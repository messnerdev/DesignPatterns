namespace ChainOfResponsibility.BrokerChain
{
    public class AttackModifier : MonsterModifier
    {
        private readonly int _factor;

        public AttackModifier(Game game, Monster monster, int factor) : base(game, monster)
        {
            _factor = factor;
        }

        protected override void Handle(object sender, Query q)
        {
            if (q.CreatureName == Monster.Name && q.WhatToQuery == QueryArgument.Attack)
                q.Value *= _factor;
        }
    }
}