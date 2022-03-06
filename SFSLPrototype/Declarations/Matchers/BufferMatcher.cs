using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSLPrototype.Declarations.Matchers;

internal class BufferMatcher : IDeclarationMatcher
{
    public Declaration Build(MatchingContext context, TokenReader keptTokens)
    {
        var type = keptTokens.MoveNext();
        var name = keptTokens.MoveNext();
        return new BufferDeclaration(name, type);
    }

    public IEnumerable<bool> Match(MatchingContext context, TokenReader reader, ScopeContext scope)
    {
        yield return scope.ExpectGlobal();
        yield return reader.MoveNext().ExpectValues("buffer");
        yield return reader.MoveNext().ExpectValues("<");
        yield return reader.MoveNext().ExpectIdentifier();
        context.KeepToken(reader.Current);
        yield return reader.MoveNext().ExpectValues(">");
        yield return reader.MoveNext().ExpectIdentifier();
        context.KeepToken(reader.Current);
        yield return reader.MoveNext().ExpectValues(";");
    }
}
