﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSLPrototype.AST;

public record BinaryExpression(Expression Left, TokenNode Operator, Expression Right) : Expression
{
}
