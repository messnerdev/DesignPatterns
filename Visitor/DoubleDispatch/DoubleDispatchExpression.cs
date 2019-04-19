namespace Visitor.DoubleDispatch
{
    public abstract class DoubleDispatchExpression
    {
        // Double dispatch
        public abstract void Accept(IExpressionVisitor visitor);
    }
}