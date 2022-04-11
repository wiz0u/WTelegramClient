using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace TL
{
	public interface IObject { }
	public interface IMethod<ReturnType> : IObject { }
	public interface IPeerResolver { IPeerInfo UserOrChat(Peer peer); }

	[AttributeUsage(AttributeTargets.Class)]
	public class TLDefAttribute : Attribute
	{
		public readonly uint CtorNb;
		public TLDefAttribute(uint ctorNb) => CtorNb = ctorNb;
		public bool inheritBefore;
	}

	[AttributeUsage(AttributeTargets.Field)]
	public class IfFlagAttribute : Attribute
	{
		public readonly int Bit;
		public IfFlagAttribute(int bit) => Bit = bit;
	}

	public class RpcException : Exception
	{
		public readonly int Code;
		/// <summary>The value of X in the message, -1 if no variable X was found</summary>
		public readonly int X;
		public RpcException(int code, string message, int x = -1) : base(message) { Code = code; X = x; }
		public override string ToString() { var str = base.ToString(); return str.Insert(str.IndexOf(':') + 1, " " + Code); }
	}

	public class ReactorError : IObject
	{
		public Exception Exception;
	}

	internal class BinaryReader : System.IO.BinaryReader
	{
		public readonly WTelegram.Client Client;
		public BinaryReader(Stream stream, WTelegram.Client client) : base(stream) => Client = client;
	}

	internal static class Serialization
	{
		internal static void WriteTLObject<T>(this BinaryWriter writer, T obj) where T : IObject
		{
			if (obj == null) { writer.WriteTLNull(typeof(T)); return; }
			var type = obj.GetType();
			var tlDef = type.GetCustomAttribute<TLDefAttribute>();
			var ctorNb = tlDef.CtorNb;
			writer.Write(ctorNb);
			IEnumerable<FieldInfo> fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (tlDef.inheritBefore) fields = fields.GroupBy(f => f.DeclaringType).Reverse().SelectMany(g => g);
			uint flags = 0;
			IfFlagAttribute ifFlag;
			foreach (var field in fields)
			{
				if (((ifFlag = field.GetCustomAttribute<IfFlagAttribute>()) != null) && (flags & (1U << ifFlag.Bit)) == 0) continue;
				object value = field.GetValue(obj);
				writer.WriteTLValue(value, field.FieldType);
				if (field.FieldType.IsEnum && field.Name == "flags") flags = (uint)value;
			}
		}

		internal static IObject ReadTLObject(this BinaryReader reader, uint ctorNb = 0)
		{
			if (ctorNb == 0) ctorNb = reader.ReadUInt32();
			if (ctorNb == Layer.GZipedCtor)
				using (var gzipReader = new BinaryReader(new GZipStream(new MemoryStream(reader.ReadTLBytes()), CompressionMode.Decompress), reader.Client))
					return ReadTLObject(gzipReader);
			if (!Layer.Table.TryGetValue(ctorNb, out var type))
				throw new ApplicationException($"Cannot find type for ctor #{ctorNb:x}");
			if (type == null) return null; // nullable ctor (class meaning is associated with null)
			var tlDef = type.GetCustomAttribute<TLDefAttribute>();
			var obj = Activator.CreateInstance(type, true);
			IEnumerable<FieldInfo> fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (tlDef.inheritBefore) fields = fields.GroupBy(f => f.DeclaringType).Reverse().SelectMany(g => g);
			uint flags = 0;
			IfFlagAttribute ifFlag;
			foreach (var field in fields)
			{
				if (((ifFlag = field.GetCustomAttribute<IfFlagAttribute>()) != null) && (flags & (1U << ifFlag.Bit)) == 0) continue;
				object value = reader.ReadTLValue(field.FieldType);
				field.SetValue(obj, value);
				if (field.FieldType.IsEnum && field.Name == "flags") flags = (uint)value;
				if (reader.Client.CollectAccessHash) reader.Client.CollectField(field, obj, value);
			}
			return (IObject)obj;
		}

		internal static void WriteTLValue(this BinaryWriter writer, object value, Type valueType)
		{
			if (value == null)
			{
				writer.WriteTLNull(valueType);
				return;
			}
			var type = value.GetType();
			switch (Type.GetTypeCode(type))
			{
				case TypeCode.Int32: writer.Write((int)value); break;
				case TypeCode.Int64: writer.Write((long)value); break;
				case TypeCode.UInt32: writer.Write((uint)value); break;
				case TypeCode.UInt64: writer.Write((ulong)value); break;
				case TypeCode.Double: writer.Write((double)value); break;
				case TypeCode.String: writer.WriteTLString((string)value); break;
				case TypeCode.Boolean: writer.Write((bool)value ? 0x997275B5 : 0xBC799737); break;
				case TypeCode.DateTime: writer.WriteTLStamp((DateTime)value); break;
				case TypeCode.Object:
					if (type.IsArray)
						if (value is byte[] bytes)
							writer.WriteTLBytes(bytes);
						else if (value is _Message[] messages)
							writer.WriteTLMessages(messages);
						else
							writer.WriteTLVector((Array)value);
					else if (value is Int128 int128)
						writer.Write(int128);
					else if (value is Int256 int256)
						writer.Write(int256);
					else if (value is IObject tlObject)
						WriteTLObject(writer, tlObject);
					else if (type.IsEnum) // needed for Mono (enums in generic types are seen as TypeCode.Object)
						writer.Write((uint)value);
					else
						ShouldntBeHere();
					break;
				default:
					ShouldntBeHere();
					break;
			}
		}

		internal static object ReadTLValue(this BinaryReader reader, Type type)
		{
			switch (Type.GetTypeCode(type))
			{
				case TypeCode.Int32: return reader.ReadInt32();
				case TypeCode.Int64: return reader.ReadInt64();
				case TypeCode.UInt32: return reader.ReadUInt32();
				case TypeCode.UInt64: return reader.ReadUInt64();
				case TypeCode.Double: return reader.ReadDouble();
				case TypeCode.String: return reader.ReadTLString();
				case TypeCode.DateTime: return reader.ReadTLStamp();
				case TypeCode.Boolean:
					return reader.ReadUInt32() switch
					{
						0x997275b5 => true,
						0xbc799737 => false,
						Layer.RpcErrorCtor => reader.ReadTLObject(Layer.RpcErrorCtor),
						var value => throw new ApplicationException($"Invalid boolean value #{value:x}")
					};
				case TypeCode.Object:
					if (type.IsArray)
					{
						if (type == typeof(byte[]))
							return reader.ReadTLBytes();
						else
							return reader.ReadTLVector(type);
					}
					else if (type == typeof(Int128))
						return new Int128(reader);
					else if (type == typeof(Int256))
						return new Int256(reader);
					else if (type == typeof(Dictionary<long, User>))
						return reader.ReadTLDictionary<User>(u => u.ID);
					else if (type == typeof(Dictionary<long, ChatBase>))
						return reader.ReadTLDictionary<ChatBase>(c => c.ID);
					else
						return reader.ReadTLObject();
				default:
					ShouldntBeHere();
					return null;
			}
		}

		internal static void WriteTLVector(this BinaryWriter writer, Array array)
		{
			writer.Write(Layer.VectorCtor);
			if (array == null) { writer.Write(0); return; }
			int count = array.Length;
			writer.Write(count);
			var elementType = array.GetType().GetElementType();
			for (int i = 0; i < count; i++)
				writer.WriteTLValue(array.GetValue(i), elementType);
		}

		internal static void WriteTLMessages(this BinaryWriter writer, _Message[] messages)
		{
			writer.Write(messages.Length);
			foreach (var msg in messages)
			{
				writer.Write(msg.msg_id);
				writer.Write(msg.seqno);
				var patchPos = writer.BaseStream.Position;
				writer.Write(0);						// patched below
				writer.WriteTLObject(msg.body);
				if ((msg.seqno & 1) != 0)
					WTelegram.Helpers.Log(1, $"            → {msg.body.GetType().Name.TrimEnd('_'),-38} #{(short)msg.msg_id.GetHashCode():X4}");
				else
					WTelegram.Helpers.Log(1, $"            → {msg.body.GetType().Name.TrimEnd('_'),-38}");
				writer.BaseStream.Position = patchPos;
				writer.Write((int)(writer.BaseStream.Length - patchPos - 4)); // patch bytes field
				writer.Seek(0, SeekOrigin.End);
			}
		}

		internal static Array ReadTLVector(this BinaryReader reader, Type type)
		{
			var elementType = type.GetElementType();
			uint ctorNb = reader.ReadUInt32();
			if (ctorNb == Layer.VectorCtor)
			{
				int count = reader.ReadInt32();
				Array array = (Array)Activator.CreateInstance(type, count);
				if (elementType.IsEnum)
					for (int i = 0; i < count; i++)
						array.SetValue(Enum.ToObject(elementType, reader.ReadTLValue(elementType)), i);
				else
					for (int i = 0; i < count; i++)
						array.SetValue(reader.ReadTLValue(elementType), i);
				return array;
			}
			else if (ctorNb < 1024 && !elementType.IsAbstract && elementType.GetCustomAttribute<TLDefAttribute>() is TLDefAttribute attr)
			{
				int count = (int)ctorNb;
				Array array = (Array)Activator.CreateInstance(type, count);
				for (int i = 0; i < count; i++)
					array.SetValue(reader.ReadTLObject(attr.CtorNb), i);
				return array;
			}
			else
				throw new ApplicationException($"Cannot deserialize {type.Name} with ctor #{ctorNb:x}");
		}

		internal static Dictionary<long, T> ReadTLDictionary<T>(this BinaryReader reader, Func<T, long> getID) where T : class
		{
			uint ctorNb = reader.ReadUInt32();
			var elementType = typeof(T);
			if (ctorNb != Layer.VectorCtor)
				throw new ApplicationException($"Cannot deserialize Vector<{elementType.Name}> with ctor #{ctorNb:x}");
			int count = reader.ReadInt32();
			var dict = new Dictionary<long, T>(count);
			for (int i = 0; i < count; i++)
			{
				var value = (T)reader.ReadTLValue(elementType);
				dict[getID(value)] = value is UserEmpty ? null : value;
			}
			return dict;
		}

		internal static void WriteTLStamp(this BinaryWriter writer, DateTime datetime)
			=> writer.Write(datetime == DateTime.MaxValue ? int.MaxValue : (int)(datetime.ToUniversalTime().Ticks / 10000000 - 62135596800L));

		internal static DateTime ReadTLStamp(this BinaryReader reader)
		{
			int unixstamp = reader.ReadInt32();
			return unixstamp == int.MaxValue ? DateTime.MaxValue : new((unixstamp + 62135596800L) * 10000000, DateTimeKind.Utc);
		}

		internal static void WriteTLString(this BinaryWriter writer, string str)
		{
			if (str == null)
				writer.Write(0);
			else
				writer.WriteTLBytes(Encoding.UTF8.GetBytes(str));
		}

		internal static string ReadTLString(this BinaryReader reader)
			=> Encoding.UTF8.GetString(reader.ReadTLBytes());

		internal static void WriteTLBytes(this BinaryWriter writer, byte[] bytes)
		{
			if (bytes == null) { writer.Write(0); return; }
			int length = bytes.Length;
			if (length < 254)
				writer.Write((byte)length);
			else
			{
				writer.Write(length << 8 | 254);
				length += 3;
			}
			writer.Write(bytes);
			while (++length % 4 != 0) writer.Write((byte)0);
		}

		internal static byte[] ReadTLBytes(this BinaryReader reader)
		{
			byte[] bytes;
			int length = reader.ReadByte();
			if (length < 254)
				bytes = reader.ReadBytes(length);
			else
			{
				length = reader.ReadUInt16() + (reader.ReadByte() << 16);
				bytes = reader.ReadBytes(length);
				length += 3;
			}
			while (++length % 4 != 0) reader.ReadByte();
			return bytes;
		}

		internal static void WriteTLNull(this BinaryWriter writer, Type type)
		{
			if (type == typeof(string)) { }
			else if (!type.IsArray)
			{
				writer.Write(Layer.Nullables.TryGetValue(type, out uint nullCtor) ? nullCtor : Layer.NullCtor);
				return;
			}
			else if (type != typeof(byte[]))
				writer.Write(Layer.VectorCtor); // not raw bytes but a vector => needs a VectorCtor
			writer.Write(0);    // null arrays/strings are serialized as empty
		}

#if DEBUG
		private static void ShouldntBeHere() => System.Diagnostics.Debugger.Break();
#else
		private static void ShouldntBeHere() => throw new NotImplementedException("You've reached an unexpected point in code");
#endif
	}

	public struct Int128
	{
		public byte[] raw;

		public Int128(System.IO.BinaryReader reader) => raw = reader.ReadBytes(16);
		public Int128(RNGCryptoServiceProvider rng) => rng.GetBytes(raw = new byte[16]);
		public static bool operator ==(Int128 left, Int128 right) { for (int i = 0; i < 16; i++) if (left.raw[i] != right.raw[i]) return false; return true; }
		public static bool operator !=(Int128 left, Int128 right) { for (int i = 0; i < 16; i++) if (left.raw[i] != right.raw[i]) return true; return false; }
		public override bool Equals(object obj) => obj is Int128 other && this == other;
		public override int GetHashCode() => BitConverter.ToInt32(raw, 0);
		public override string ToString() => Convert.ToHexString(raw);
		public static implicit operator byte[](Int128 int128) => int128.raw;
	}

	public struct Int256
	{
		public byte[] raw;

		public Int256(System.IO.BinaryReader reader) => raw = reader.ReadBytes(32);
		public Int256(RNGCryptoServiceProvider rng) => rng.GetBytes(raw = new byte[32]);
		public static bool operator ==(Int256 left, Int256 right) { for (int i = 0; i < 32; i++) if (left.raw[i] != right.raw[i]) return false; return true; }
		public static bool operator !=(Int256 left, Int256 right) { for (int i = 0; i < 32; i++) if (left.raw[i] != right.raw[i]) return true; return false; }
		public override bool Equals(object obj) => obj is Int256 other && this == other;
		public override int GetHashCode() => BitConverter.ToInt32(raw, 0);
		public override string ToString() => Convert.ToHexString(raw);
		public static implicit operator byte[](Int256 int256) => int256.raw;
	}

	// Below TL types are commented "parsed manually" from https://github.com/telegramdesktop/tdesktop/blob/dev/Telegram/Resources/tl/mtproto.tl

	[TLDef(0x7A19CB76)] //RSA_public_key#7a19cb76 n:bytes e:bytes = RSAPublicKey
	public class RSAPublicKey : IObject
	{
		public byte[] n;
		public byte[] e;
	}

	[TLDef(0xF35C6D01)] //rpc_result#f35c6d01 req_msg_id:long result:Object = RpcResult
	public class RpcResult : IObject
	{
		public long req_msg_id;
		public object result;
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006")]
	[TLDef(0x5BB8E511)] //message#5bb8e511 msg_id:long seqno:int bytes:int body:Object = Message
	public class _Message
	{
		public _Message(long msgId, int seqNo, IObject obj) { msg_id = msgId; seqno = seqNo; body = obj; }
		public long msg_id;
		public int seqno;
		public int bytes;
		public IObject body;
	}

	[TLDef(0x73F1F8DC)] //msg_container#73f1f8dc messages:vector<%Message> = MessageContainer
	public class MsgContainer : IObject { public _Message[] messages; }
	[TLDef(0xE06046B2)] //msg_copy#e06046b2 orig_message:Message = MessageCopy
	public class MsgCopy : IObject { public _Message orig_message; }

	[TLDef(0x3072CFA1)] //gzip_packed#3072cfa1 packed_data:bytes = Object
	public class GzipPacked : IObject { public byte[] packed_data; }
}
