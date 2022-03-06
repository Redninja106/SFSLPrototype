using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSLPrototype;

public class Token
{
    public string Value { get; private set; }
    public int EndIndex { get; private set; }
    
    public int StartIndex => EndIndex - Value.Length;
    public int Length => Value.Length;

    public Token(string value, int endIndex)
    {
        this.Value = value;
        this.EndIndex = endIndex;
    }

    public bool ExpectValues(params string[] values)
    {
        return values.Any(v => v == Value);
    }

    public bool ExpectIdentifier()
    {
        return !ExpectKeyword() && Value.All(c => IsIdentifierPart(c)) && !char.IsDigit(Value[0]);
    }

    public bool ExpectKeyword()
    {
        return LanguageInfo.Keywords.Any(s => s == Value);
    }

    public bool ExpectType()
    {
        return ExpectIdentifier() || ExpectValues("void");
    }

    private bool IsIdentifierPart(char c)
    {
        return c == '_' || char.IsLetter(c) || char.IsDigit(c);
    }

    public override string ToString()
    {
        return Value;
    }


    public static Token[] Tokenize(string src)
    {
        bool IsPunctuation(string s, int i)
        {
            return char.IsPunctuation(s, i) || s[i] == '>' || s[i] == '<';
        }

        List<Token> result = new();

        string token = "";
        for (int i = 0; i < src.Length; i++)
        {
            if (char.IsWhiteSpace(src[i]))
                continue;

            token += src[i];

            if (token == "//")
            {
                while (src[i] != '\n') i++;
                token = "";
                continue;
            }

            if (i >= src.Length - 1 || char.IsWhiteSpace(src[i + 1]) || (IsPunctuation(token, 0) != IsPunctuation(src, i + 1)))
            {
                result.Add(new(token, i));
                token = "";
            }
        }

        return result.ToArray();
    }

}
