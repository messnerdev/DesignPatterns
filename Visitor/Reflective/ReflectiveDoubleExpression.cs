namespace Visitor.Reflective
{
    public class ReflectiveDoubleExpression : ReflectiveExpression
    {
        public double Value;

        public ReflectiveDoubleExpression(double value)
        {
            Value = value;
        }
    }
}