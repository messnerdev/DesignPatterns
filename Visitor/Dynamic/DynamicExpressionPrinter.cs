using System.Text;

namespace Visitor.Dynamic
{
    public class DynamicExpressionPrinter
    {
        public void Print(DynamicAdditionExpression ae, StringBuilder sb)
        {
            sb.Append("(");
            Print((dynamic)ae.Left, sb);
            sb.Append("+");
            Print((dynamic)ae.Right, sb);
            sb.Append(")");
        }

        public void Print(DynamicDoubleExpression de, StringBuilder sb)
        {
            sb.Append(de.Value);
        }
    }
}