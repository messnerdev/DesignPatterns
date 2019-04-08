using System;
using Factory.AbstractFactory;
using Factory.Factory;
using Factory.FactoryMethod;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var point = PointWithFactoryMethods.NewPolarPoint(1, Math.PI / 2);
            Console.WriteLine(point);

            Point origin = Point.Origin;
            Console.WriteLine(origin);

            var machine = new HotDrinkMachine();
            machine.ListDrinks();
            var drink = machine.MakeDrink("Tea", 100);
            drink.Consume();
        }
    }
}
