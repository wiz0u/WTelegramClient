using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using WTelegram;

namespace TL
{
	public interface ITLObject { }
	public interface ITLFunction<R> : ITLObject { }

	public static partial class Schema
	{
		internal static byte[] Serialize(ITLObject msg)
		{
			using var memStream = new MemoryStream(1024);
			using (var writer = new BinaryWriter(memStream))
				Serialize(writer, msg);
			return memStream.ToArray();
		}

		internal static T Deserialize<T>(byte[] bytes) where T : ITLObject
		{
			using var memStream = new MemoryStream(bytes);
			using var reader = new BinaryReader(memStream);
			return Deserialize<T>(reader);
		}

		internal static void Serialize(BinaryWriter writer, ITLObject msg)
		{
			var type = msg.GetType();
			var ctorNb = type.GetCustomAttribute<TLDefAttribute>().CtorNb;
			writer.Write(ctorNb);
			SerializeObject(writer, msg);
		}

		internal static T Deserialize<T>(BinaryReader reader) where T : ITLObject
		{
			var ctorNb = reader.ReadUInt32();
			if (!Table.TryGetValue(ctorNb, out var realType))
				throw new ApplicationException($"Cannot find type for ctor #{ctorNb:x}");
			return (T)DeserializeObject(reader, realType);
		}

		internal static void SerializeObject(BinaryWriter writer, object obj)
		{
			var fields = obj.GetType().GetFields().GroupBy(f => f.DeclaringType).Reverse().SelectMany(g => g);
			int flags = 0;
			IfFlagAttribute ifFlag;
			foreach (var field in fields)
			{
				if (((ifFlag = field.GetCustomAttribute<IfFlagAttribute>()) != null) && (flags & (1 << ifFlag.Bit)) == 0) continue;
				object value = field.GetValue(obj);
				if (value == null)
					SerializeNull(writer, field.FieldType);
				else
					SerializeValue(writer, value);
				if (field.Name.Equals("Flags", StringComparison.OrdinalIgnoreCase)) flags = (int)value;
			}
		}

		internal static ITLObject DeserializeObject(BinaryReader reader, Type type)
		{
			var obj = Activator.CreateInstance(type);
			var fields = obj.GetType().GetFields().GroupBy(f => f.DeclaringType).Reverse().SelectMany(g => g);
			int flags = 0;
			IfFlagAttribute ifFlag;
			foreach (var field in fields)
			{
				if (((ifFlag = field.GetCustomAttribute<IfFlagAttribute>()) != null) && (flags & (1 << ifFlag.Bit)) == 0) continue;
				object value = DeserializeValue(reader, field.FieldType);
				field.SetValue(obj, value);
				if (field.Name.Equals("Flags", StringComparison.OrdinalIgnoreCase)) flags = (int)value;
			}
			return type == typeof(GzipPacked) ? UnzipPacket((GzipPacked)obj) : (ITLObject)obj;
		}

		internal static void SerializeValue(BinaryWriter writer, object value)
		{
			var type = value.GetType();
			switch (Type.GetTypeCode(type))
			{
				case TypeCode.Int32: writer.Write((int)value); break;
				case TypeCode.UInt32: writer.Write((uint)value); break;
				case TypeCode.Int64: writer.Write((long)value); break;
				case TypeCode.UInt64: writer.Write((ulong)value); break;
				case TypeCode.Double: writer.Write((double)value); break;
				case TypeCode.String: SerializeBytes(writer, Encoding.UTF8.GetBytes((string)value)); break;
				case TypeCode.DateTime: writer.Write((uint)(((DateTime)value).ToUniversalTime().Ticks / 10000000 - 62135596800L)); break;
				case TypeCode.Boolean: writer.Write((bool)value ? 0x997275b5 : 0xbc799737); break;
				case TypeCode.Object:
					if (type.IsArray)
					{
						if (value is byte[] bytes)
							SerializeBytes(writer, bytes);
						else
							SerializeVector(writer, (Array)value);
					}
					else if (value is Int128 int128)
						writer.Write(int128);
					else if (value is Int256 int256)
						writer.Write(int256);
					else if (type.IsValueType)
						SerializeObject(writer, value);
					else if (value is ITLObject tlObject)
						Serialize(writer, tlObject);
					else
						ShouldntBeHere();
					break;
				default:
					ShouldntBeHere();
					break;
			}
		}

