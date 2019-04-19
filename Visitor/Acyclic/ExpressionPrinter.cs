using System.Text;

namespace Visitor.Acyclic
{
    public class ExpressionPrinter : IVisitor, IVisitor<Expression>, IVisitor<DoubleExpression>, IVisitor<AdditionExpression>
    {
        private StringBuilder _stringBuilder = new StringBuilder();

        public void Visit(Expression obj)
        {
            // Shouldn't ever arrive here
        }

        public void Visit(DoubleExpression obj)
        {
            _stringBuilder.Append(obj.Value);
        }

        public void Visit(AdditionExpression obj)
        {
            _stringBuilder.Append("(");
            obj.Left.Accept(this);
            _stringBuilder.Append("+");
            obj.Right.Accept(this);
            _stringBuilder.Append(")");
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }
    }
}