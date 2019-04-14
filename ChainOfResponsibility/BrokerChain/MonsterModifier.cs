using System;

namespace ChainOfResponsibility.BrokerChain
{
    public abstract class MonsterModifier : IDisposable
    {
        private readonly Game _game;
        protected Monster Monster;

        protected MonsterModifier(Game game, Monster monster)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
            Monster = monster ?? throw new ArgumentNullException(nameof(monster));
            _game.Queries += Handle;
        }

        protected abstract void Handle(object sender, Query q);

        public void Dispose()
        {
            _game.Queries -= Handle;
        }
    }
}