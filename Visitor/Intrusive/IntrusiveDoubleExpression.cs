using System.Text;

namespace Visitor.Intrusive
{
    public class IntrusiveDoubleExpression : IntrusiveExpression
    {
        private double _value;

        public IntrusiveDoubleExpression(double value)
        {
            _value = value;
        }

        public override void Print(StringBuilder sb)
        {
            sb.Append(_value);
        }
    }
}