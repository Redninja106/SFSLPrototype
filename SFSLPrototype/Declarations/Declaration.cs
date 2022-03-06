using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSLPrototype.Declarations;

public abstract class Declaration
{
    public Token Name;
    public AttributeDeclaration[] Attributes;

    public Declaration(Token name)
    {
        this.Name = name;
    }

    public virtual void SetAttributes(AttributeDeclaration[] attributes)
    {
        this.Attributes = attributes;
    }
}
