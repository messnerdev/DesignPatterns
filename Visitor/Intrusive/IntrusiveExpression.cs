using System.Text;

namespace Visitor.Intrusive
{
    public abstract class IntrusiveExpression
    {
        public abstract void Print(StringBuilder sb);
    }
}