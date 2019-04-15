using System;

namespace TemplateMethod
{
    public class Chess : TurnBasedGame
    {
        private int _turn = 1;
        private int _maxTurns = 10;

        public Chess() : base(2)
        {
        }

        protected override bool HaveWinner => _turn == _maxTurns;
        protected override int WinningPlayer => CurrentPlayer;
        protected override void Start()
        {
            Console.WriteLine($"Starting a game of chess with {NumberOfPlayers} players.");
        }

        protected override void TakeTurn()
        {
            Console.WriteLine($"Turn {_turn++}  taken by player {CurrentPlayer}.");
            CurrentPlayer = (CurrentPlayer + 1) % NumberOfPlayers;
        }
    }
}