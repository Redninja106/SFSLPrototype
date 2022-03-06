using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSLPrototype.Declarations;

internal class StructMember
{
    public Token Name;
    public Token Type;

    public StructMember(Token name, Token type)
    {
        this.Name = name;
        this.Type = type;
    }
}
