using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace Singleton
{
    public class SingletonDatabase : IDatabase
    {
        private static readonly Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());
        public static SingletonDatabase Instance => instance.Value;
        private readonly Dictionary<string, int> _capitals;
        public static int ConstructorCallCount { get; private set; } = 0;

        private SingletonDatabase()
        {
            ConstructorCallCount++;
            Console.WriteLine("Initializing Database");

            _capitals = File.ReadAllLines("capitals.txt")
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(), 
                    list => int.Parse(list.ElementAt(1))
                );
        }

        public int GetPopulation(string city)
        {
            return _capitals[city];
        }
    }
}