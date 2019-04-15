using System;

namespace TemplateMethod
{
    public abstract class TurnBasedGame
    {
        protected int CurrentPlayer;
        protected readonly int NumberOfPlayers;
        protected abstract bool HaveWinner { get; }
        protected abstract int WinningPlayer { get; }

        protected TurnBasedGame(int numberOfPlayers)
        {
            NumberOfPlayers = numberOfPlayers;
        }

        public void Run()
        {
            Start();
            while (!HaveWinner)
                TakeTurn();

            Console.WriteLine($"Player {WinningPlayer} wins");
        }

        protected abstract void Start();
        protected abstract void TakeTurn();
    }
}