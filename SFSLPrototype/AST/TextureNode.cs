﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSLPrototype.AST;
public record TextureNode(TokenNode TextureKeyword, TokenNode NameToken, TokenNode Semicolon) : Node()
{
    public override void Accept(DocumentVisitor visitor)
    {
        visitor.Visit(this);

        TextureKeyword.Accept(visitor);
        NameToken.Accept(visitor);
        Semicolon.Accept(visitor);
    }
}

