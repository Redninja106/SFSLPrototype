﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSLPrototype.AST;

public record Expression : Node
{
    public override void Accept(DocumentVisitor visitor)
    {
        throw new NotImplementedException();
    }
}
