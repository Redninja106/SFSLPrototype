using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFSLPrototype.Declarations;
using SFSLPrototype.Expressions;

namespace SFSLPrototype.Declarations.Matchers;

internal class FunctionMatcher : IDeclarationMatcher
{
    private static readonly ExpressionParser expressionParser = new();

    public Declaration Build(MatchingContext context, TokenReader keptTokens)
    {
        var type = keptTokens.MoveNext();
        var name = keptTokens.MoveNext();
        var parameters = new FunctionParameter[keptTokens.CountRemaining / 2];

        for (int i = 0; i < parameters.Length; i++)
        {
            parameters[i] = new(keptTokens.MoveNext(), keptTokens.MoveNext());
        }

        return new FunctionDeclaration(name, type, parameters, null);
    }

    public IEnumerable<bool> Match(MatchingContext context, TokenReader reader, ScopeContext scope)
    {
        // return type
        yield return reader.MoveNext().ExpectType();
        context.KeepToken(reader.Current);
        // name
        yield return reader.MoveNext().ExpectIdentifier();
        context.KeepToken(reader.Current);
        // open paren/double paren
        yield return reader.MoveNext().ExpectValues("(", "()");
        if (reader.Current.Value == "(")
        {
            while (reader.Current.Value != ")")
            {
                yield return reader.MoveNext().ExpectType();
                context.KeepToken(reader.Current);
                yield return reader.MoveNext().ExpectIdentifier();
                context.KeepToken(reader.Current);
                yield return reader.MoveNext().ExpectValues(",", ")");
            }
        }
        yield return reader.MoveNext().ExpectValues("{");

        int depth = 1;
        while (depth != 0)
        {
            reader.MoveNext();
            context.KeepToken(reader.Current);
            if (reader.Current.Value == "{") depth++;
            if (reader.Current.Value == "}") depth--;
        }
    }
}
