using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

static class Extensions
{
    public static IReadOnlyList<AttributeData> GetAttributes(this AttributeListSyntax attributes, Compilation compilation)
    {
        // Collect pertinent syntax trees from these attributes
        var acceptedTrees = new HashSet<SyntaxTree>();
        foreach (var attribute in attributes.Attributes)
            acceptedTrees.Add(attribute.SyntaxTree);

        var parentSymbol = attributes.Parent!.GetDeclaredSymbol(compilation)!;
        var parentAttributes = parentSymbol.GetAttributes();
        var ret = new List<AttributeData>();
        foreach (var attribute in parentAttributes)
        {
            if (acceptedTrees.Contains(attribute.ApplicationSyntaxReference!.SyntaxTree))
                ret.Add(attribute);
        }

        return ret;
    }

    public static ISymbol? GetDeclaredSymbol(this SyntaxNode node, Compilation compilation)
    {
        var model = compilation.GetSemanticModel(node.SyntaxTree);
        return model.GetDeclaredSymbol(node);
    }

    public static TypeInfo GetTypeInfo(this SyntaxNode node, Compilation compilation)
    {
        var model = compilation.GetSemanticModel(node.SyntaxTree);
        return model.GetTypeInfo(node);
    }

    public static AttributeSyntax? FindAttributeSyntax(this SyntaxList<AttributeListSyntax> attributeListSyntaxes, string name)
    {
        foreach (var attributeList in attributeListSyntaxes)
        {
            foreach (var attribute in attributeList.Attributes)
            {
                if (attribute.Name.NormalizeWhitespace().ToFullString() == name)
                {
                    return attribute;
                }
            }
        }
        return null;
    }

    public static bool TryGetParentSyntax<T>(this SyntaxNode syntaxNode, out T result)
        where T : SyntaxNode
    {
        // set defaults
        result = null;

        if (syntaxNode == null)
        {
            return false;
        }

        try
        {
            syntaxNode = syntaxNode.Parent;

            if (syntaxNode == null)
            {
                return false;
            }

            if (syntaxNode.GetType() == typeof(T))
            {
                result = syntaxNode as T;
                return true;
            }

            return TryGetParentSyntax<T>(syntaxNode, out result);
        }
        catch
        {
            return false;
        }
    }
    
    public static IEnumerable<TypeDeclarationSyntax> GetAllTypeDeclarationSyntaxes(this Compilation compilation)
    {
        foreach (var tree in compilation.SyntaxTrees)
        {
            foreach (var type in tree.GetRoot().DescendantNodes()
                         .OfType<TypeDeclarationSyntax>())
            {
                yield return type;
            }
        }
    }
    
}