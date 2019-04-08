using System;

namespace Factory.AbstractFactory
{
    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Grind beans, boil water, pour {amount} ml, add cream, enjoy!");
            return new Coffee();
        }
    }
}