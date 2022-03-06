using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SFSLPrototype.Declarations;

namespace SFSLPrototype.Emit;

internal interface IEmitter
{
    void VisitBuffer(BufferDeclaration declaration);
    void VisitFunction(FunctionDeclaration declaration);
    void VisitStruct(StructDeclaration declaration);
    void VisitTexture(TextureDeclaration declaration);
    void VisitVariable(VariableDeclaration declaration);

    ExpressionVisitor GetExpressionVisitor();
}
