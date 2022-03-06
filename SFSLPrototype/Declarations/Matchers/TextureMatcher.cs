using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSLPrototype.Declarations.Matchers;

internal class TextureMatcher : IDeclarationMatcher
{
    public Declaration Build(MatchingContext context, TokenReader keptTokens)
    {
        return new TextureDeclaration(keptTokens.MoveNext());
    }

    public IEnumerable<bool> Match(MatchingContext context, TokenReader reader, ScopeContext scope)
    {
        yield return reader.MoveNext().ExpectValues("texture");
        yield return reader.MoveNext().ExpectIdentifier();
        context.KeepToken(reader.Current);
        yield return reader.MoveNext().ExpectValues(";");
    }
}
