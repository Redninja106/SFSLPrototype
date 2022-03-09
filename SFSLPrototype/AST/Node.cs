namespace SFSLPrototype.AST;


public abstract record Node
{
    public abstract void Accept(DocumentVisitor visitor);
}