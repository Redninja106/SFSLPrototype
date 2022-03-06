using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSLPrototype.Declarations.Matchers;

internal class AttributeMatcher : IDeclarationMatcher
{
    public Declaration Build(MatchingContext context, TokenReader keptTokens)
    {
        context.AddAttribute(new(keptTokens.MoveNext()));
        return null;
    }

    IEnumerable<bool> IDeclarationMatcher.Match(MatchingContext context, TokenReader reader, ScopeContext scope)
    {
        yield return scope.ExpectGlobal();
        yield return reader.MoveNext().ExpectValues("[");
        yield return reader.MoveNext().ExpectIdentifier();
        context.KeepToken(reader.Current);
        yield return reader.MoveNext().ExpectValues("]");
    }
}
