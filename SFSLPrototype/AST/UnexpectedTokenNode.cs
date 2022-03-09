﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSLPrototype.AST;

public record UnexpectedTokenNode(TokenNode Unexpected) : Node()
{
    public override void Accept(DocumentVisitor visitor)
    {
        visitor.Visit(this);

        Unexpected.Accept(visitor);
    }
}
