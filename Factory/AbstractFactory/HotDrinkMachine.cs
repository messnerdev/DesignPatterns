using System;
using System.Collections.Generic;
using System.Linq;

namespace Factory.AbstractFactory
{
    public class HotDrinkMachine
    {
        private readonly Dictionary<string, IHotDrinkFactory> _factories = new Dictionary<string, IHotDrinkFactory>();

        public HotDrinkMachine()
        {
            // Typically dependency injection would replace this reflection code
            var factoryImplementations = typeof(HotDrinkMachine).Assembly.GetTypes()
                .Where(x => typeof(IHotDrinkFactory).IsAssignableFrom(x) && !x.IsInterface);

            foreach (Type t in factoryImplementations)
            {
                string drinkName = t.Name.Replace("Factory", string.Empty);
                _factories[drinkName] = (IHotDrinkFactory)Activator.CreateInstance(t);
            }
        }

        public IHotDrink MakeDrink(string drinkName, int amount)
        {
            if (_factories.TryGetValue(drinkName, out IHotDrinkFactory factory))
            {
                return factory.Prepare(amount);
            }

            throw new ArgumentOutOfRangeException(nameof(drinkName));
        }

        public void ListDrinks()
        {
            Console.WriteLine("Available Drinks");
            foreach (string drinkName in _factories.Keys)
            {
                Console.WriteLine($"\t{drinkName}");
            }
        }
    }
}