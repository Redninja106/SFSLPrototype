using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSLPrototype.Declarations;

internal class StructDeclaration : Declaration
{
    public StructMember[] Members;

    public StructDeclaration(Token name, StructMember[] members) : base(name)
    {
        this.Members = members;
    }
}
