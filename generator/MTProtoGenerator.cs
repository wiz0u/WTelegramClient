using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

#pragma warning disable RS1024 // Symbols should be compared for equality

namespace TL.Generator;

[Generator]
public class MTProtoGenerator : IIncrementalGenerator
{
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		var classDeclarations = context.SyntaxProvider.ForAttributeWithMetadataName("TL.TLDefAttribute",
			(_, _) => true, (context, _) => (ClassDeclarationSyntax)context.TargetNode);
		var source = context.CompilationProvider.Combine(classDeclarations.Collect());
		context.RegisterSourceOutput(source, Execute);
	}

	static void Execute(SourceProductionContext context, (Compilation compilation, ImmutableArray<ClassDeclarationSyntax> classes) unit)
	{
		var object_ = unit.compilation.GetSpecialType(SpecialType.System_Object);
		if (unit.compilation.GetTypeByMetadataName("TL.TLDefAttribute") is not { } tlDefAttribute) return;
		if (unit.compilation.GetTypeByMetadataName("TL.IfFlagAttribute") is not { } ifFlagAttribute) return;
		if (unit.compilation.GetTypeByMetadataName("TL.Layer") is not { } layer) return;
		if (unit.compilation.GetTypeByMetadataName("TL.IObject") is not { } iobject) return;
		var nullables = LoadNullables(layer);
		var namespaces = new Dictionary<string, Dictionary<string, string>>(); // namespace,class,methods
		var tableTL = new StringBuilder();
		var methodsTL = new StringBuilder();
		var source = new StringBuilder();
		source
			.AppendLine("using System;")
			.AppendLine("using System.Collections.Generic;")
			.AppendLine("using System.ComponentModel;")
			.AppendLine("using System.IO;")
			.AppendLine("using System.Linq;")
			.AppendLine("using TL;")
			.AppendLine()
			.AppendLine("#pragma warning disable CS0109")
			.AppendLine();
		tableTL
			.AppendLine("\t\tpublic static readonly Dictionary<uint, Func<BinaryReader, IObject>> Table = new()")
			.AppendLine("\t\t{");
		methodsTL
			.AppendLine("\t\tpublic static readonly Dictionary<uint, Func<BinaryReader, IObject>> Methods = new()")
			.AppendLine("\t\t{");

		foreach (var classDecl in unit.classes)
		{
			var semanticModel = unit.compilation.GetSemanticModel(classDecl.SyntaxTree);
			if (semanticModel.GetDeclaredSymbol(classDecl) is not { } symbol) continue;
			var tldef = symbol.GetAttributes().FirstOrDefault(a => a.AttributeClass == tlDefAttribute);
			if (tldef == null) continue;
			var id = (uint)tldef.ConstructorArguments[0].Value;
			StringBuilder writeTl = new(), readTL = new();
			var ns = symbol.BaseType.ContainingNamespace.ToString();
			var name = symbol.BaseType.Name;
			if (ns != "System")
			{
				if (!namespaces.TryGetValue(ns, out var parentClasses)) namespaces[ns] = parentClasses = [];
				parentClasses.TryGetValue(name, out var parentMethods);
				if (symbol.BaseType.IsAbstract)
				{
					if (parentMethods == null)
					{
						if (name is "Peer")
							writeTl.AppendLine("\t\tpublic virtual void WriteTL(BinaryWriter writer) => throw new NotSupportedException();");
						else
							writeTl.AppendLine("\t\tpublic abstract void WriteTL(BinaryWriter writer);");
						parentClasses[name] = writeTl.ToString();
						writeTl.Clear();
					}
				}
				else if (parentMethods?.Contains(" virtual ") == false)
					parentClasses[name] = parentMethods.Replace("public void WriteTL(", "public virtual void WriteTL(");
			}
			ns = symbol.ContainingNamespace.ToString();
			name = symbol.Name;
			if (!namespaces.TryGetValue(ns, out var classes)) namespaces[ns] = classes = [];
			if (name is "_Message" or "MsgCopy")
			{
				classes[name] = "\t\tpublic void WriteTL(BinaryWriter writer) => throw new NotSupportedException();";
				continue;
			}
			if (id == 0x3072CFA1) // GzipPacked
				tableTL.AppendLine($"\t\t\t[0x{id:X8}] = reader => (IObject)reader.ReadTLGzipped(typeof(IObject)),");
			else if (name != "Null")
			{ 
				if (ns == "TL.Methods")
					methodsTL.AppendLine($"\t\t\t[0x{id:X8}] = {(ns == "TL" ? "" : ns + '.')}{name}{(symbol.IsGenericType ? "<object>" : "")}.ReadTL,");
				if (ns != "TL.Methods" || name == "Ping")
					tableTL.AppendLine($"\t\t\t[0x{id:X8}] = {(ns == "TL" ? "" : ns + '.')}{name}.ReadTL,");
			}
			var override_ = symbol.BaseType == object_ ? "" : "override ";
			if (name == "Messages_AffectedMessages") override_ = "virtual ";
			//if (symbol.Constructors[0].IsImplicitlyDeclared)
			//	ctorTL.AppendLine($"\t\tpublic {name}() {{ }}");
			if (symbol.IsGenericType) name += "<X>";
			readTL
				.AppendLine($"\t\tpublic static new {name} ReadTL(BinaryReader reader)")
				.AppendLine("\t\t{")
				.AppendLine($"\t\t\tvar r = new {name}();");
			writeTl
				.AppendLine("\t\t[EditorBrowsable(EditorBrowsableState.Never)]")
				.AppendLine($"\t\tpublic {override_}void WriteTL(BinaryWriter writer)")
				.AppendLine("\t\t{")
				.AppendLine($"\t\t\twriter.Write(0x{id:X8});");
			var members = symbol.GetMembers().ToList();
			for (var parent = symbol.BaseType; parent != object_; parent = parent.BaseType)
			{
				var inheritBefore = (bool?)tldef.NamedArguments.FirstOrDefault(k => k.Key == "inheritBefore").Value.Value ?? false;
				if (inheritBefore) members.InsertRange(0, parent.GetMembers());
				else members.AddRange(parent.GetMembers());
				tldef = parent.GetAttributes().FirstOrDefault(a => a.AttributeClass == tlDefAttribute);
			}
			foreach (var member in members.OfType<IFieldSymbol>())
			{
				if (member.DeclaredAccessibility != Accessibility.Public || member.IsStatic) continue;
				readTL.Append("\t\t\t");
				writeTl.Append("\t\t\t");
				var ifFlag = (int?)member.GetAttributes().FirstOrDefault(a => a.AttributeClass == ifFlagAttribute)?.ConstructorArguments[0].Value;
				if (ifFlag != null)
				{
					readTL.Append(ifFlag < 32 ? $"if (((uint)r.flags & 0x{1 << ifFlag:X}) != 0) "
											: $"if (((uint)r.flags2 & 0x{1 << (ifFlag - 32):X}) != 0) ");
					writeTl.Append(ifFlag < 32 ? $"if (((uint)flags & 0x{1 << ifFlag:X}) != 0) "
											: $"if (((uint)flags2 & 0x{1 << (ifFlag - 32):X}) != 0) ");
				}
				string memberType = member.Type.ToString();
				switch (memberType)
				{
					case "int":
						readTL.AppendLine($"r.{member.Name} = reader.ReadInt32();");
						writeTl.AppendLine($"writer.Write({member.Name});");
						break;
					case "long":
						readTL.AppendLine($"r.{member.Name} = reader.ReadInt64();");
						writeTl.AppendLine($"writer.Write({member.Name});");
						break;
					case "double":
						readTL.AppendLine($"r.{member.Name} = reader.ReadDouble();");
						writeTl.AppendLine($"writer.Write({member.Name});");
						break;
					case "bool":
						readTL.AppendLine($"r.{member.Name} = reader.ReadTLBool();");
						writeTl.AppendLine($"writer.Write({member.Name} ? 0x997275B5 : 0xBC799737);");
						break;
					case "System.DateTime":
						readTL.AppendLine($"r.{member.Name} = reader.ReadTLStamp();");
						writeTl.AppendLine($"writer.WriteTLStamp({member.Name});");
						break;
					case "string":
						readTL.AppendLine($"r.{member.Name} = reader.ReadTLString();"); 
						writeTl.AppendLine($"writer.WriteTLString({member.Name});");
						break;
					case "byte[]": 
						readTL.AppendLine($"r.{member.Name} = reader.ReadTLBytes();"); 
						writeTl.AppendLine($"writer.WriteTLBytes({member.Name});"); 
						break;
					case "TL.Int128":
						readTL.AppendLine($"r.{member.Name} = new Int128(reader);");
						writeTl.AppendLine($"writer.Write({member.Name});");
						break;
					case "TL.Int256":
						readTL.AppendLine($"r.{member.Name} = new Int256(reader);");
						writeTl.AppendLine($"writer.Write({member.Name});");
						break;
					case "System.Collections.Generic.List<TL._Message>":
						readTL.AppendLine($"r.{member.Name} = reader.ReadTLRawVector<_Message>(0x5BB8E511);");
						writeTl.AppendLine($"writer.WriteTLMessages({member.Name});"); 
						break;
					case "TL.IObject": case "TL.IMethod<X>":
						readTL.AppendLine($"r.{member.Name} = {(memberType == "TL.IObject" ? "reader.ReadTLObject()" : "reader.ReadTLMethod<X>()")};");
						writeTl.AppendLine($"{member.Name}.WriteTL(writer);"); 
						break;
					case "System.Collections.Generic.Dictionary<long, TL.User>":
						readTL.AppendLine($"r.{member.Name} = reader.ReadTLDictionary<User>();");
						writeTl.AppendLine($"writer.WriteTLVector({member.Name}?.Values.ToArray());"); 
						break;
					case "System.Collections.Generic.Dictionary<long, TL.ChatBase>":
						readTL.AppendLine($"r.{member.Name} = reader.ReadTLDictionary<ChatBase>();");
						writeTl.AppendLine($"writer.WriteTLVector({member.Name}?.Values.ToArray());");
						break;
					case "object":
						readTL.AppendLine($"r.{member.Name} = reader.ReadTLObject();");
						writeTl.AppendLine($"writer.WriteTLValue({member.Name}, {member.Name}.GetType());");
						break;
					default:
						if (member.Type is IArrayTypeSymbol arrayType)
						{
							if (name is "FutureSalts")
							{
								readTL.AppendLine($"r.{member.Name} = reader.ReadTLRawVector<{memberType.Substring(0, memberType.Length - 2)}>(0x0949D9DC).ToArray();");
								writeTl.AppendLine($"writer.WriteTLRawVector({member.Name}, 16);");
							}
							else
							{
								readTL.AppendLine($"r.{member.Name} = reader.ReadTLVector<{memberType.Substring(0, memberType.Length - 2)}>();");
								writeTl.AppendLine($"writer.WriteTLVector({member.Name});");
							}
						}
						else if (member.Type.BaseType.SpecialType == SpecialType.System_Enum)
						{
							readTL.AppendLine($"r.{member.Name} = ({memberType})reader.ReadUInt32();");
							writeTl.AppendLine($"writer.Write((uint){member.Name});");
						}
						else if (memberType.StartsWith("TL."))
						{
							readTL.AppendLine($"r.{member.Name} = ({memberType})reader.ReadTLObject();");
							var nullStr = nullables.TryGetValue(memberType, out uint nullCtor) ? $"0x{nullCtor:X8}" : "Layer.NullCtor";
							writeTl.AppendLine($"if ({member.Name} != null) {member.Name}.WriteTL(writer); else writer.Write({nullStr});");
						}
						else
							writeTl.AppendLine($"Cannot serialize {memberType}");
						break;
				}
			}
			readTL.AppendLine("\t\t\treturn r;");
			readTL.AppendLine("\t\t}");
			writeTl.AppendLine("\t\t}");
			readTL.Append(writeTl.ToString());
			classes[name] = readTL.ToString();
		}

		foreach (var nullable in nullables)
			tableTL.AppendLine($"\t\t\t[0x{nullable.Value:X8}] = null,");
		tableTL.AppendLine("\t\t};");
		methodsTL.AppendLine("\t\t};");
		namespaces["TL"]["Layer"] = tableTL.ToString() + methodsTL.ToString();
		foreach (var namesp in namespaces)
		{
			source.Append("namespace ").AppendLine(namesp.Key).Append('{');
			foreach (var method in namesp.Value)
				source.AppendLine().Append("\tpartial class ").AppendLine(method.Key).AppendLine("\t{").Append(method.Value).AppendLine("\t}");
			source.AppendLine("}").AppendLine();
		}
		string text = source.ToString();
		Debug.Write(text);
		context.AddSource("TL.Generated.cs", text);
	}

	private static Dictionary<string, uint> LoadNullables(INamedTypeSymbol layer)
	{
		var nullables = layer.GetMembers("Nullables").Single() as IFieldSymbol;
		var initializer = nullables.DeclaringSyntaxReferences[0].GetSyntax().ToString();
		var table = new Dictionary<string, uint>();
		foreach (var line in initializer.Split('\n'))
		{
			int index = line.IndexOf("[typeof(");
			if (index == -1) continue;
			int index2 = line.IndexOf(')', index += 8);
			string className = "TL." + line.Substring(index, index2 - index);
			index = line.IndexOf("= 0x", index2);
			if (index == -1) continue;
			index2 = line.IndexOf(',', index += 4);
			table[className] = uint.Parse(line.Substring(index, index2 - index), System.Globalization.NumberStyles.HexNumber);
		}
		return table;
	}
}
