using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WTelegram
{
	public class Generator
	{
		readonly Dictionary<int, string> ctorToTypes = new();
		readonly HashSet<string> allTypes = new();
		readonly Dictionary<string, int> knownStyles = new() { ["InitConnection"] = 1, ["Help_GetConfig"] = 0, ["HttpWait"] = -1 };
		readonly Dictionary<string, TypeInfo> typeInfos = new();
		readonly HashSet<string> enumTypes = new();
		int currentLayer;
		string tabIndent;
		private string currentJson;

		public async Task FromWeb()
		{
			Console.WriteLine("Fetch web pages...");
#if DEBUG
			currentLayer = await Task.FromResult(TL.Layer.Version);
#else
			using var http = new HttpClient();
			//var html = await http.GetStringAsync("https://core.telegram.org/api/layers");
			//currentLayer = int.Parse(Regex.Match(html, @"#layer-(\d+)").Groups[1].Value);
			//File.WriteAllBytes("TL.MTProto.json", await http.GetByteArrayAsync("https://core.telegram.org/schema/mtproto-json"));
			//File.WriteAllBytes("TL.Schema.json", await http.GetByteArrayAsync("https://core.telegram.org/schema/json"));
			File.WriteAllBytes("TL.MTProto.tl", await http.GetByteArrayAsync("https://raw.githubusercontent.com/telegramdesktop/tdesktop/dev/Telegram/Resources/tl/mtproto.tl"));
			File.WriteAllBytes("TL.Schema.tl", await http.GetByteArrayAsync("https://raw.githubusercontent.com/telegramdesktop/tdesktop/dev/Telegram/Resources/tl/api.tl"));
			File.WriteAllBytes("TL.Secret.json", await http.GetByteArrayAsync("https://core.telegram.org/schema/end-to-end-json"));
#endif
			//FromJson("TL.MTProto.json", "TL.MTProto.cs", @"TL.Table.cs");
			//FromJson("TL.Schema.json", "TL.Schema.cs", @"TL.Table.cs");
			FromTL("TL.MTProto.tl", "TL.MTProto.cs");
			FromTL("TL.Schema.tl", "TL.Schema.cs");
			FromJson("TL.Secret.json", "TL.Secret.cs");
		}

		private void FromTL(string tlPath, string outputCs)
		{
			using var sr = new StreamReader(tlPath);
			var schema = new SchemaJson { constructors = new(), methods = new() };
			string line;
			bool inFunctions = false;
			while ((line = sr.ReadLine()) != null)
			{
				line = line.Trim();
				if (line == "---functions---")
					inFunctions = true;
				else if (line == "---types---")
					inFunctions = false;
				else if (line.StartsWith("// LAYER "))
					currentLayer = int.Parse(line[9..]);
				else if (line != "" && !line.StartsWith("//"))
				{
					if (!line.EndsWith(";")) System.Diagnostics.Debugger.Break();
					var words = line.Split(' ');
					int hash = words[0].IndexOf('#');
					if (hash == -1) { Console.WriteLine(line); continue; }
					if (words[^2] != "=") { Console.WriteLine(line); continue; }
					string name = words[0][0..hash];
					int id = int.Parse(words[0][(hash + 1)..], System.Globalization.NumberStyles.HexNumber);
					string type = words[^1].TrimEnd(';');
					var @params = words[1..^2].Where(word => word != "{X:Type}").Select(word =>
					{
						int colon = word.IndexOf(':');
						string name = word[0..colon];
						string type = word[(colon + 1)..];
						if (type == "string" && outputCs == "TL.MTProto.cs" && !name.Contains("message")) type = "bytes";
						return new Param { name = name, type = type };
					}).ToArray();
					if (inFunctions)
						schema.methods.Add(new Method { id = id.ToString(), method = name, type = type, @params = @params });
					else
						schema.constructors.Add(new Constructor { id = id.ToString(), predicate = name, type = type, @params = @params });
				}
			}
			FromSchema(schema, outputCs);
		}

		public void FromJson(string jsonPath, string outputCs)
		{
			Console.WriteLine("Parsing " + jsonPath);
			var schema = JsonSerializer.Deserialize<SchemaJson>(File.ReadAllText(jsonPath));
			FromSchema(schema, outputCs);
		}

		public void FromSchema(SchemaJson schema, string outputCs)
		{
			currentJson = Path.GetFileNameWithoutExtension(outputCs);
			using var sw = new StreamWriter(outputCs, false, Encoding.UTF8);
			sw.WriteLine("// This file is generated automatically using the Generator class");
			sw.WriteLine("using System;");
			sw.WriteLine("using System.Collections.Generic;");
			if (schema.methods.Count != 0) sw.WriteLine("using System.Threading.Tasks;");
			sw.WriteLine();
			sw.WriteLine("namespace TL");
			sw.WriteLine("{");
			sw.WriteLine("\tusing BinaryWriter = System.IO.BinaryWriter;");
			sw.WriteLine("\tusing Client = WTelegram.Client;");
			tabIndent = "\t";
			foreach (var ctor in schema.constructors)
			{
				if (ctorToTypes.ContainsKey(ctor.ID)) continue;
				if (ctor.type == "Vector t") continue;
				var structName = CSharpName(ctor.predicate);
				ctorToTypes[ctor.ID] = ctor.layer == 0 ? structName : $"Layer{ctor.layer}.{structName}";
				var typeInfo = typeInfos.GetOrCreate(ctor.type);
				if (ctor.ID == 0x5BB8E511) { ctorToTypes[ctor.ID] = structName = ctor.predicate = ctor.type = "_Message"; }
				else if (ctor.ID == TL.Layer.NullCtor) { ctorToTypes[ctor.ID] += "=null"; typeInfo.Nullable = ctor; }
				if (typeInfo.ReturnName == null) typeInfo.ReturnName = CSharpName(ctor.type);
				typeInfo.Structs.Add(ctor);
				if (structName == typeInfo.ReturnName) typeInfo.MainClass = ctor;
			}
			foreach (var (name, typeInfo) in typeInfos)
			{
				if (allTypes.Contains(typeInfo.ReturnName))
				{
					if (typeInfos.TryGetValue(typeInfo.ReturnName, out var existingType))
					{
						typeInfo.ReturnName = existingType.ReturnName;
						typeInfo.MainClass = existingType.MainClass;
					}
					continue;
				}

				if (typeInfo.Structs.All(ctor => ctor.@params.Length == 0))
					typeInfo.AsEnum = true;
				var nullable = typeInfo.Structs.Where(c => c.predicate == "help.noAppUpdate" ||
					c.predicate.EndsWith("Empty") || c.predicate.EndsWith("Unknown") || c.predicate.EndsWith("NotModified")).ToList();
				if (nullable.Count == 1 && nullable[0].@params.Length == 0 && !typeInfo.AsEnum)
				{
					typeInfo.Nullable = nullable[0];
					typeInfo.Structs.Remove(typeInfo.Nullable);
					ctorToTypes[typeInfo.Nullable.ID] += "=null";
				}
				if (typeInfo.MainClass == null)
				{
					List<Param> fakeCtorParams = new();
					if (typeInfo.Structs.Count > 1)
					{
						while (typeInfo.Structs[0].@params.Length > fakeCtorParams.Count)
						{
							fakeCtorParams.Add(typeInfo.Structs[0].@params[fakeCtorParams.Count]);
							if (!typeInfo.Structs.All(ctor => HasPrefix(ctor, fakeCtorParams)))
							{
								fakeCtorParams.RemoveAt(fakeCtorParams.Count - 1);
								break;
							}
						}
						if (fakeCtorParams.Count == 0)
							while (typeInfo.Structs[0].@params.Length > fakeCtorParams.Count)
							{
								fakeCtorParams.Insert(0, typeInfo.Structs[0].@params[^(fakeCtorParams.Count + 1)]);
								if (!typeInfo.Structs.All(ctor => HasSuffix(ctor, fakeCtorParams)))
								{
									fakeCtorParams.RemoveAt(0);
									break;
								}
							}
					}
					typeInfo.MainClass = new Constructor { id = null, @params = fakeCtorParams.ToArray(), predicate = typeInfo.ReturnName, type = name };
					typeInfo.Structs.Insert(0, typeInfo.MainClass);
					typeInfo.CommonFields = fakeCtorParams.Count; // generation of abstract main class with some common fields
				}
				else if (typeInfo.Structs.Count > 1)
				{
					if (typeInfo.Structs.All(ctor => ctor == typeInfo.MainClass || HasPrefix(ctor, typeInfo.MainClass.@params) || HasSuffix(ctor, typeInfo.MainClass.@params)))
						typeInfo.CommonFields = typeInfo.MainClass.@params.Length;
					else
					{
						// the previous MainClass (ctor have the same name as ReturnName) is incompatible with other classes fields
						typeInfo.MainClass = new Constructor { id = null, @params = Array.Empty<Param>(), predicate = typeInfo.ReturnName + "Base", type = name };
						typeInfo.Structs.Insert(0, typeInfo.MainClass);
						typeInfo.ReturnName = typeInfo.MainClass.predicate;
					}
					typeInfo.AbstractUserOrChat = AbstractUserOrChatTypes.Contains(typeInfo.ReturnName);
					if (typeInfo.CommonFields == 0)
					{
						var autoProps = typeInfo.Structs.OrderByDescending(s => s.@params.Length).First().@params
							.Where(p => !p.type.EndsWith("?true")).ToList();
						if (typeInfo.AbstractUserOrChat) { autoProps.Remove(ParamUsers); autoProps.Remove(ParamChats); }
						autoProps.Remove(ParamFlags);
						int autoPropsCount = 0;
						foreach (var str in typeInfo.Structs)
						{
							if (str.ID == 0 ||str.predicate.EndsWith("Empty") || str.predicate.EndsWith("TooLong") || str.predicate.EndsWith("NotModified")) continue;
							for (int i = autoProps.Count - 1; i >= 0; i--)
								if (!str.@params.Contains(autoProps[i]))
									autoProps.RemoveAt(i);
							if (autoProps.Count == 0) break;
							++autoPropsCount;
						}
						if (autoProps.Count > 0 && autoPropsCount > 1)
							typeInfo.AutoProps = autoProps;
					}

				}
			}
			var layers = schema.constructors.Select(c => c.layer).Distinct().ToList();
			if (layers.Count > 1) // multi-layer file => generate abstract classes out of layer namespaces first
				foreach (var typeInfo in typeInfos.Values)
					WriteTypeInfo(sw, typeInfo, 0);
			foreach (var layer in layers)
			{
				if (layer != 0)
				{
					sw.WriteLine();
					sw.WriteLine("\tnamespace Layer" + layer);
					sw.Write("\t{");
					tabIndent += "\t";
				}
				foreach (var typeInfo in typeInfos.Values)
					WriteTypeInfo(sw, typeInfo, layer);
				if (layer != 0)
				{
					sw.WriteLine("\t}");
					tabIndent = tabIndent[1..];
				}
			}
			if (typeInfos.GetValueOrDefault("Message")?.MainClass.ID == 0x5BB8E511) typeInfos.Remove("Message");

			if (schema.methods.Count != 0)
			{
				var ping = schema.methods.FirstOrDefault(m => m.method == "ping");
				if (ping != null)
				{
					var typeInfo = new TypeInfo { ReturnName = ping.type, MainClass = 
						new Constructor { id = ping.id, @params = ping.@params, predicate = ping.method, type = ping.type } };
					typeInfo.Structs.Add(typeInfo.MainClass);
					ctorToTypes[int.Parse(ping.id)] = CSharpName(ping.method);
					WriteTypeInfo(sw, typeInfo, 0);
				}
				sw.WriteLine();
				sw.WriteLine("\t// ---functions---");
				sw.WriteLine();
				sw.WriteLine($"\tpublic static class {currentJson[3..]}");
				//sw.WriteLine("\tpublic static partial class Fn // ---functions---");
				sw.Write("\t{");
				tabIndent = "\t\t";
				foreach (var method in schema.methods)
				{
					WriteMethod(sw, method);
					//var typeInfo = new TypeInfo { ReturnName = method.type };
					//typeInfo.Structs.Add(new Constructor { id = method.id, @params = method.@params, predicate = method.method, type = method.type });
					//methods.Add(typeInfo);
					//WriteTypeInfo(sw, typeInfo, "", true);
				}
				sw.WriteLine("\t}");
			}
			sw.WriteLine("}");

			UpdateTable("TL.Table.cs");
		}

		void WriteTypeInfo(StreamWriter sw, TypeInfo typeInfo, int layer)
		{
			var genericType = typeInfo.ReturnName.Length == 1 ? $"<{typeInfo.ReturnName}>" : null;
			bool needNewLine = true;
			int commonFields = 0;
			foreach (var ctor in typeInfo.Structs)
			{
				if (ctor.layer != layer) continue;
				int ctorId = ctor.ID;
				string className = CSharpName(ctor.predicate) + genericType;
				if (!allTypes.Add((layer == 0 ? "" : $"Layer{layer}.") + className)) continue;
				if (needNewLine) { needNewLine = false; sw.WriteLine(); }
				var parentClass = ctor == typeInfo.MainClass ? "ITLObject" : typeInfo.ReturnName;
				var parms = ctor.@params;
				if (ctorId == 0) // abstract parent
				{
					if (currentJson != "TL.MTProto")
						sw.WriteLine($"{tabIndent}///<summary>See <a href=\"https://corefork.telegram.org/type/{typeInfo.Structs[0].type}\"/></summary>");
					if (typeInfo.Nullable != null)
						sw.WriteLine($"{tabIndent}///<remarks>a <c>null</c> value means <a href=\"https://corefork.telegram.org/constructor/{typeInfo.Nullable.predicate}\">{typeInfo.Nullable.predicate}</a></remarks>");
					if (typeInfo.AsEnum)
					{
						WriteTypeAsEnum(sw, typeInfo);
						return;
					}
					sw.Write($"{tabIndent}public abstract partial class {ctor.predicate}");
				}
				else
				{
					string tldefReverse = null;
					if (commonFields != 0)
					{
						if (ctor.@params[0].name == typeInfo.MainClass.@params[0].name)
							parms = ctor.@params.Skip(commonFields).ToArray();
						else
						{
							parms = ctor.@params.Take(ctor.@params.Length - commonFields).ToArray();
							tldefReverse = ", inheritAfter = true";
						}
					}
					else
					{
						foreach (var other in typeInfo.Structs)
						{
							if (other == ctor) continue;
							var otherParams = other.@params;
							if (otherParams.Length <= commonFields) continue;
							if (!IsDerivedName(ctor.predicate, other.predicate)) continue;
							if (HasPrefix(ctor, otherParams))
							{
								parms = ctor.@params.Skip(otherParams.Length).ToArray();
								tldefReverse = null;
							}
							else if (HasSuffix(ctor, otherParams))
							{
								parms = ctor.@params.Take(ctor.@params.Length - otherParams.Length).ToArray();
								tldefReverse = ", inheritAfter = true";
							}
							else continue;
							commonFields = otherParams.Length;
							parentClass = CSharpName(other.predicate) + genericType;
						}
					}
					if (currentJson != "TL.MTProto")
					{
						sw.WriteLine($"{tabIndent}///<summary>See <a href=\"https://corefork.telegram.org/constructor/{ctor.predicate}\"/></summary>");
						if (typeInfo.Nullable != null && ctor == typeInfo.MainClass)
							sw.WriteLine($"{tabIndent}///<remarks>a <c>null</c> value means <a href=\"https://corefork.telegram.org/constructor/{typeInfo.Nullable.predicate}\">{typeInfo.Nullable.predicate}</a></remarks>");
						sw.WriteLine($"{tabIndent}[TLDef(0x{ctor.ID:X8}{tldefReverse})]");
					}
					else
					{
						sw.Write($"{tabIndent}[TLDef(0x{ctor.ID:X8}{tldefReverse})] //{ctor.predicate}#{ctor.ID:x8} ");
						if (genericType != null) sw.Write($"{{{typeInfo.ReturnName}:Type}} ");
						foreach (var parm in ctor.@params) sw.Write($"{parm.name}:{parm.type} ");
						sw.WriteLine($"= {ctor.type}");
					}
					sw.Write($"{tabIndent}public partial class {className}");
					//sw.Write(skipParams == 0 && typeInfo.NeedAbstract > 0 ? "ITLObject" : parentClass);
				}
				sw.Write(" : ");
				sw.Write(parentClass);
				if (parms.Length == 0 && !typeInfo.AbstractUserOrChat && typeInfo.AutoProps == null)
				{
					sw.WriteLine(" { }");
					commonFields = typeInfo.CommonFields;
					continue;
				}
				var hasFlagEnum = parms.Any(p => p.type.StartsWith("flags."));
				bool multiline = hasFlagEnum || parms.Length > 1 || typeInfo.AbstractUserOrChat || typeInfo.AutoProps != null;
				if (multiline)
				{
					sw.WriteLine();
					sw.WriteLine(tabIndent + "{");
				}
				else
					sw.Write(" { ");
				if (hasFlagEnum)
				{
					var list = new SortedList<int, string>();
					foreach (var parm in parms)
					{
						if (!parm.type.StartsWith("flags.") || !parm.type.EndsWith("?true")) continue;
						var mask = 1 << int.Parse(parm.type[6..parm.type.IndexOf('?')]);
						if (!list.ContainsKey(mask)) list[mask] = MapName(parm.name);
					}
					foreach (var parm in parms)
					{
						if (!parm.type.StartsWith("flags.") || parm.type.EndsWith("?true")) continue;
						var mask = 1 << int.Parse(parm.type[6..parm.type.IndexOf('?')]);
						if (list.ContainsKey(mask)) continue;
						var name = MapName("has_" + parm.name);
						if (list.Values.Contains(name)) name += "_field";
						list[mask] = name;
					}
					string line = tabIndent + "\t[Flags] public enum Flags { ";
					foreach (var (mask, name) in list)
					{
						var str = $"{name} = 0x{mask:X}, ";
						if (line.Length + str.Length + tabIndent.Length * 3 >= 134) { sw.WriteLine(line); line = tabIndent + "\t\t"; }
						line += str;
					}
					sw.WriteLine(line.TrimEnd(',', ' ') + " }");
				}
				foreach (var parm in parms)
				{
					if (parm.type.EndsWith("?true")) continue;
					if (multiline) sw.Write(tabIndent + "\t");
					if (parm.type == "#")
						sw.Write($"public {(hasFlagEnum ? "Flags" : "int")} {parm.name};");
					else
					{
						if (parm.type.StartsWith("flags."))
						{
							int qm = parm.type.IndexOf('?');
							sw.Write($"[IfFlag({parm.type[6..qm]})] public {MapType(parm.type[(qm + 1)..], parm.name)} {MapName(parm.name)};");
						}
						else
							sw.Write($"public {MapType(parm.type, parm.name)} {MapName(parm.name)};");
					}
					if (multiline) sw.WriteLine();
				}
				if (typeInfo.AutoProps != null)
				{
					bool firstLine = parms.Length != 0;
					string format = $"{tabIndent}\tpublic ";
					if (ctorId == 0)
						format += "abstract {0} {1} {{ get; }}";
					else if (ctor == typeInfo.MainClass)
						format += "virtual {0} {1} => {2};";
					else
						format += "override {0} {1} => {2};";
					foreach (var parm in typeInfo.AutoProps)
					{
						var value = "default";
						if (ctor.@params.Any(p => p.name == parm.name))
							if (!parms.Any(p => p.name == parm.name)) continue;
							else value = MapName(parm.name);
						else if (parm.type.StartsWith("Vector<") && className.EndsWith("Empty"))
							value = $"Array.Empty<{MapType(parm.type, parm.name).TrimEnd('[', ']')}>()";
						string csName = CSharpName(parm.name);
						if (csName.EndsWith("Id") && parm.type != "int" && parm.type != "long") csName = csName[..^2];
						if (firstLine) { sw.WriteLine(); firstLine = false; }
						sw.WriteLine(string.Format(format, MapType(parm.type, parm.name), csName, value));
					}
				}
				var hasUsersChats = parms.Contains(ParamUsers) && parms.Contains(ParamChats);
				if (hasUsersChats || (typeInfo.AbstractUserOrChat && (ctor == typeInfo.MainClass || parentClass == typeInfo.ReturnName)))
				{
					var modifier = !typeInfo.AbstractUserOrChat ? null : ctorId == 0 ? "abstract " : "override ";
					sw.Write($"{tabIndent}\tpublic {modifier}IPeerInfo UserOrChat");
					if (!hasUsersChats || ctor.@params.Length != 3 || !parms.Contains(ParamPeer))
						sw.Write("(Peer peer)");
					if (modifier == "abstract ")
						sw.WriteLine(";");
					else if (hasUsersChats)
						sw.WriteLine(" => peer.UserOrChat(users, chats);");
					else
						sw.WriteLine(" => null;");
				}

				if (multiline)
					sw.WriteLine(tabIndent + "}");
				else
					sw.WriteLine(" }");
				commonFields = typeInfo.CommonFields;
			}
		}
		static readonly Param ParamFlags = new() { name = "flags", type = "#" };
		static readonly Param ParamPeer = new() { name = "peer", type = "Peer" };
		static readonly Param ParamUsers = new() { name = "users", type = "Vector<User>" };
		static readonly Param ParamChats = new() { name = "chats", type = "Vector<Chat>" };
		static readonly HashSet<string> AbstractUserOrChatTypes = new() {
			"Messages_MessagesBase", "Updates_DifferenceBase", "Updates_ChannelDifferenceBase",
			"Messages_DialogsBase"
		};

		private static bool IsDerivedName(string derived, string basename)
		{
			int left, right;
			if (basename.Length >= derived.Length) return false;
			for (left = 0; left < basename.Length; left++)
				if (basename[left] != derived[left])
					break;
			if (left == 0) return false;
			for (right = 1; left + right <= basename.Length; right++)
				if (basename[^right] != derived[^right])
					break;
			return left + right > basename.Length;
		}

		private void WriteTypeAsEnum(StreamWriter sw, TypeInfo typeInfo)
		{
			enumTypes.Add(typeInfo.ReturnName);
			bool lowercase = typeInfo.ReturnName == "Storage_FileType";
			sw.WriteLine($"{tabIndent}public enum {typeInfo.ReturnName} : uint");
			sw.WriteLine($"{tabIndent}{{");
			string prefix = "";
			while ((prefix += typeInfo.Structs[1].predicate[prefix.Length]) != null)
				if (!typeInfo.Structs.All(ctor => ctor.id == null || ctor.predicate.StartsWith(prefix)))
					break;
			int prefixLen = CSharpName(prefix).Length - 1;
			foreach (var ctor in typeInfo.Structs)
			{
				if (ctor.id == null) continue;
				string className = CSharpName(ctor.predicate);
				if (!allTypes.Add(className)) continue;
				if (lowercase) className = className.ToLowerInvariant();
				ctorToTypes.Remove(ctor.ID);
				sw.WriteLine($"{tabIndent}\t///<summary>See <a href=\"https://corefork.telegram.org/constructor/{ctor.predicate}\"/></summary>");
				sw.WriteLine($"{tabIndent}\t{className[prefixLen..]} = 0x{ctor.ID:X8},");
			}
			sw.WriteLine($"{tabIndent}}}");
		}


		private static string MapName(string name) => name switch
		{
			"out" => "out_",
			"static" => "static_",
			"long" => "long_",
			"default" => "default_",
			"public" => "public_",
			"params" => "params_",
			"private" => "private_",
			_ => name
		};

		private string MapType(string type, string name)
		{
			if (type.StartsWith("flags.")) type = type[(type.IndexOf('?') + 1)..];
			if (type.StartsWith("Vector<", StringComparison.OrdinalIgnoreCase))
			{
				if (name == "users" && type == "Vector<User>")
					return $"Dictionary<long, " + MapType(type[7..^1], name) + ">";
				else if (name == "chats" && type == "Vector<Chat>")
					return $"Dictionary<long, " + MapType(type[7..^1], name) + ">";
				return MapType(type[7..^1], name) + "[]";
			}
			else if (type == "Bool")
				return "bool";
			else if (type == "bytes")
				return "byte[]";
			else if (type == "int128")
				return "Int128";
			else if (type == "int256")
				return "Int256";
			else if (type == "Object")
				return "ITLObject";
			else if (type == "!X")
				return "ITLFunction";
			else if (type == "int")
			{
				var name2 = '_' + name + '_';
				if (name2.EndsWith("_date_") || name2.EndsWith("_time_") || name2.StartsWith("_valid_") ||
					name2 == "_expires_" || name2 == "_expires_at_" || name2 == "_now_")
					return "DateTime";
				else
					return "int";
			}
			else if (type == "string")
				return name.StartsWith("md5") ? "byte[]" : "string";
			else if (type == "long" || type == "double" || type == "X")
				return type;
			else if (typeInfos.TryGetValue(type, out var typeInfo))
				return typeInfo.ReturnName;
			else
			{   // try to find type in a lower layer
				/*foreach (var layer in typeInfosByLayer.OrderByDescending(kvp => kvp.Key))
					if (layer.Value.TryGetValue(type, out typeInfo))
						return layer.Key == 0 ? typeInfo.ReturnName : $"Layer{layer.Key}.{typeInfo.ReturnName}";*/
				return CSharpName(type);
			}
		}

		private string MapOptionalType(string type, string name)
		{
			if (type == "Bool")
				return "bool?";
			else if (type == "long")
				return "long?";
			else if (type == "double")
				return "double?";
			else if (type == "int128")
				return "Int128?";
			else if (type == "int256")
				return "Int256?";
			else if (type == "int")
			{
				var name2 = '_' + name + '_';
				if (name2.EndsWith("_date_") || name2.EndsWith("_time_") || name2 == "_expires_" || name2 == "_now_" || name2.StartsWith("_valid_"))
					return "DateTime?";
				else
					return "int?";
			}
			else
				return MapType(type, name);
		}

		private void WriteMethod(StreamWriter sw, Method method)
		{
			int ctorNb = int.Parse(method.id);
			var funcName = CSharpName(method.method);
			string returnType = MapType(method.type, "");
			int style = knownStyles.GetValueOrDefault(funcName, 2);
			// styles: 0 = static string, 1 = static ITLFunction<>, 2 = Task<>, -1 = skip method
			if (style == -1) return;
			sw.WriteLine();

			var callAsync = "CallAsync";
			if (method.type.Length == 1 && style != 1) funcName += $"<{returnType}>";
			if (currentJson != "TL.MTProto")
				sw.WriteLine($"{tabIndent}///<summary>See <a href=\"https://corefork.telegram.org/method/{method.method}\"/></summary>");
			else
			{
				if (method.type is not "FutureSalts" and not "Pong") callAsync = "CallBareAsync";
				sw.Write($"{tabIndent}//{method.method}#{ctorNb:x8} ");
				if (method.type.Length == 1) sw.Write($"{{{method.type}:Type}} ");
				foreach (var parm in method.@params) sw.Write($"{parm.name}:{parm.type} ");
				sw.WriteLine($"= {method.type}");
			}

			if (style == 0) sw.WriteLine($"{tabIndent}public static Task<{returnType}> {funcName}(this Client client) => client.{callAsync}<{returnType}>({funcName});");
			if (style == 0) sw.Write($"{tabIndent}public static string {funcName}(BinaryWriter writer");
			if (style == 1) sw.Write($"{tabIndent}public static ITLFunction {funcName}(");
			if (style == 2) sw.Write($"{tabIndent}public static Task<{returnType}> {funcName}(this Client client");
			bool first = style == 1;
			foreach (var parm in method.@params) // output non-optional parameters
			{
				if (parm.type == "#" || parm.type.StartsWith("flags.")) continue;
				if (first) first = false; else sw.Write(", ");
				sw.Write($"{MapType(parm.type, parm.name)} {MapName(parm.name)}");
			}
			string flagExpr = null;
			foreach (var parm in method.@params) // output optional parameters
			{
				if (!parm.type.StartsWith("flags.")) continue;
				var parmName = MapName(parm.name);
				int qm = parm.type.IndexOf('?');
				int bit = int.Parse(parm.type[6..qm]);
				if (first) first = false; else sw.Write(", ");
				if (parm.type.EndsWith("?true"))
				{
					sw.Write($"bool {parmName} = false");
					flagExpr += $" | ({parmName} ? 0x{1 << bit:X} : 0)";
				}
				else
				{
					sw.Write($"{MapOptionalType(parm.type[(qm + 1)..], parm.name)} {parmName} = null");
					flagExpr += $" | ({parmName} != null ? 0x{1 << bit:X} : 0)";
				}
			}
			if (flagExpr != null) flagExpr = flagExpr.IndexOf('|', 3) >= 0 ? flagExpr[3..] : flagExpr[4..^1];
			sw.WriteLine(")");
			if (style != 0) tabIndent += "\t";
			if (style == 1) sw.WriteLine($"{tabIndent}=> writer =>");
			if (style == 2) sw.WriteLine($"{tabIndent}=> client.{callAsync}<{returnType}>(writer =>");
			sw.WriteLine(tabIndent + "{");
			sw.WriteLine($"{tabIndent}\twriter.Write(0x{ctorNb:X8});");
			foreach (var parm in method.@params) // serialize request
			{
				var parmName = MapName(parm.name);
				var parmType = parm.type;
				if (parmType.StartsWith("flags."))
				{
					if (parmType.EndsWith("?true")) continue;
					int qm = parmType.IndexOf('?');
					parmType = parmType[(qm + 1)..];
					sw.WriteLine($"{tabIndent}\tif ({parmName} != null)");
					sw.Write('\t');
					if (MapOptionalType(parmType, parm.name).EndsWith("?"))
						parmName += ".Value";
				}
				switch (parmType)
				{
					case "Bool":
						sw.WriteLine($"{tabIndent}\twriter.Write({parmName} ? 0x997275B5 : 0xBC799737);");
						break;
					case "bytes":
						sw.WriteLine($"{tabIndent}\twriter.WriteTLBytes({parmName});");
						break;
					case "long": case "int128": case "int256": case "double":
						sw.WriteLine($"{tabIndent}\twriter.Write({parmName});");
						break;
					case "int":
						if (MapType(parmType, parm.name) == "int")
							sw.WriteLine($"{tabIndent}\twriter.Write({parmName});");
						else
							sw.WriteLine($"{tabIndent}\twriter.WriteTLStamp({parmName});");
						break;
					case "string":
						if (parm.name.StartsWith("md5"))
							sw.WriteLine($"{tabIndent}\twriter.WriteTLBytes({parmName});");
						else
							sw.WriteLine($"{tabIndent}\twriter.WriteTLString({parmName});");
						break;
					case "#":
						sw.WriteLine($"{tabIndent}\twriter.Write({flagExpr});");
						break;
					case "!X":
						sw.WriteLine($"{tabIndent}\t{parmName}(writer);");
						break;
					default:
						if (parmType.StartsWith("Vector<", StringComparison.OrdinalIgnoreCase))
							sw.WriteLine($"{tabIndent}\twriter.WriteTLVector({parmName});");
						else if (enumTypes.Contains(parmType))
							sw.WriteLine($"{tabIndent}\twriter.Write((uint){parmName});");
						else
							sw.WriteLine($"{tabIndent}\twriter.WriteTLObject({parmName});");
						break;
				}
			}
			sw.WriteLine($"{tabIndent}\treturn \"{funcName}\";");
			if (style == 0) sw.WriteLine(tabIndent + "}");
			if (style == 1) sw.WriteLine(tabIndent + "};");
			if (style == 2) sw.WriteLine(tabIndent + "});");
			if (style != 0) tabIndent = tabIndent[0..^1];
		}

		void UpdateTable(string tableCs)
		{
			int tableId = 0;
			var myTag = $"\t\t\t// from {currentJson}:";
			var seen_ids = new HashSet<int>();
			var seen_nullables = new HashSet<string>();
			using (var sr = new StreamReader(tableCs))
			using (var sw = new StreamWriter(tableCs + ".new", false, Encoding.UTF8))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					if (currentLayer != 0 && line.StartsWith("\t\tpublic const int Layer"))
						sw.WriteLine($"\t\tpublic const int Layer = {currentLayer};\t\t\t\t\t// fetched {DateTime.UtcNow}");
					else
						sw.WriteLine(line);
					if (line == myTag)
					{
						switch (++tableId)
						{
							case 1:
								foreach (var ctor in ctorToTypes)
									if (seen_ids.Add(ctor.Key))
										if (ctor.Value.EndsWith("=null"))
											sw.WriteLine($"\t\t\t[0x{ctor.Key:X8}] = null,//{ctor.Value[..^5]}");
										else
											sw.WriteLine($"\t\t\t[0x{ctor.Key:X8}] = typeof({ctor.Value}),");
								break;
							case 2:
								foreach (var typeInfo in typeInfos.Values)
									if (typeInfo.Nullable != null && seen_nullables.Add(typeInfo.ReturnName))
										sw.WriteLine($"\t\t\t[typeof({typeInfo.ReturnName})]{new string(' ', 30 - typeInfo.ReturnName.Length)} = 0x{typeInfo.Nullable.ID:X8}, //{typeInfo.Nullable.predicate}");
								break;
						}
						while ((line = sr.ReadLine()) != null)
							if (line.StartsWith("\t\t\t// "))
								break;
						sw.WriteLine(line);
					}
					else if (line.StartsWith("\t\t\t[0x"))
						seen_ids.Add(int.Parse(line[6..14], System.Globalization.NumberStyles.HexNumber));
					else if (line.StartsWith("\t\t\t[typeof("))
						seen_nullables.Add(line[11..line.IndexOf(')')]);
				}
			}
			File.Replace(tableCs + ".new", tableCs, null);
		}

		private static bool HasPrefix(Constructor ctor, IList<Param> prefixParams)
		{
			if (ctor.@params.Length < prefixParams.Count) return false;
			for (int i = 0; i < prefixParams.Count; i++)
				if (ctor.@params[i].name != prefixParams[i].name || ctor.@params[i].type != prefixParams[i].type)
					return false;
			return true;
		}

		private static bool HasSuffix(Constructor ctor, IList<Param> prefixParams)
		{
			if (ctor.@params.Length < prefixParams.Count) return false;
			for (int i = 1; i <= prefixParams.Count; i++)
				if (ctor.@params[^i].name != prefixParams[^i].name || ctor.@params[^i].type != prefixParams[^i].type)
					return false;
			return true;
		}

		private static string CSharpName(string name)
		{
			if (name == "id") return "ID";
			name = char.ToUpper(name[0]) + name[1..];
			int i;
			while ((i = name.IndexOf('_')) > 0)
				name = name[..i] + char.ToUpper(name[i + 1]) + name[(i + 2)..];
			while ((i = name.IndexOf('.')) > 0)
				name = name[..i] + '_' + char.ToUpper(name[i + 1]) + name[(i + 2)..];
			return name;
		}

		class TypeInfo
		{
			public string ReturnName;
			public Constructor MainClass;
			public Constructor Nullable;
			public List<Constructor> Structs = new();
			internal int CommonFields; // n fields are common among all those classes
			internal bool AsEnum;
			internal bool AbstractUserOrChat;
			internal List<Param> AutoProps;
		}

#pragma warning disable IDE1006 // Naming Styles
		public class SchemaJson
		{
			public List<Constructor> constructors { get; set; }
			public List<Method> methods { get; set; }
		}

		public class Constructor
		{
			public string id { get; set; }
			public string predicate { get; set; }
			public Param[] @params { get; set; }
			public string type { get; set; }
			public int layer { get; set; }

			public int ID => string.IsNullOrEmpty(id) ? 0 : int.Parse(id);
		}

		public class Param
		{
			public string name { get; set; }
			public string type { get; set; }
			public override bool Equals(object obj) => obj is Param other && other.name == name && other.type == type;
			public override int GetHashCode() => HashCode.Combine(name, type);
		}

		public class Method
		{
			public string id { get; set; }
			public string method { get; set; }
			public Param[] @params { get; set; }
			public string type { get; set; }
		}
#pragma warning restore IDE1006 // Naming Styles
	}
}
