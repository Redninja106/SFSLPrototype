using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SFSLPrototype.Expressions;

internal class ExpressionParser
{
    public bool ParseExpressionBody(TokenReader reader, out BlockExpression expression)
    {
        // um i got no clue whats goin on here
        var src = @"(a+b)";
        reader = new TokenReader(Token.Tokenize(src));

        Stack<Expression> expressions = new();

        while (!reader.IsAtEnd)
        {
            reader.MoveNext();

            if (!(reader.Current.ExpectIdentifier() || reader.Current.ExpectValues("--", "++")))
                throw new Exception();
            
            // increment, decrement
            if ((reader.Current.ExpectValues("--", "++") && reader.Current.ExpectIdentifier()) || (reader.Current.ExpectIdentifier() && reader.GetNext().ExpectValues("--", "++")))
            {
                throw new NotImplementedException("increment and decrement as statements not implemented!");
            }

            // variable declaration
            if (reader.GetNext().ExpectIdentifier())
            {
                var name = reader.MoveNext();
            
                //expressions.Push(Expression.Variable());
            }

            // method call
            
            // assignment

        }

        expression = null;
        return false;
    }
}
