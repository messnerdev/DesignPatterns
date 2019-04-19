using System;

namespace Visitor.Dynamic
{
    public class DynamicAdditionExpression : DynamicExpression
    {
        public DynamicExpression Left, Right;

        public DynamicAdditionExpression(DynamicExpression left, DynamicExpression right)
        {
            Left = left ?? throw new ArgumentNullException(nameof(left));
            Right = right ?? throw new ArgumentNullException(nameof(right));
        }
    }
}