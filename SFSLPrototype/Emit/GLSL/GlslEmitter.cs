using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SFSLPrototype.Declarations;

namespace SFSLPrototype.Emit.GLSL;

internal class GlslEmitter : IEmitter
{
    TextWriter writer;

    public GlslEmitter(TextWriter writer)
    {
        this.writer = writer;
    }

    public ExpressionVisitor GetExpressionVisitor()
    {
        throw new NotImplementedException();
    }

    public void VisitBuffer(BufferDeclaration declaration)
    {
        throw new NotImplementedException();
    }

    public void VisitFunction(FunctionDeclaration declaration)
    {
        throw new NotImplementedException();
    }

    public void VisitStruct(StructDeclaration declaration)
    {
        throw new NotImplementedException();
    }

    public void VisitTexture(TextureDeclaration declaration)
    {
        throw new NotImplementedException();
    }

    public void VisitVariable(VariableDeclaration declaration)
    {
        throw new NotImplementedException();
    }
}
