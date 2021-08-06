using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace WTelegram
{
	public static class Generator
	{
		//TODO: generate BinaryReader/Writer serialization directly to avoid using Reflection
		//TODO: generate partial class with methods for functions instead of exposing request classes

		public static void FromJson(string jsonPath, string outputCs, string tableCs = null)
		{
			var schema = JsonSerializer.Deserialize<SchemaJson>(File.ReadAllText(jsonPath));
			using var sw = File.CreateText(outputCs);
			sw.WriteLine("using System;");
			sw.WriteLine();
			sw.WriteLine("namespace TL");
			sw.Write("{");
			string tabIndent = "\t";
			Dictionary<string, TypeInfo> typeInfos = new();
			foreach (var ctor in schema.constructors)
			{
				var structName = CSharpName(ctor.predicate);
				var typeInfo = typeInfos.GetOrCreate(ctor.type);
				if (typeInfo.ReturnName == null) typeInfo.ReturnName = CSharpName(ctor.type);
				typeInfo.Structs.Add(ctor);
				if (structName == typeInfo.ReturnName) typeInfo.SameName = ctor;
			}
			typeInfos.Remove("Bool");
			typeInfos.Remove("Vector t");
			foreach (var (name, typeInfo) in typeInfos)
			{
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
				WriteTypeInfo(sw, typeInfo);

			sw.WriteLine();
			sw.WriteLine("\tpublic static partial class Fn // ---functions---");
			sw.Write("\t{");
			tabIndent = "\t\t";
			var methods = new List<TypeInfo>();
			foreach (var method in schema.methods)
			{
				var typeInfo = new TypeInfo { ReturnName = method.type };
				typeInfo.Structs.Add(new Constructor { id = method.id, @params = method.@params, predicate = method.method, type = method.type });
				methods.Add(typeInfo);
				WriteTypeInfo(sw, typeInfo, true);
			}
			sw.WriteLine("\t}");
			sw.WriteLine("}");

			if (tableCs != null) UpdateTable();

			void WriteTypeInfo(StreamWriter sw, TypeInfo typeInfo, bool isMethod = false)
			{
				var parentClass = typeInfo.NeedAbstract != 0 ? typeInfo.ReturnName : "ITLObject";
				var genericType = typeInfo.ReturnName.Length == 1 ? $"<{typeInfo.ReturnName}>" : null;
				if (isMethod)
					parentClass = $"ITLFunction<{MapType(typeInfo.ReturnName, "")}>";
				sw.WriteLine();
				if (typeInfo.NeedAbstract == -1)
					sw.WriteLine($"{tabIndent}public abstract class {parentClass} : ITLObject {{ }}");
				int skipParams = 0;
				foreach (var ctor in typeInfo.Structs)
				{
					string className = CSharpName(ctor.predicate) + genericType;
					if (ctor.id == null)
						sw.Write($"{tabIndent}public abstract class {className} : ITLObject");
					else
					{
						int ctorId = int.Parse(ctor.id);
						sw.Write($"{tabIndent}[TLDef(0x{ctorId:X8})] //{ctor.predicate}#{ctorId:x8} ");
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

			void UpdateTable()
			{
				var myTag = $"\t\t\t// from {Path.GetFileNameWithoutExtension(jsonPath)}:";
				using (var sr = new StreamReader(tableCs))
				using (var sw = new StreamWriter(tableCs + ".new"))
				{
					string line;
					while ((line = sr.ReadLine()) != null)
					{
						sw.WriteLine(line);
						if (line == myTag)
						{
							foreach (var typeInfo in typeInfos.Values)
								foreach (var ctor in typeInfo.Structs)
									if (ctor.id != null)
										sw.WriteLine($"\t\t\t[0x{int.Parse(ctor.id):X8}] = typeof({CSharpName(ctor.predicate)}),");
							foreach (var typeInfo in methods)
								foreach (var ctor in typeInfo.Structs)
								{
									var generic = typeInfo.ReturnName.Length == 1 ? "<>" : "";
									sw.WriteLine($"\t\t\t[0x{int.Parse(ctor.id):X8}] = typeof(Fn.{CSharpName(ctor.predicate)}{generic}),");
								}
							while ((line = sr.ReadLine()) != null)
								if (line.StartsWith("\t\t\t// "))
									break;
							sw.WriteLine(line);
						}
					}
				}
				File.Replace(tableCs + ".new", tableCs, null);
			}
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
