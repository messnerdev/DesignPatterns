using System;

namespace ChainOfResponsibility.MethodChain
{
    public class CreatureModifier
    {
        protected Creature Creature;
        protected CreatureModifier Next; // Linked List
        private bool HasNext => Next != null;

        public CreatureModifier(Creature creature)
        {
            Creature = creature ?? throw new ArgumentNullException(nameof(creature));
        }

        public void Add(CreatureModifier creatureModifier)
        {
            if (HasNext)
                Next.Add(creatureModifier);
            else
                Next = creatureModifier;
        }

        public virtual void Handle() => Next?.Handle();
    }
}