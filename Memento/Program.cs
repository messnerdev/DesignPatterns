using System;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            var ba = new BankAccount(100);

            var m1 = ba.Deposit(50);
            var m2 = ba.Deposit(25);
            Console.WriteLine(ba);

            ba.Undo();
            Console.WriteLine($"Undo 1: {ba}");

            ba.Undo();
            Console.WriteLine($"Undo 2: {ba}");

            ba.Redo();
            Console.WriteLine($"Redo 1: {ba}");

            var m3 = ba.Deposit(100);
            Console.WriteLine(ba);

            var m4 = ba.Deposit(200);
            Console.WriteLine(ba);
        }
    }
}
