using System;
using System.Collections.Generic;
using System.Text;

namespace Visitor.Reflective
{
    public static class ReflectiveExpressionPrinter
    {
        public static void SwitchBasedPrint(ReflectiveExpression e, StringBuilder sb)
        {
            if (e is ReflectiveDoubleExpression de)
            {
                sb.Append(de.Value);
            }
            else if (e is ReflectiveAdditionExpression ae)
            {
                sb.Append("(");
                SwitchBasedPrint(ae.Left, sb);
                sb.Append("+");
                SwitchBasedPrint(ae.Right, sb);
                sb.Append(")");
            }
        }

        private static readonly Dictionary<Type, Action<ReflectiveExpression, StringBuilder>> Actions = new Dictionary<Type, Action<ReflectiveExpression, StringBuilder>>
        {
            [typeof(ReflectiveDoubleExpression)] = (e, sb) =>
            {
                var de = (ReflectiveDoubleExpression) e;
                sb.Append(de.Value);
            },
            [typeof(ReflectiveAdditionExpression)] = (e, sb) =>
            {
                var ae = (ReflectiveAdditionExpression)e;
                sb.Append("(");
                LookupBasedPrint(ae.Left, sb);
                sb.Append("+");
                LookupBasedPrint(ae.Right, sb);
                sb.Append(")");
            }
        };

        public static void LookupBasedPrint(ReflectiveExpression e, StringBuilder sb)
        {
            Actions[e.GetType()].Invoke(e, sb);
        }
    }
}