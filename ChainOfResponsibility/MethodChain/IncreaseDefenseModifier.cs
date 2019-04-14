using System;

namespace ChainOfResponsibility.MethodChain
{
    public class IncreaseDefenseModifier : CreatureModifier
    {
        private readonly double _factor;

        public IncreaseDefenseModifier(Creature creature, double factor) : base(creature)
        {
            _factor = (factor >= 1) ? factor : throw new ArgumentOutOfRangeException(nameof(factor));
        }

        public override void Handle()
        {
            Console.WriteLine($"Increasing {Creature.Name}'s {nameof(Creature.Defense)}");
            Creature.Defense *= _factor;
            base.Handle();
        }
    }
}