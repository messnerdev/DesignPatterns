using System;

namespace Factory.AbstractFactory
{
    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Drink tea");
        }
    }
}