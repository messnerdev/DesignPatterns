using System;
using System.Diagnostics;
using System.Dynamic;
using ImpromptuInterface;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Real logger
            var log = new ConsoleLog();
            var ba = new BankAccount(log);
            ba.Deposit(100);
            ba.Withdraw(200);

            // Dummy logger
            var nullLog = new NullLog();
            var nullLogBankAccount = new BankAccount(nullLog);
            nullLogBankAccount.Deposit(100);

            // Low effort dummy logger (slower, but useful for large interfaces)
            ILog nullTLog = Null<ILog>.Instance;
            var nullTLogBankAccount = new BankAccount(nullTLog);
            nullTLogBankAccount.Deposit(100);
        }
    }

    public interface ILog
    {
        void Info(string message);
        void Warn(string message);
    }

    public class NullLog : ILog
    {
        public void Info(string message) { }

        public void Warn(string message) { }
    }

    public class Null<TInterface> : DynamicObject where TInterface : class
    {
        public static TInterface Instance {
            get {
                if (!typeof(TInterface).IsInterface)
                    throw new ArgumentException("I must be an interface type");

                return new Null<TInterface>().ActLike<TInterface>();
            }
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = Activator.CreateInstance(binder.ReturnType);
            return true;
        }

        private class Empty { }
    }

    public class ConsoleLog : ILog
    {
        public void Info(string message)
        {
            Console.WriteLine(message);
        }

        public void Warn(string message)
        {
            LogInColor(ConsoleColor.Yellow, message);
        }

        private void LogInColor(ConsoleColor color, string message)
        {
            ConsoleColor ogColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ogColor;
        }
    }

    public class BankAccount
    {
        private readonly ILog _log;
        private int _balance;

        public BankAccount(ILog log)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void Deposit(int amount)
        {
            _balance += amount;
            _log.Info($"Deposited {amount}, balance is now {_balance}");
        }

        public void Withdraw(int amount)
        {
            if (_balance >= amount)
            {
                _balance -= amount;
                _log.Info($"Withdrew ${amount}, we have ${_balance} left");
            }
            else
            {
                _log.Warn($"Could not withdraw ${amount} because balance is only ${_balance}");
            }
        }
    }
}
