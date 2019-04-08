using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using SOLID.DependencyInversion;
using SOLID.LiskovSubstitution;
using SOLID.LiskovSubstitution.Bad;
using SOLID.OpenClosed;
using SOLID.OpenClosed.Bad;

namespace SOLID
{
    class Program
    {
        static void SingleResponsibility()
        {
            var j = new Journal();
            j.AddEntry("I cried today.");
            j.AddEntry("I ate a bug.");
            Console.WriteLine(j);

            var p = new Persistence();
            var filename = "journal.txt";
            p.SaveToFile(j, filename);
        }

        static void OpenClosed()
        {
            var products = new Product[]
            {
                new Product("Apple", Color.Green, Size.Small),
                new Product("Tree", Color.Green, Size.Large),
                new Product("House", Color.Blue, Size.Large) 
            };

            Console.WriteLine("Green Products (old filter)");
            foreach (Product p in ProductFilter.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($"\t{p.Name} is {p.Color}");
            }

            Console.WriteLine("Green Products (better filter)");
            var bf = new BetterProductFilter();
            foreach (Product p in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($"\t{p.Name} is {p.Color}");
            }

            // Abstracted logic that is open to extension (create new ISpecifications), but closed to modification (should never have to edit BetterProductFilter)
            Console.WriteLine("Green & Large Products (better filter)");
            var andSpecification = new AndSpecification<Product>(new ColorSpecification(Color.Green), new SizeSpecification(Size.Large));
            foreach (Product p in bf.Filter(products, andSpecification))
            {
                Console.WriteLine($"\t{p.Name} is {p.Color} and {p.Size}");
            }

            // Abstracted logic that is open to extension (create new ISpecifications), but closed to modification (should never have to edit BetterProductFilter)
            Console.WriteLine("Blue or Small Products (better filter)");
            var orSpecification = new OrSpecification<Product>(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Small));
            foreach (Product p in bf.Filter(products, orSpecification))
            {
                Console.WriteLine($"\t{p.Name} is {p.Color} and {p.Size}");
            }
        }

        private static void LiskovSubstitution()
        {
            var rectangle = new Rectangle(2,4);
            Console.WriteLine($"{rectangle} has area {rectangle.Area}");

            // Will not set width properly, as it is using the Rectangle Width setter
            Rectangle badSquare = new BadSquare();
            badSquare.Height = 4; 
            Console.WriteLine($"{badSquare} has area {badSquare.Area}");
            
            // Functionality of Square should be preserved even if it is instantiated as a rectangle
            Rectangle goodSquare = new Square();
            goodSquare.Height = 4;
            Console.WriteLine($"{goodSquare} has area {goodSquare.Area}");
        }

        private static void InterfaceSegregation()
        {
            // See folder
        }

        private static void DependencyInversion()
        {
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new Relationships();

            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            var research = new Research(relationships);
        }

        static void Main(string[] args)
        {
            SingleResponsibility();
            OpenClosed();
            LiskovSubstitution();
            InterfaceSegregation();
            DependencyInversion();
        }
    }
}
