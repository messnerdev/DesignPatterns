using System;

namespace Command
{
    public class BankAccountCommand : ICommand
    {
        private readonly BankAccount _account;
        private readonly Action _action;
        private readonly int _amount;
        private bool _succeeded;

        public BankAccountCommand(BankAccount account, Action action, int amount)
        {
            _account = account ?? throw new ArgumentNullException(nameof(account));
            _action = action;
            _amount = amount;
        }

        public void Call()
        {
            switch (_action)
            {
                case Action.Deposit:
                    _account.Deposit(_amount);
                    _succeeded = true;
                    break;
                case Action.Withdraw:
                    _succeeded = _account.Withdraw(_amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Undo()
        {
            if (!_succeeded)
                return;

            switch (_action)
            {
                case Action.Deposit:
                    _account.Withdraw(_amount);
                    break;
                case Action.Withdraw:
                    _account.Deposit(_amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public enum Action
        {
            Deposit, Withdraw
        }
    }
}