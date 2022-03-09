using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSLPrototype.AST;

public record LiteralExpression(TokenNode Value) : Expression
{
}
