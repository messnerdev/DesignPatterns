using System;

namespace ChainOfResponsibility.BrokerChain
{
    public class Monster
    {
        private readonly Game _game;
        public string Name;
        private readonly int _attack;
        private readonly int _defense;

        public int Attack
        {
            get
            {
                var q = new Query(Name, QueryArgument.Attack, _attack);
                _game.PerformQuery(this, q);
                return q.Value;
            }
        }

        public int Defense {
            get {
                var q = new Query(Name, QueryArgument.Defense, _defense);
                _game.PerformQuery(this, q);
                return q.Value;
            }
        }

        public Monster(Game game, string name, int attack, int defense)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            _attack = attack;
            _defense = defense;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
        }
    }
}