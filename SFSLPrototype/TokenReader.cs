using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SFSLPrototype;

internal class TokenReader
{
    private readonly Stack<int> locations = new();
    private readonly Token[] tokens;

    public int Location
    {
        get => locations.Peek();
        set
        {
            locations.Pop(); 
            locations.Push(value);
        }
    }

    public Token Current => locations.Peek() < 0 ? null : tokens[locations.Peek()];

    public int CountRemaining => tokens.Length - (locations.Peek() + 1);

    public bool IsAtEnd => (locations.Peek() + 1) >= tokens.Length;

    public TokenReader(Token[] tokens)
    {
        this.tokens = tokens;
        locations.Push(-1);
    }

    public Token GetNext(int amount = 1)
    {
        return tokens[locations.Peek() + amount];
    }

    public Token MoveNext()
    {
        return TryMoveNext(out Token token) ? token : throw new Exception("There are no more tokens!"); 
    }

    public bool TryMoveNext(out Token token)
    {
        token = null;
        
        if (IsAtEnd)
            return false;

        locations.Push(locations.Pop() + 1);

        token = tokens[locations.Peek()];
        return true;
    }

    public void PushLocation()
    {
        locations.Push(locations.Peek());
    }

    public int PopLocation()
    {
        return locations.Pop();
    }

    public TokenReader Subsection(int length)
    {
        return new TokenReader(tokens[Location..(Location + length)]);
    }
}
