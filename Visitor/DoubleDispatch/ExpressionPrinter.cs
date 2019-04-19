using System.Text;

namespace Visitor.DoubleDispatch
{
    public class DoubleDispatchExpressionPrinter : IExpressionVisitor
    {
        private readonly StringBuilder sb = new StringBuilder();

        public void Visit(DoubleDispatchDoubleExpression de)
        {
            sb.Append(de.Value);
        }

        public void Visit(DoubleDispatchAdditionExpression ae)
        {
            sb.Append("(");
            ae.Left.Accept(this);
            sb.Append("+");
            ae.Right.Accept(this);
            sb.Append(")");
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
}