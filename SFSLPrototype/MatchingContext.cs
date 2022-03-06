using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFSLPrototype.Declarations;

namespace SFSLPrototype;

internal class MatchingContext
{
    private readonly List<Token> keptTokens = new();
    private readonly List<AttributeDeclaration> attributes = new();

    public void KeepToken(Token token)
    {
        keptTokens.Add(token);
    }

    public void AddAttribute(AttributeDeclaration attribute)
    {
        this.attributes.Add(attribute);
    }

    public Token[] GetKeptTokens()
    {
        return keptTokens.ToArray();
    }

    internal void ClearKeptTokens()
    {
        keptTokens.Clear();
    }

    internal AttributeDeclaration[] FlushAttributes()
    {
        var result = attributes.ToArray();
        attributes.Clear();
        return result;
    }
}
