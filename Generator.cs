using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WTelegram
{
	public class Generator
	{
		//TODO: generate BinaryReader/Writer serialization directly to avoid using Reflection
		//TODO: generate partial class with methods for functions instead of exposing request classes
		readonly Dictionary<int, string> ctorToTypes = new();
		readonly HashSet<string> allTypes = new();
		readonly Dictionary<int, Dictionary<string, TypeInfo>> typeInfosByLayer = new();
		Dictionary<string, TypeInfo> typeInfos;
		int currentLayer;
		string tabIndent;

		public async Task FromWeb()
		{
			Console.WriteLine("Fetch web pages...");
			//using var http = new HttpClient();
			//var html = await http.GetStringAsync("https://core.telegram.org/api/layers");
			var html = await Task.FromResult("#layer-121");
			currentLayer = int.Parse(Regex.Match(html, @"#layer-(\d+)").Groups[1].Value);
			//await File.WriteAllBytesAsync("TL.MTProto.json", await http.GetByteArrayAsync("https://core.telegram.org/schema/mtproto-json"));
			//await File.WriteAllBytesAsync("TL.Schema.json", await http.GetByteArrayAsync("https://core.telegram.org/schema/json"));
			//await File.WriteAllBytesAsync("TL.Secret.json", await http.GetByteArrayAsync("https://core.telegram.org/schema/end-to-end-json"));
			FromJson("TL.MTProto.json", "TL.MTProto.cs", @"TL.Table.cs");
			FromJson("TL.Schema.json", "TL.Schema.cs", @"TL.Table.cs");
			FromJson("TL.Secret.json", "TL.Secret.cs", @"TL.Table.cs");
		}

		public void FromJson(string jsonPath, string outputCs, string tableCs = null)
		{
			Console.WriteLine("Parsing " + jsonPath);
			var schema = JsonSerializer.Deserialize<SchemaJson>(File.ReadAllText(jsonPath));
			using var sw = File.CreateText(outputCs);
			sw.WriteLine("using System;");
			sw.WriteLine();
			sw.WriteLine("namespace TL");
			sw.Write("{");
			tabIndent = "\t";
			var layers = schema.constructors.GroupBy(c => c.layer).OrderBy(g => g.Key);
			foreach (var layer in layers)
			{
				typeInfos = typeInfosByLayer.GetOrCreate(layer.Key);
				if (layer.Key != 0)
				{
					sw.WriteLine();
					sw.WriteLine("\tnamespace Layer" + layer.Key);
					sw.Write("\t{");
					tabIndent += "\t";
				}
				string layerPrefix = layer.Key == 0 ? "" : $"Layer{layer.Key}.";
				foreach (var ctor in layer)
				{
					if (ctorToTypes.ContainsKey(ctor.ID)) continue;
					if (ctor.type is "Bool" or "Vector t") continue;
					var structName = CSharpName(ctor.predicate);
					ctorToTypes[ctor.ID] = layerPrefix + structName;
					var typeInfo = typeInfos.GetOrCreate(ctor.type);
					if (ctor.ID == 0x5BB8E511) { ctorToTypes[ctor.ID] = structName = ctor.predicate = ctor.type = "_Message"; }
					if (typeInfo.ReturnName == null) typeInfo.ReturnName = CSharpName(ctor.type);
					typeInfo.Structs.Add(ctor);
					if (structName == typeInfo.ReturnName) typeInfo.SameName = ctor;
				}
				foreach (var (name, typeInfo) in typeInfos)
				{
					if (allTypes.Contains(typeInfo.ReturnName)) { typeInfo.NeedAbstract = -2; continue; }
					if (typeInfo.SameName == null)
					{
						typeInfo.NeedAbstract = -1;
						if (typeInfo.Structs.Count > 1)
						{
							List<Param> fakeCtorParams = new();
							while (typeInfo.Structs[0].@params.Length > fakeCtorParams.Count)
							{
								fakeCtorParams.Add(typeInfo.Structs[0].@params[fakeCtorParams.Count]);
								if (!typeInfo.Structs.All(ctor => HasPrefix(ctor, fakeCtorParams)))
								{
									fakeCtorParams.RemoveAt(fakeCtorParams.Count - 1);
									break;
								}
							}
							if (fakeCtorParams.Count > 0)
							{
								typeInfo.Structs.Insert(0, typeInfo.SameName = new Constructor
								{ id = null, @params = fakeCtorParams.ToArray(), predicate = typeInfo.ReturnName, type = typeInfo.ReturnName });
								typeInfo.NeedAbstract = fakeCtorParams.Count;
							}
						}
					}
					else if (typeInfo.Structs.Count > 1)
					{
						typeInfo.NeedAbstract = typeInfo.SameName.@params.Length;
						foreach (var ctor in typeInfo.Structs)
						{
							if (ctor == typeInfo.SameName) continue;
							if (!HasPrefix(ctor, typeInfo.SameName.@params)) { typeInfo.NeedAbstract = -1; typeInfo.ReturnName += "Base"; break; }
						}
					}
				}
				foreach (var typeInfo in typeInfos.Values)
					WriteTypeInfo(sw, typeInfo, jsonPath, layerPrefix, false);
				if (layer.Key != 0)
				{
					sw.WriteLine("\t}");
					tabIndent = tabIndent[1..];
				}
			}
			if (typeInfosByLayer[0]["Message"].SameName.ID == 0x5BB8E511) typeInfosByLayer[0].Remove("Message");

			sw.WriteLine();
			var methods = new List<TypeInfo>();
			if (schema.methods.Length != 0)
			{
				typeInfos = typeInfosByLayer[0];
				sw.WriteLine("\tpublic static partial class Fn // ---functions---");
				sw.Write("\t{");
				tabIndent = "\t\t";
				foreach (var method in schema.methods)
				{
					var typeInfo = new TypeInfo { ReturnName = method.type };
					typeInfo.Structs.Add(new Constructor { id = method.id, @params = method.@params, predicate = method.method, type = method.type });
					methods.Add(typeInfo);
					WriteTypeInfo(sw, typeInfo, jsonPath, "", true);
				}
				sw.WriteLine("\t}");
			}
			sw.WriteLine("}");

			if (tableCs != null) UpdateTable(jsonPath, tableCs, methods);
		}

		void WriteTypeInfo(StreamWriter sw, TypeInfo typeInfo, string definedIn, string layerPrefix, bool isMethod)
		{
			var parentClass = typeInfo.NeedAbstract != 0 ? typeInfo.ReturnName : "ITLObject";
			var genericType = typeInfo.ReturnName.Length == 1 ? $"<{typeInfo.ReturnName}>" : null;
			if (isMethod) parentClass = $"ITLFunction<{MapType(typeInfo.ReturnName, "")}>";
			bool needNewLine = true;
			if (typeInfo.NeedAbstract == -1 && allTypes.Add(layerPrefix + parentClass))
			{
				needNewLine = false;
				sw.WriteLine();
				sw.WriteLine($"{tabIndent}public abstract class {parentClass} : ITLObject {{ }}");
			}
			int skipParams = 0;
			foreach (var ctor in typeInfo.Structs)
			{
				string className = CSharpName(ctor.predicate) + genericType;
				//if (typeInfo.ReturnName == "SendMessageAction") System.Diagnostics.Debugger.Break();
				if (layerPrefix != "" && className == parentClass) { className += "_"; ctorToTypes[ctor.ID] = layerPrefix + className; }
				if (!allTypes.Add(layerPrefix + className)) continue;
				if (needNewLine) { needNewLine = false; sw.WriteLine(); }
				if (ctor.id == null)
					sw.Write($"{tabIndent}public abstract class {className} : ITLObject");
				else
				{
					sw.Write($"{tabIndent}[TLDef(0x{ctor.ID:X8})] //{ctor.predicate}#{ctor.ID:x8} ");
					if (genericType != null) sw.Write($"{{{typeInfo.ReturnName}:Type}} ");
					foreach (var parm in ctor.@params) sw.Write($"{parm.name}:{parm.type} ");
					sw.WriteLine($"= {ctor.type}");
					sw.Write($"{tabIndent}public class {className} : ");
					sw.Write(skipParams == 0 && typeInfo.NeedAbstract > 0 ? "ITLObject" : parentClass);
				}
				var parms = ctor.@params.Skip(skipParams).ToArray();
				if (parms.Length == 0)
				{
					sw.WriteLine(" { }");
					continue;
				}
				var hasFlagEnum = parms.Any(p => p.type.StartsWith("flags."));
				bool multiline = hasFlagEnum || parms.Length > 1;
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

				if (ctorNeedClone.Contains(className))
					sw.WriteLine($"{tabIndent}\tpublic {className} Clone() => ({className})MemberwiseClone();");
				if (multiline)
					sw.WriteLine(tabIndent + "}");
				else
					sw.WriteLine(" }");
				skipParams = typeInfo.NeedAbstract;
			}
			string MapName(string name) => name switch
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

			string MapType(string type, string name)
			{
				if (type.StartsWith("Vector<", StringComparison.OrdinalIgnoreCase))
					return MapType(type[7..^1], name) + "[]";
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
					return "ITLFunction<X>";
				else if (typeInfos.TryGetValue(type, out var typeInfo))
					return typeInfo.ReturnName;
				else if (type == "int")
				{
					var name2 = '_' + name + '_';
					if (name2.EndsWith("_date_") || name2.EndsWith("_time_") || name2 == "_expires_" || name2 == "_now_" || name2.StartsWith("_valid_"))
						return "DateTime";
					else
						return "int";
				}
				else if (type == "string")
					return name.StartsWith("md5") ? "byte[]" : "string";
				else
					return type;
			}
		}

		void UpdateTable(string jsonPath, string tableCs, List<TypeInfo> methods)
		{
			var myTag = $"\t\t\t// from {Path.GetFileNameWithoutExtension(jsonPath)}:";
			var seen_ids = new HashSet<int>();
			using (var sr = new StreamReader(tableCs))
			using (var sw = new StreamWriter(tableCs + ".new"))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					if (currentLayer != 0 && line.StartsWith("\t\tpublic const int Layer"))
						sw.WriteLine($"\t\tpublic const int Layer = {currentLayer};\t\t\t\t// fetched {DateTime.UtcNow}");
					else
						sw.WriteLine(line);
					if (line == myTag)
					{
						foreach (var ctor in ctorToTypes)
							if (seen_ids.Add(ctor.Key))
								sw.WriteLine($"\t\t\t[0x{ctor.Key:X8}] = typeof({ctor.Value}),");
						while ((line = sr.ReadLine()) != null)
							if (line.StartsWith("\t\t\t// "))
								break;
						sw.WriteLine(line);
					}
					else if (line.StartsWith("\t\t\t[0x"))
						seen_ids.Add(int.Parse(line[6..14], System.Globalization.NumberStyles.HexNumber));
				}
			}
			File.Replace(tableCs + ".new", tableCs, null);
		}

		static readonly HashSet<string> ctorNeedClone = new() { /*"User"*/ };

		private static bool HasPrefix(Constructor ctor, IList<Param> prefixParams)
		{
			if (ctor.@params.Length < prefixParams.Count) return false;
			for (int i = 0; i < prefixParams.Count; i++)
				if (ctor.@params[i].name != prefixParams[i].name || ctor.@params[i].type != prefixParams[i].type)
					return false;
			return true;
		}

		private static string CSharpName(string name)
		{
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
			public Constructor SameName;
			public List<Constructor> Structs = new();
			internal int NeedAbstract; // 0:no, -1:create auto, n:use first generated constructor and skip n params
		}

#pragma warning disable IDE1006 // Naming Styles
		public class SchemaJson
		{
			public Constructor[] constructors { get; set; }
			public Method[] methods { get; set; }
		}

		public class Constructor
		{
			public string id { get; set; }
			public string predicate { get; set; }
			public Param[] @params { get; set; }
			public string type { get; set; }
			public int layer { get; set; }

			public int ID => int.Parse(id);
		}

		public class Param
		{
			public string name { get; set; }
			public string type { get; set; }
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
