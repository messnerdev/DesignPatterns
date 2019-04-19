namespace Visitor.Dynamic
{
    public class DynamicDoubleExpression : DynamicExpression
    {
        public double Value;

        public DynamicDoubleExpression(double value)
        {
            Value = value;
        }
    }
}