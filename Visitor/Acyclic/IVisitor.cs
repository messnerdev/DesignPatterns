namespace Visitor.Acyclic
{
    public interface IVisitor { }

    public interface IVisitor<TVisitable>
    {
        void Visit(TVisitable obj);
    }
}