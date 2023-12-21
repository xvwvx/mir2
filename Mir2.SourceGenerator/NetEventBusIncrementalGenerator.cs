using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
namespace Mir2.SourceGenerator;

[Generator(LanguageNames.CSharp)]
public class NetEventBusIncrementalGenerator : IIncrementalGenerator
{
    public static readonly string Namespace = "Mir2.Shared.Net";
    public static readonly string Parameter0FullName = "Arch.Core.World";
    public static readonly string Parameter1FullName = "Arch.Core.Entity";
    public static readonly string RouteAttributeFullName = $"{Namespace}.RouteAttribute";

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var syntaxProvider = context.SyntaxProvider.CreateSyntaxProvider<MethodDeclarationSyntax?>(static (s, _) =>
        {
            return s is MethodDeclarationSyntax { ParameterList.Parameters.Count: 1 or 3 };
        }, static (ctx, _) =>
        {
            var methodDeclarationSyntax = (MethodDeclarationSyntax)ctx.Node;
            var parameters = methodDeclarationSyntax.ParameterList.Parameters;
            // if (parameters.Count == 3)
            // {
            //     var typeInfo0 = ModelExtensions.GetTypeInfo(ctx.SemanticModel, parameters[0].Type!);
            //     var typeInfo1 = ModelExtensions.GetTypeInfo(ctx.SemanticModel, parameters[1].Type!);
            //     if (typeInfo0.Type!.ToDisplayString() != Parameter0FullName
            //         || typeInfo1.Type!.ToDisplayString() != Parameter1FullName)
            //     {
            //         return null;
            //     }
            // }

            var typeInfo2 = ModelExtensions.GetTypeInfo(ctx.SemanticModel, parameters.Last().Type!);
            var attributes = typeInfo2.Type!.GetAttributes();
            foreach (var attribute in attributes)
            {
                if (attribute.AttributeClass!.ToDisplayString() == RouteAttributeFullName)
                {
                    return methodDeclarationSyntax;
                }
            }
            return null;
        }).Where(m => m is not null);

        var valueProvider = context.CompilationProvider.Combine(syntaxProvider!.WithComparer(Comparer.Instance).Collect());
        context.RegisterSourceOutput(valueProvider, static (spc, source) => Generate(source.Item1, source.Item2!, spc));
    }

    private static void Generate(
        Compilation compilation,
        ImmutableArray<MethodDeclarationSyntax> methods,
        SourceProductionContext context
    )
    {
        if (methods.IsDefaultOrEmpty)
        {
            return;
        }

        var typeDict = new Dictionary<ITypeSymbol, List<IMethodSymbol>>(SymbolEqualityComparer.Default);
        foreach (var methodSyntax in methods)
        {
            var semanticModel = compilation.GetSemanticModel(methodSyntax.SyntaxTree);
            var methodSymbol = ModelExtensions.GetDeclaredSymbol(semanticModel, methodSyntax) as IMethodSymbol;
            
            if (!methodSymbol.Name.EndsWith("Net"))
            {
                continue;
            }
            
            var receiverType = methodSymbol!.ReceiverType!;
            if (!typeDict.TryGetValue(receiverType, out var list))
            {
                list = new();
                typeDict[receiverType] = list;
            }
            list.Add(methodSymbol);
        }

        foreach (var pair in typeDict)
        {
            var regSB = new StringBuilder();
            var unregSB = new StringBuilder();
            foreach (var methodSymbol in pair.Value)
            {
                // var receiverType = methodSymbol.ReceiverType;
                var methodName = methodSymbol.Name;
                var returnType = methodSymbol.ReturnType;
                var parameters = methodSymbol.Parameters;

                var requestType = parameters.Last().Type;

                var attributeData = requestType.GetAttributes()
                    .FirstOrDefault(data => data.AttributeClass?.ToString() == RouteAttributeFullName);
                if (attributeData == null)
                {
                    continue;
                }
                var members = attributeData.AttributeClass!.GetMembers();

                UInt16 routeId = 0;
                var constructorArguments = attributeData.ConstructorArguments;
                if (constructorArguments[0].Type.ToDisplayString() == "ushort")
                {
                    routeId = (UInt16)constructorArguments[0].Value!;
                }
                else
                {
                    var sysId = (UInt16)(byte)constructorArguments[0].Value!;
                    var msgId = (UInt16)(byte)constructorArguments[1].Value!;
                    // var hint = (string)constructorArguments[2].Value!;
                    routeId = (UInt16)(sysId << 8 | msgId);
                }

                var clsName = parameters.Length == 1
                    ? "NetEventBus.Shared"
                    : "EntityNetEventBus.Shared";

                var routeIdStr = $"0x{routeId:X}";
                if (returnType.ToDisplayString() != "void")
                {
                    regSB.Append($$"""
                                   {{clsName}}.Register<{{requestType}}, {{returnType}}>({{routeIdStr}}, this.{{methodName}});
                                   """);
                }
                else
                {
                    regSB.Append($$"""
                                   {{clsName}}.Register<{{requestType}}>({{routeIdStr}}, this.{{methodName}});
                                   """);
                }
                unregSB.Append($$"""
                                 {{clsName}}.Unregister({{routeIdStr}});
                                 """);
            }

            var typeBuilder = new StringBuilder();
            typeBuilder.Append($$"""
                                 public void RegisterNet()
                                 {
                                     {{regSB}}
                                 }
                                 """);

            typeBuilder.Append($$"""
                                 public void UnregisterNet()
                                 {
                                     {{unregSB}}
                                 }
                                 """);

            var fileBuilder = new StringBuilder($$"""
                                                  using Mir2.Shared.Net;
                                                  namespace {{pair.Key.ContainingNamespace.ToDisplayString()}};
                                                  public partial class {{pair.Key.Name}}
                                                  {
                                                      {{typeBuilder}}
                                                  }
                                                  """);
            var source = CSharpSyntaxTree
                .ParseText(fileBuilder.ToString())
                .GetRoot()
                .NormalizeWhitespace()
                .ToFullString();
            context.AddSource($"{pair.Key.Name}.Net.g.cs", source);
        }
    }
}

class Comparer : IEqualityComparer<MethodDeclarationSyntax>
{
    public static readonly Comparer Instance = new Comparer();

    public bool Equals(MethodDeclarationSyntax? x, MethodDeclarationSyntax? y)
    {
        return x?.Equals(y) ?? false;
    }

    public int GetHashCode(MethodDeclarationSyntax obj)
    {
        return obj.GetHashCode();
    }
}