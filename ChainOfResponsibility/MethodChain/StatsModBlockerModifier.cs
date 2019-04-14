using System;

namespace ChainOfResponsibility.MethodChain
{
    public class StatsModBlockerModifier : CreatureModifier
    {
        public StatsModBlockerModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            Console.WriteLine("Blocking additional modifiers");
            // Nothing
        }
    }
}