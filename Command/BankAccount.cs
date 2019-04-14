using System;

namespace Command
{
    public class BankAccount
    {
        private int _balance;
        private int _overdraftLimit = -500;

        public void Deposit(int amount)
        {
            _balance += amount;
            Console.WriteLine($"Deposited ${amount}, balance is now {_balance}");
        }

        public bool Withdraw(int amount)
        {
            if (_balance - amount < _overdraftLimit)
                return false;

            _balance -= amount;
            Console.WriteLine($"Withdrew ${amount}, balance is now {_balance}");
            return true;
        }

        public override string ToString()
        {
            return $"{nameof(_balance)}: {_balance}";
        }
    }
}