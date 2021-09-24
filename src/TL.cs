using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace TL
{
	public interface ITLObject { }
	public delegate string ITLFunction(BinaryWriter writer);

	public static class Serialization
	{
		internal static byte[] Serialize(this ITLObject msg)
		{
			using var memStream = new MemoryStream(1024);
			using (var writer = new BinaryWriter(memStream))
				WriteTLObject(writer, msg);
			return memStream.ToArray();
		}

		internal static T Deserialize<T>(byte[] bytes) where T : ITLObject
		{
			using var memStream = new MemoryStream(bytes);
			using var reader = new BinaryReader(memStream, null);
			return (T)reader.ReadTLObject();
		}

		internal static void WriteTLObject(this BinaryWriter writer, ITLObject obj)
		{
			if (obj == null) { writer.Write(Layer.NullCtor); return; }
			var type = obj.GetType();
			var ctorNb = type.GetCustomAttribute<TLDefAttribute>().CtorNb;
			writer.Write(ctorNb);
			var fields = obj.GetType().GetFields().GroupBy(f => f.DeclaringType).Reverse().SelectMany(g => g);
			int flags = 0;
			IfFlagAttribute ifFlag;
			foreach (var field in fields)
			{
				if (((ifFlag = field.GetCustomAttribute<IfFlagAttribute>()) != null) && (flags & (1 << ifFlag.Bit)) == 0) continue;
				object value = field.GetValue(obj);
				if (value == null)
					writer.WriteTLNull(field.FieldType);
				else
					writer.WriteTLValue(value);
				if (field.Name.Equals("Flags", StringComparison.OrdinalIgnoreCase)) flags = (int)value;
			}
		}

		internal static ITLObject ReadTLObject(this BinaryReader reader, uint ctorNb = 0)
		{
			if (ctorNb == 0) ctorNb = reader.ReadUInt32();
			if (ctorNb == Layer.NullCtor) return null;
			if (!Layer.Table.TryGetValue(ctorNb, out var type))
				throw new ApplicationException($"Cannot find type for ctor #{ctorNb:x}");
			var obj = Activator.CreateInstance(type);
			var fields = type.GetFields().GroupBy(f => f.DeclaringType).Reverse().SelectMany(g => g);
			int flags = 0;
			IfFlagAttribute ifFlag;
			foreach (var field in fields)
			{
				if (((ifFlag = field.GetCustomAttribute<IfFlagAttribute>()) != null) && (flags & (1 << ifFlag.Bit)) == 0) continue;
				object value = reader.ReadTLValue(field.FieldType);
				field.SetValue(obj, value);
				if (field.Name == "flags") flags = (int)value;
				else if (field.Name == "access_hash") reader.Client?.UpdateAccessHash(obj, type, value);
			}
			return type == typeof(GzipPacked) ? UnzipPacket((GzipPacked)obj, reader.Client) : (ITLObject)obj;
		}

		internal static void WriteTLValue(this BinaryWriter writer, object value)
		{
			var type = value.GetType();
			switch (Type.GetTypeCode(type))
			{
				case TypeCode.Int32: writer.Write((int)value); break;
				case TypeCode.UInt32: writer.Write((uint)value); break;
				case TypeCode.Int64: writer.Write((long)value); break;
				case TypeCode.UInt64: writer.Write((ulong)value); break;
				case TypeCode.Double: writer.Write((double)value); break;
				case TypeCode.String: writer.WriteTLString((string)value); break;
				case TypeCode.DateTime: writer.WriteTLStamp((DateTime)value); break;
				case TypeCode.Boolean: writer.Write((bool)value ? 0x997275B5 : 0xBC799737); break;
				case TypeCode.Object:
					if (type.IsArray)
						if (value is byte[] bytes)
							writer.WriteTLBytes(bytes);
						else
							writer.WriteTLVector((Array)value);
					else if (value is Int128 int128)
						writer.Write(int128);
					else if (value is Int256 int256)
						writer.Write(int256);
					else if (value is ITLObject tlObject)
						WriteTLObject(writer, tlObject);
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
				case TypeCode.UInt32: return reader.ReadUInt32();
				case TypeCode.Int64: return reader.ReadInt64();
				case TypeCode.UInt64: return reader.ReadUInt64();
				case TypeCode.Double: return reader.ReadDouble();
				case TypeCode.String: return reader.ReadTLString();
				case TypeCode.DateTime: return reader.ReadTLStamp();
				case TypeCode.Boolean:
					return reader.ReadUInt32() switch
					{
						0x997275b5 => true,
						0xbc799737 => false,
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
			for (int i = 0; i < count; i++)
				writer.WriteTLValue(array.GetValue(i));
		}

		internal static Array ReadTLVector(this BinaryReader reader, Type type)
		{
			var elementType = type.GetElementType();
			uint ctorNb = reader.ReadUInt32();
			if (ctorNb == Layer.VectorCtor)
			{
				int count = reader.ReadInt32();
				Array array = (Array)Activator.CreateInstance(type, count);
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

		internal static void WriteTLStamp(this BinaryWriter writer, DateTime datetime)
			=> writer.Write((uint)(datetime.ToUniversalTime().Ticks / 10000000 - 62135596800L));

		internal static DateTime ReadTLStamp(this BinaryReader reader)
			=> new((reader.ReadUInt32() + 62135596800L) * 10000000, DateTimeKind.Utc);

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
			if (!type.IsArray)
				writer.Write(Layer.NullCtor);
			else if (type != typeof(byte[]))
				writer.Write(Layer.VectorCtor);
			writer.Write(0);    // null arrays are serialized as empty
		}

		internal static ITLObject UnzipPacket(GzipPacked obj, WTelegram.Client client)
		{
			using var reader = new BinaryReader(new GZipStream(new MemoryStream(obj.packed_data), CompressionMode.Decompress), client);
			var result = reader.ReadTLObject();
			return result;
		}

#if DEBUG
		private static void ShouldntBeHere() => System.Diagnostics.Debugger.Break();
#else
		private static void ShouldntBeHere() => throw new NotImplementedException("You've reached an unexpected point in code");
#endif
	}

	public class BinaryReader : System.IO.BinaryReader
	{
		public readonly WTelegram.Client Client;
		public BinaryReader(Stream stream, WTelegram.Client client) : base(stream) => Client = client;
	}

	[AttributeUsage(AttributeTargets.Class)]
	public class TLDefAttribute : Attribute
	{
		public readonly uint CtorNb;
		public TLDefAttribute(uint ctorNb) => CtorNb = ctorNb;
	}

	[AttributeUsage(AttributeTargets.Field)]
	public class IfFlagAttribute : Attribute
	{
		public readonly int Bit;
		public IfFlagAttribute(int bit) => Bit = bit;
	}

	public struct Int128
	{
		public byte[] raw;

		public Int128(BinaryReader reader) => raw = reader.ReadBytes(16);
		public Int128(RNGCryptoServiceProvider rng) => rng.GetBytes(raw = new byte[16]);
		public static bool operator ==(Int128 left, Int128 right) { for (int i = 0; i < 16; i++) if (left.raw[i] != right.raw[i]) return false; return true; }
		public static bool operator !=(Int128 left, Int128 right) { for (int i = 0; i < 16; i++) if (left.raw[i] != right.raw[i]) return true; return false; }
		public override bool Equals(object obj) => obj is Int128 other && this == other;
		public override int GetHashCode() => HashCode.Combine(raw[0], raw[1]);
		public static implicit operator byte[](Int128 int128) => int128.raw;
	}

	public struct Int256
	{
		public byte[] raw;

		public Int256(BinaryReader reader) => raw = reader.ReadBytes(32);
		public Int256(RNGCryptoServiceProvider rng) => rng.GetBytes(raw = new byte[32]);
		public static bool operator ==(Int256 left, Int256 right) { for (int i = 0; i < 32; i++) if (left.raw[i] != right.raw[i]) return false; return true; }
		public static bool operator !=(Int256 left, Int256 right) { for (int i = 0; i < 32; i++) if (left.raw[i] != right.raw[i]) return true; return false; }
		public override bool Equals(object obj) => obj is Int256 other && this == other;
		public override int GetHashCode() => HashCode.Combine(raw[0], raw[1]);
		public static implicit operator byte[](Int256 int256) => int256.raw;
	}

	public class RpcException : Exception
	{
		public readonly int Code;
		public RpcException(int code, string message) : base(message) => Code = code;
	}

	public class ReactorError : ITLObject
	{
		public Exception Exception;
	}

	// Below TL types are commented "parsed manually" from https://github.com/telegramdesktop/tdesktop/blob/dev/Telegram/Resources/tl/mtproto.tl

	[TLDef(0xF35C6D01)] //rpc_result#f35c6d01 req_msg_id:long result:Object = RpcResult
	public partial class RpcResult : ITLObject
	{
		public long req_msg_id;
		public object result;
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006")]
	[TLDef(0x5BB8E511)] //message#5bb8e511 msg_id:long seqno:int bytes:int body:Object = Message
	public partial class _Message
	{
		public long msg_id;
		public int seqno;
		public int bytes;
		public ITLObject body;
	}

	[TLDef(0x73F1F8DC)] //msg_container#73f1f8dc messages:vector<%Message> = MessageContainer
	public partial class MsgContainer : ITLObject { public _Message[] messages; }
	[TLDef(0xE06046B2)] //msg_copy#e06046b2 orig_message:Message = MessageCopy
	public partial class MsgCopy : ITLObject { public _Message orig_message; }

	[TLDef(0x3072CFA1)] //gzip_packed#3072cfa1 packed_data:bytes = Object
	public partial class GzipPacked : ITLObject { public byte[] packed_data; }
}
