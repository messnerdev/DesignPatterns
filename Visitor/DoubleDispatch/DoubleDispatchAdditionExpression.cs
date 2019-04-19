using System;

namespace Visitor.DoubleDispatch
{
    public class DoubleDispatchAdditionExpression : DoubleDispatchExpression
    {
        public DoubleDispatchExpression Left, Right;

        public DoubleDispatchAdditionExpression(DoubleDispatchExpression left, DoubleDispatchExpression right)
        {
            Left = left ?? throw new ArgumentNullException(nameof(left));
            Right = right ?? throw new ArgumentNullException(nameof(right));
        }

        public override void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}