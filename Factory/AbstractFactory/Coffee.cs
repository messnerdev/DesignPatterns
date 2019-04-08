using System;

namespace Factory.AbstractFactory
{
    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Drink coffee");
        }
    }
}