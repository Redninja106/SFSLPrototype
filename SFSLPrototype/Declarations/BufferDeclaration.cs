using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSLPrototype.Declarations;

internal class BufferDeclaration : Declaration
{
    public Token Type { get; private set; }

    public BufferDeclaration(Token name, Token type) : base(name)
    {
        this.Type = type;
    }
}
