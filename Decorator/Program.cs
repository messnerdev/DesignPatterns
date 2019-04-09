using System;
using Decorator.AdapterDecorator;
using Decorator.DynamicComposition;
using Decorator.Fluent;
using Decorator.MultipleInheritance;
using Decorator.StaticComposition;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            FluentDecorator();
            AdapterDecorator();
            MultipleInheritance();
            DynamicDecoratorComposition();
            StaticDecoratorComposition();
        }

        public static void FluentDecorator()
        {
            var cb = new CodeBuilder();
            cb.AppendLine("class foo")
                .AppendLine("{")
                .AppendLine("}");

            Console.WriteLine(cb);
        }

        public static void AdapterDecorator()
        {
            MyStringBuilder s = "hello ";
            s += "world";
            Console.WriteLine(s);
        }

        public static void MultipleInheritance()
        {
            var d = new Dragon();
            d.Crawl();
            d.Fly();
        }

        public static void DynamicDecoratorComposition()
        {
            var square = new Square(1.23f);
            Console.WriteLine(square.AsString());

            var redSquare = new ColoredShape(square, "red");
            Console.WriteLine(redSquare.AsString());

            var redClearSquare = new TransparentShape(redSquare, 0.5f);
            Console.WriteLine(redClearSquare.AsString());
        }

        // Kind of messy, don't have much control over members of deeper classes
        // Also instantiates 3 different Shapes
        public static void StaticDecoratorComposition()
        {
            var circle = new TransparentShape<ColoredShape<ShapeCircle>>();
            Console.WriteLine(circle.AsString());
        }
    }

    // CRTP Not Supported in C# :(
    // public class ColoredShape<T> : T
}
