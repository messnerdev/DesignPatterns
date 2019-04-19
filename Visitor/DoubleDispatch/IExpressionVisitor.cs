namespace Visitor.DoubleDispatch
{
    public interface IExpressionVisitor
    {
        void Visit(DoubleDispatchDoubleExpression de);
        void Visit(DoubleDispatchAdditionExpression ae);
    }
}