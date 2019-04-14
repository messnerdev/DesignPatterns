using System;
using System.Collections.Generic;
using System.Linq;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            var ba = new BankAccount();
            var commands = new List<ICommand>()
            {
                new BankAccountCommand(ba, BankAccountCommand.Action.Deposit, 100),
                new BankAccountCommand(ba, BankAccountCommand.Action.Withdraw, 1000)
            };

            Console.WriteLine(ba);

            foreach (ICommand command in commands)
                command.Call();

            Console.WriteLine(ba);

            foreach (ICommand command in Enumerable.Reverse(commands))
                command.Undo();

            Console.WriteLine(ba);
        }
    }
}
