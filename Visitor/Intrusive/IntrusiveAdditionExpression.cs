using System;
using System.Text;

namespace Visitor.Intrusive
{
    public class IntrusiveAdditionExpression : IntrusiveExpression
    {
        private IntrusiveExpression _left, _right;

        public IntrusiveAdditionExpression(IntrusiveExpression left, IntrusiveExpression right)
        {
            _left = left ?? throw new ArgumentNullException(nameof(left));
            _right = right ?? throw new ArgumentNullException(nameof(right));
        }

        public override void Print(StringBuilder sb)
        {
            sb.Append("(");
            _left.Print(sb);
            sb.Append("+");
            _right.Print(sb);
            sb.Append(")");
        }
    }
}