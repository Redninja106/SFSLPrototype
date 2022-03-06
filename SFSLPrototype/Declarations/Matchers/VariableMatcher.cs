using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSLPrototype.Declarations.Matchers;

internal class VariableMatcher : IDeclarationMatcher
{
    public Declaration Build(MatchingContext context, TokenReader keptTokens)
    {
        VariableModifier modifier = VariableModifier.None;

        if (keptTokens.MoveNext().Value == "in")
        {
            modifier = VariableModifier.In;
            keptTokens.MoveNext();
        }
        else if (keptTokens.Current.Value == "out")
        {
            modifier = VariableModifier.Out;
            keptTokens.MoveNext();
        }

        var type = keptTokens.Current;
        var name = keptTokens.MoveNext();

        return new VariableDeclaration(name, type, modifier);
    }

    public IEnumerable<bool> Match(MatchingContext context, TokenReader reader, ScopeContext scope)
    {
        yield return reader.MoveNext().ExpectIdentifier() || reader.Current.ExpectKeyword();
        context.KeepToken(reader.Current);

        if (reader.Current.Value == "in" || reader.Current.Value == "out")
        {
            yield return reader.MoveNext().ExpectIdentifier();
            context.KeepToken(reader.Current);
        }

        yield return reader.MoveNext().ExpectIdentifier();
        context.KeepToken(reader.Current);
        yield return reader.MoveNext().ExpectValues(";");
    }
}
