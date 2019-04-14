using System;
using System.Collections.Generic;
using ChainOfResponsibility.BrokerChain;
using ChainOfResponsibility.MethodChain;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodChainExample();
            BrokerChainExample();
        }

        // Modification of base object
        private static void MethodChainExample()
        {
            var goblin = new Creature("Goblin", 2, 2);
            Console.WriteLine(goblin);

            var root = new CreatureModifier(goblin);

            Console.WriteLine("Let's double the goblins attack");
            root.Add(new DoubleAttachModifier(goblin));

            Console.WriteLine("Let's block further additional goblin modifiers");
            root.Add(new StatsModBlockerModifier(goblin));

            Console.WriteLine("Let's increase the goblins defense");
            root.Add(new IncreaseDefenseModifier(goblin, 2.4));

            root.Handle();
            Console.WriteLine(goblin);
        }

        // Also the mediator design pattern!
        // Does not modify base object
        private static void BrokerChainExample()
        {
            var game = new Game();
            var goblin = new Monster(game,"HobGoblin", 3, 3);
            Console.WriteLine(goblin);

            using (MonsterModifier mod = new AttackModifier(game, goblin, 2))
            {
                Console.WriteLine(goblin);
            }

            Console.WriteLine(goblin);

            using (MonsterModifier mod = new DefenseModifier(game, goblin, 2))
            {
                Console.WriteLine(goblin);
            }

            Console.WriteLine(goblin);
        }
    }
}
