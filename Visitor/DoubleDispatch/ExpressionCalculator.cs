namespace Visitor.DoubleDispatch
{
    public class ExpressionCalculator : IExpressionVisitor
    {
        public double Result;

        public void Visit(DoubleDispatchDoubleExpression de)
        {
            Result = de.Value;
        }

        public void Visit(DoubleDispatchAdditionExpression ae)
        {
            ae.Left.Accept(this);
            double a = Result;
            ae.Right.Accept(this);
            double b = Result;
            Result = a + b;
        }
    }
}