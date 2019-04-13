using System;
using System.Security.Cryptography.X509Certificates;
using Proxy.Composite;
using Proxy.Dynamic;
using Proxy.Property;
using Proxy.Protection;
using Proxy.Value;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            ProtectionProxyExample();
            PropertyProxyExample();
            ValueProxyExample();
            CompositeProxyExample();
            DynamicProxyExample();
        }

        private static void ProtectionProxyExample()
        {
            ICar car = new CarProxy(new Driver(12));
            car.Drive();
        }

        private static void PropertyProxyExample()
        {
            var c = new PropertyCreature
            {
                Agility = 10
            };

            // Doesn't do anything
            c.Agility = 10;
        }

        private static void ValueProxyExample()
        {
            Console.WriteLine(10.0 * 5.Percent());
            Console.WriteLine(2.Percent() + 3.Percent());
        }

        private static void CompositeProxyExample()
        {
            // Array of structures (AoS)
            // Memory layout of creatures: Age X Y Age X Y Age X Y...
            var creatures = new Creature[100];
            for (int i = 0; i < 100; i++)
                creatures[i] = new Creature(){Age = 10, X = 0, Y = 0};

            foreach (Creature creature in creatures)
                creature.X++;

            // Structure of Array (SoA)
            // Preferred memory layout for efficient manipulation:
            // Age Age Age ...
            // X X X
            // Y Y Y
            var creatures2 = new Creatures(100);
            foreach (Creatures.CreatureProxy creature in creatures2)
                creature.X++;
        }

        private static void DynamicProxyExample()
        {
            //var ba = new BankAccount();
            var ba = Log<BankAccount>.As<IBankAccount>();

            ba.Deposit(100);
            ba.Withdraw(50);

            Console.WriteLine(ba);
        }
    }
}
