using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSLPrototype.Declarations;

internal class FunctionDeclaration : Declaration
{
    public Token ReturnType;
    public FunctionParameter[] Parameters;
    public Token[] Body;

    public FunctionDeclaration(Token name, Token returnType, FunctionParameter[] parameters, Token[] body) : base(name)
    {
        this.ReturnType = returnType;
        this.Parameters = parameters;
        this.Body = body;
    }
}
