namespace Visitor.DoubleDispatch
{
    public class DoubleDispatchDoubleExpression : DoubleDispatchExpression
    {
        public double Value;

        public DoubleDispatchDoubleExpression(double value)
        {
            Value = value;
        }

        public override void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}