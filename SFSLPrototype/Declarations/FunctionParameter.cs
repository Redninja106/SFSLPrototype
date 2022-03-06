namespace SFSLPrototype.Declarations;

public class FunctionParameter
{
    public Token Type;
    public Token Name;

    public FunctionParameter(Token type, Token name)
    {
        this.Type = type;
        this.Name = name;
    }
}