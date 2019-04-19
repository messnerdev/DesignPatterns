using System;

namespace Visitor.Reflective
{
    public class ReflectiveAdditionExpression : ReflectiveExpression
    {
        public ReflectiveExpression Left, Right;

        public ReflectiveAdditionExpression(ReflectiveExpression left, ReflectiveExpression right)
        {
            Left = left ?? throw new ArgumentNullException(nameof(left));
            Right = right ?? throw new ArgumentNullException(nameof(right));
        }
    }
}