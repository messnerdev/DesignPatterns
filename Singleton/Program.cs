using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Singleton.Monostate;

namespace Singleton
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Singleton();
            // See tests

            MonoState();
        }

        private static void Singleton()
        {
            var db = SingletonDatabase.Instance;
            string city = "Tokyo";
            Console.WriteLine($"{city}: {db.GetPopulation(city)}");
        }

        private static void MonoState()
        {
            var ceo = new Ceo
            {
                Name = "Jeff",
                Age = 12
            };
            Console.WriteLine(ceo);

            var newCeo = new Ceo();
            Console.WriteLine(newCeo);
        }
    }
}
