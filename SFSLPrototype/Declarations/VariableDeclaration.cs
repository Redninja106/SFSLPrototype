using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSLPrototype.Declarations;

internal class VariableDeclaration : Declaration
{
    public Token Type;
    public VariableModifier Modifier;

    public VariableDeclaration(Token name, Token type, VariableModifier modifier) : base(name)
    {
        this.Type = type;
        this.Modifier = modifier;
    }
}