		internal static object DeserializeValue(BinaryReader reader, Type type)
		{
			switch (Type.GetTypeCode(type))
			{
				case TypeCode.Int32: return reader.ReadInt32();
				case TypeCode.UInt32: return reader.ReadUInt32();
				case TypeCode.Int64: return reader.ReadInt64();
				case TypeCode.UInt64: return reader.ReadUInt64();
				case TypeCode.Double: return reader.ReadDouble();
				case TypeCode.String: return Encoding.UTF8.GetString(DeserializeBytes(reader));
				case TypeCode.DateTime: return new DateTime((reader.ReadUInt32() + 62135596800L) * 10000000, DateTimeKind.Utc);
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
							return DeserializeBytes(reader);
						else if (type == typeof(_Message[]))
							return DeserializeMessages(reader);
						else
							return DeserializeVector(reader, type);
					}
					else if (type == typeof(Int128))
						return new Int128(reader);
					else if (type == typeof(Int256))
						return new Int256(reader);
					else if (type.IsValueType)
						return DeserializeObject(reader, type);
					else
						return Deserialize<ITLObject>(reader);
				default:
					ShouldntBeHere();
					return null;
			}
		}

		private static void SerializeVector(BinaryWriter writer, Array array)
		{
			writer.Write(VectorCtor);
			int count = array.Length;
			writer.Write(count);
			for (int i = 0; i < count; i++)
				SerializeValue(writer, array.GetValue(i));
		}

		private static object DeserializeVector(BinaryReader reader, Type type)
		{
			var ctorNb = reader.ReadInt32();
			if (ctorNb != VectorCtor) throw new ApplicationException($"Cannot deserialize {type.Name} with ctor #{ctorNb:x}");
			var elementType = type.GetElementType();
			int count = reader.ReadInt32();
			Array array = (Array)Activator.CreateInstance(type, count);
			for (int i = 0; i < count; i++)
				array.SetValue(DeserializeValue(reader, elementType), i);
			return array;
		}

		private static void SerializeBytes(BinaryWriter writer, byte[] bytes)
		{
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

		private static byte[] DeserializeBytes(BinaryReader reader)
		{
			byte[] bytes;
			int length = reader.ReadByte();
			if (length < 254)
				bytes = reader.ReadBytes(length);
			else
			{
				length = reader.ReadInt16() + (reader.ReadByte() << 16);
				bytes = reader.ReadBytes(length);
				length += 3;
			}
			while (++length % 4 != 0) reader.ReadByte();
			return bytes;
		}

		internal static void SerializeNull(BinaryWriter writer, Type type)
		{
			if (!type.IsArray)
				writer.Write(NullCtor);
			else if (type != typeof(byte[]))	// null arrays are serialized as empty
				writer.Write(VectorCtor);
			writer.Write(0);
		}

		private static _Message[] DeserializeMessages(BinaryReader reader)
		{
			int count = reader.ReadInt32();
			var array = new _Message[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = new _Message
				{
					msg_id = reader.ReadInt64(),
					seqno = reader.ReadInt32(),
					bytes = reader.ReadInt32(),
				};
				var pos = reader.BaseStream.Position;
				try
				{
					array[i].body = (ITLObject)DeserializeValue(reader, typeof(ITLObject));
				}
				catch (Exception ex)
				{
					Helpers.Log(4, ex.ToString());
				}
				reader.BaseStream.Position = pos + array[i].bytes;
			}
			return array;
		}

		private static ITLObject UnzipPacket(GzipPacked obj)
		{
			using var reader = new BinaryReader(new GZipStream(new MemoryStream(obj.packed_data), CompressionMode.Decompress));
			var result = Deserialize<ITLObject>(reader);
			Helpers.Log(1, $"            → {result.GetType().Name}");
			return result;
		}

#if DEBUG
		private static void ShouldntBeHere() => System.Diagnostics.Debugger.Break();
#else
		private static void ShouldntBeHere() => throw new NotImplementedException("You've reached an unexpected point in code");
#endif
	}

	[AttributeUsage(AttributeTargets.Class)]
	public class TLDefAttribute : Attribute
	{
		public readonly uint CtorNb;
		public TLDefAttribute(uint ctorNb) => CtorNb = ctorNb;
		/*public TLDefAttribute(string def)
		{
			var hash = def.IndexOfAny(new[] { '#', ' ' });
			CtorNb = def[hash] == ' ' ? Force.Crc32.Crc32Algorithm.Compute(System.Text.Encoding.UTF8.GetBytes(def))
									  : uint.Parse(def[(hash + 1)..def.IndexOf(' ', hash)], System.Globalization.NumberStyles.HexNumber);
		}*/
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
}
