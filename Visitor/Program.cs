using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Visitor.Acyclic;
using Visitor.DoubleDispatch;
using Visitor.Dynamic;
using Visitor.Intrusive;
using Visitor.Reflective;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            IntrusiveExample();
            ReflectionBasedExample();
            DoubleDispatchVisitorExample();
            DynamicVisitorExample();
            AcyclicVisitor();
        }

        // Intrusive requires us to go in and implement the method explicitly for each inheriting class
        private static void IntrusiveExample()
        {
            var e = new IntrusiveAdditionExpression(new IntrusiveDoubleExpression(1.0), new IntrusiveAdditionExpression(new IntrusiveDoubleExpression(2.0), new IntrusiveDoubleExpression(3.0)));
            var sb = new StringBuilder();
            e.Print(sb);
            Console.WriteLine(sb);
        }

        // Still not good
        private static void ReflectionBasedExample()
        {
            var e = new ReflectiveAdditionExpression(new ReflectiveDoubleExpression(1.0), new ReflectiveAdditionExpression(new ReflectiveDoubleExpression(2.0), new ReflectiveDoubleExpression(3.0)));
            var sb = new StringBuilder();
            ReflectiveExpressionPrinter.SwitchBasedPrint(e, sb);
            Console.WriteLine(sb);

            sb.Clear();
            ReflectiveExpressionPrinter.LookupBasedPrint(e, sb);
            Console.WriteLine(sb);
        }

        // Classic Visitor Pattern
        private static void DoubleDispatchVisitorExample()
        {
            var e = new DoubleDispatchAdditionExpression(new DoubleDispatchDoubleExpression(1.0), new DoubleDispatchAdditionExpression(new DoubleDispatchDoubleExpression(2.0), new DoubleDispatchDoubleExpression(3.0)));
            var ep = new DoubleDispatchExpressionPrinter();
            ep.Visit(e);
            Console.WriteLine(ep);

            var ec = new ExpressionCalculator();
            ec.Visit(e);
            Console.WriteLine($"{ep} = {ec.Result}");
        }

        // Not very performant or safe
        private static void DynamicVisitorExample()
        {
            DynamicExpression e = new DynamicAdditionExpression(new DynamicDoubleExpression(1.0), new DynamicAdditionExpression(new DynamicDoubleExpression(2.0), new DynamicDoubleExpression(3.0)));
            var ep = new DynamicExpressionPrinter();
            var sb = new StringBuilder();
            ep.Print((dynamic)e, sb);
            Console.WriteLine(sb);
        }

        private static void AcyclicVisitor()
        {
            AdditionExpression e = new AdditionExpression(new DoubleExpression(1.0),
                new AdditionExpression(new DoubleExpression(2.0), new DoubleExpression(3.0)));

            var ep = new ExpressionPrinter();
            ep.Visit(e);
            Console.WriteLine(ep);
        }
    }
}
