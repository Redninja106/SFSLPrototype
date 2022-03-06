using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSLPrototype.Declarations.Matchers;

internal class StructMatcher : IDeclarationMatcher
{
    public Declaration Build(MatchingContext context, TokenReader keptTokens)
    {
        var name = keptTokens.MoveNext();
        var members = new StructMember[keptTokens.CountRemaining / 2];

        for (int i = 0; i < members.Length; i++)
        {
            var memberType = keptTokens.MoveNext();
            var memberName = keptTokens.MoveNext();
            members[i] = new(memberName, memberType);
        }

        return new StructDeclaration(name, members);
    }

    public IEnumerable<bool> Match(MatchingContext context, TokenReader reader, ScopeContext scope)
    {
        yield return scope.ExpectGlobal();
        yield return reader.MoveNext().ExpectValues("struct");
        yield return reader.MoveNext().ExpectIdentifier();
        context.KeepToken(reader.Current);
        yield return reader.MoveNext().ExpectValues("{");

        while (reader.GetNext().Value != "}")
        {
            yield return reader.MoveNext().ExpectIdentifier();
            context.KeepToken(reader.Current);
            yield return reader.MoveNext().ExpectIdentifier();
            context.KeepToken(reader.Current);
            yield return reader.MoveNext().ExpectValues(";");
        }

        yield return reader.MoveNext().ExpectValues("}");
    }
}
