using System;

namespace ChainOfResponsibility.MethodChain
{
    public class DoubleAttachModifier : CreatureModifier
    {
        public DoubleAttachModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            Console.WriteLine($"Doubling {Creature.Name}'s {nameof(Creature.Attack)}");
            Creature.Attack *= 2;
            base.Handle();
        }
    }
}