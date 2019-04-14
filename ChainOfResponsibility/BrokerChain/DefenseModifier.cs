namespace ChainOfResponsibility.BrokerChain
{
    public class DefenseModifier : MonsterModifier
    {
        private readonly int _factor;

        public DefenseModifier(Game game, Monster monster, int factor) : base(game, monster)
        {
            _factor = factor;
        }

        protected override void Handle(object sender, Query q)
        {
            if (q.CreatureName == Monster.Name && q.WhatToQuery == QueryArgument.Defense)
                q.Value *= _factor;
        }
    }
}