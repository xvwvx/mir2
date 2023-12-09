using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
namespace Mir2.SourceGenerator;

[Generator(LanguageNames.CSharp)]
public class FormatterGenerator : IIncrementalGenerator
{

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var syntaxProvider = context.SyntaxProvider.CreateSyntaxProvider<TypeDeclarationSyntax?>(static (s, _) =>
        {
            return s is TypeDeclarationSyntax;
        }, static (ctx, _) =>
        {
            var typeDeclarationSyntax = (TypeDeclarationSyntax)ctx.Node;
            var attributeLists = typeDeclarationSyntax.AttributeLists;
            if (attributeLists.FindAttributeSyntax("MessagePackObject") != null)
            {
                return typeDeclarationSyntax;
            }
            return null;
        }).Where(m => m is not null);

        var valueProvider = context.CompilationProvider.Combine(syntaxProvider.Collect());
        context.RegisterSourceOutput(valueProvider, (spc, source) => Generate(source.Item1, source.Item2!, spc));
    }

    private void Generate(
        Compilation compilation,
        ImmutableArray<TypeDeclarationSyntax> typeDeclarationSyntaxes,
        SourceProductionContext context
    )
    {
        void GetFileds(SortedDictionary<int, FieldDeclarationSyntax> dict, TypeDeclarationSyntax typeDeclarationSyntax)
        {
            var members = typeDeclarationSyntax.Members;
            foreach (var memberDeclarationSyntax in members)
            {
                var attributeLists = memberDeclarationSyntax.AttributeLists;
                if (attributeLists.FindAttributeSyntax("Key") is { } attributeSyntax)
                {
                    var arguments = attributeSyntax.ArgumentList.Arguments;
                    var argument = arguments[0];

                    var key = int.Parse(argument.ToString());
                    if (memberDeclarationSyntax is PropertyDeclarationSyntax property)
                    {

                    }
                    else if (memberDeclarationSyntax is FieldDeclarationSyntax field)
                    {
                        dict[key] = field;
                    }
                }
            }
        }

        var symbolMap = new Dictionary<INamedTypeSymbol, TypeDeclarationSyntax>();
        foreach (var typeDeclarationSyntax in compilation.GetAllTypeDeclarationSyntaxes())
        {
            var symbol = (INamedTypeSymbol)typeDeclarationSyntax.GetDeclaredSymbol(compilation);
            symbolMap[symbol] = typeDeclarationSyntax;
        }

        var nameList = new List<string>();
        foreach (var typeDeclarationSyntax in typeDeclarationSyntaxes)
        {
            if (typeDeclarationSyntax.GetDeclaredSymbol(compilation) is { IsAbstract: true })
            {
                continue;
            }
            
            var dict = new SortedDictionary<int, FieldDeclarationSyntax>();
            var iter = typeDeclarationSyntax;
            while (true)
            {
                GetFileds(dict, iter);
                if ((INamedTypeSymbol?)iter.GetDeclaredSymbol(compilation) is { } symbol)
                {
                    if (symbol.BaseType.ToDisplayString() != "object")
                    {
                        iter = symbolMap[symbol.BaseType];
                        continue;
                    }
                }
                break;
            }

            var name = GenerateFormater(compilation, typeDeclarationSyntax, dict);
            nameList.Add(name);
        }

        var mapSB = new StringBuilder();
        var switchSB = new StringBuilder();
        for (int i = 0; i < nameList.Count; i++)
        {
            var name = nameList[i];
            mapSB.AppendLine($$"""[typeof({{name}})] = {{i}},""");
            switchSB.AppendLine($$"""case {{i}}: return new {{name}}Formatter();""");
        }

        var str = $$"""
                    using System.Buffers;
                    using MessagePack;
                    using MessagePack.Formatters;
                    using System.Collections.Generic;

                    namespace MessagePack.Resolvers {
                        public class GeneratedResolver : global::MessagePack.IFormatterResolver
                        {
                            public static readonly global::MessagePack.IFormatterResolver Instance = new GeneratedResolver();
                        
                            private GeneratedResolver()
                            {
                            }
                        
                            public global::MessagePack.Formatters.IMessagePackFormatter<T> GetFormatter<T>()
                            {
                                return FormatterCache<T>.Formatter;
                            }
                        
                            private static class FormatterCache<T>
                            {
                                internal static readonly global::MessagePack.Formatters.IMessagePackFormatter<T> Formatter;
                        
                                static FormatterCache()
                                {
                                    var f = GeneratedResolverGetFormatterHelper.GetFormatter(typeof(T));
                                    if (f != null)
                                    {
                                        Formatter = (global::MessagePack.Formatters.IMessagePackFormatter<T>)f;
                                    }
                                }
                            }
                        }
                        
                        internal static class GeneratedResolverGetFormatterHelper
                        {
                            private static readonly System.Collections.Generic.Dictionary<global::System.Type, int> lookup;
                        
                            static GeneratedResolverGetFormatterHelper()
                            {
                                lookup = new System.Collections.Generic.Dictionary<global::System.Type, int>(14)
                                    {{{mapSB}}};
                            }
                        
                            internal static object GetFormatter(global::System.Type t)
                            {
                                int key;
                                if (!lookup.TryGetValue(t, out key))
                                {
                                    return null;
                                }
                        
                                switch (key)
                                {
                                    {{switchSB}}
                                    default: return null;
                                }
                            }
                        }
                    }

                    {{_allSource}}
                    """;

        var source = CSharpSyntaxTree
            .ParseText(str)
            .GetRoot()
            .NormalizeWhitespace()
            .ToFullString();
        context.AddSource($"MessagePack.g.cs", source);

        _allSource.Clear();
    }

    private readonly StringBuilder _allSource = new StringBuilder();

    private string GenerateFormater(
        Compilation compilation,
        TypeDeclarationSyntax typeDeclarationSyntax,
        SortedDictionary<int, FieldDeclarationSyntax> dict
    )
    {

        var symbol = (INamedTypeSymbol)typeDeclarationSyntax.GetDeclaredSymbol(compilation);
        var clsName = symbol.ToDisplayString();

        var serializeSB = new StringBuilder();
        var deserializeSB = new StringBuilder();

        var max = dict.Keys.Count > 0 ? dict.Keys.Max() : -1;
        serializeSB.AppendLine($"writer.WriteArrayHeader({max + 1});");
        deserializeSB.AppendLine($"var count = reader.ReadArrayHeader();");
        for (int i = 0; i <= max; i++)
        {
            if (!dict.TryGetValue(i, out var field))
            {
                serializeSB.AppendLine($"writer.WriteNil();");
                deserializeSB.AppendLine($"reader.ReadNil();");
                continue;
            }

            var name = field.Declaration.Variables.First().Identifier.ValueText;

            var typeSyntax = field.Declaration.Type;

            var typeInfo = typeSyntax.GetTypeInfo(compilation);
            var type = typeInfo.Type;

            var typeName = type.ToDisplayString();
            if (typeName.StartsWith("System.Collections.Generic."))
            {
                typeName = typeName.Replace("System.Collections.Generic.", "");
            }

            if (type.TypeKind == TypeKind.Enum)
            {
                serializeSB.AppendLine($"writer.Write((uint)value.{name});");
                deserializeSB.AppendLine($"value.{name} = ({typeName})reader.ReadUInt32();");
            }
            else if (type.SpecialType is >= SpecialType.System_Boolean and <= SpecialType.System_String or SpecialType.System_DateTime)
            {
                var array = type.SpecialType.ToString().Split('_');
                var key = array.Last();
                serializeSB.AppendLine($"writer.Write(value.{name});");
                deserializeSB.AppendLine($"value.{name} = reader.Read{key}();");
            }
            else
            {
                serializeSB.AppendLine($$"""
                                         {
                                            var formatter = options.Resolver.GetFormatterWithVerify<{{typeName}}>();
                                            formatter.Serialize(ref writer, value.{{name}}, options);
                                         }
                                         """);
                deserializeSB.AppendLine($$"""
                                           {
                                              var formatter = options.Resolver.GetFormatterWithVerify<{{typeName}}>();
                                              value.{{name}} = formatter.Deserialize(ref reader, options);
                                           }
                                           """);
            }
        }

        var @namespace = "";
        if (symbol.ContainingNamespace.Name != string.Empty)
        {
            @namespace = symbol.ContainingNamespace.ToDisplayString();
        }

        var str = $$"""
                    public sealed class {{symbol.Name}}Formatter : IMessagePackFormatter<{{symbol.Name}}>
                    {
                        public void Serialize(ref MessagePackWriter writer, {{symbol.Name}} value, MessagePackSerializerOptions options)
                        {
                            if (value is null)
                            {
                                writer.WriteNil();
                                return;
                            }
                            {{serializeSB}}
                        }
                    
                        public {{symbol.Name}} Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
                        {
                            if (reader.TryReadNil())
                            {
                                return null;
                            }
                            options.Security.DepthStep(ref reader);
                            var value = new {{symbol.Name}}();
                            {{deserializeSB}}
                            reader.Depth--;
                            return value;
                        }
                    }
                    """;

        if (@namespace != string.Empty)
        {
            str = $$"""
                    namespace {{@namespace}}
                    {
                        {{str}}
                    }
                    """;
        }

        _allSource.AppendLine(str);
        return clsName;
    }

}