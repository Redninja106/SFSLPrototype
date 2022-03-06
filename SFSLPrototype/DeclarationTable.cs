using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFSLPrototype.Declarations;
using SFSLPrototype.Declarations.Matchers;
using SFSLPrototype.Emit;

namespace SFSLPrototype;

internal class DeclarationTable
{
    public IReadOnlyList<Declaration> Declarations => declarations;

    private readonly List<Declaration> declarations = new();
    private readonly List<IDeclarationMatcher> matchers = new();

    public DeclarationTable()
    {
    }

    public void RegisterMatcher(IDeclarationMatcher matcher)
    {
        if (!this.matchers.Contains(matcher))
            this.matchers.Add(matcher);
    }

    public void Build(Token[] tokens)
    {
        var reader = new TokenReader(tokens);
        var scopeContext = new ScopeContext();

        MatchingContext context = new();
        bool matched = false;

        while (!reader.IsAtEnd)
        {
            foreach (var matcher in matchers)
            {
                context.ClearKeptTokens();
                reader.PushLocation();
                if (matcher.Match(context, reader, scopeContext).All(e => e))
                {
                    matched = true;
                    var declaration = matcher.Build(context, new TokenReader(context.GetKeptTokens()));
                    reader.Location = reader.PopLocation();
                    if (declaration is not null) 
                    {
                        declarations.Add(declaration);
                        declaration.SetAttributes(context.FlushAttributes());
                        break;
                    }
                }
                else
                {
                    reader.PopLocation();
                }
            }

            if (!matched)
            {
                throw new Exception("Unrecognized symbol: " + reader.Current.Value);
                //reader.MoveNext();
            }
            else 
            {
                matched = false;
            }
        }
    }

    public void Accept(IEmitter emitter)
    {

    }
}
