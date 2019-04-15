using System.Collections.Generic;

namespace Memento
{
    public class BankAccount
    {
        private int _balance;
        private List<Memento> _changes = new List<Memento>();
        private int _current;

        public BankAccount(int balance)
        {
            _balance = balance;
            _changes.Add(new Memento(_balance));
        }

        public Memento Deposit(int amount)
        {
            _balance += amount;
            var m = new Memento(_balance);
            _changes.RemoveRange(++_current, _changes.Count - _current);
            _changes.Add(m);
            return m;
        }

        public Memento Restore(Memento m)
        {
            if (m == null)
                return null;

            _balance = m.Balance;
            _changes.Add(m);
            _current++;
            return m;
        }

        public Memento Undo()
        {
            if (_current <= 0)
                return null;

            Memento m = _changes[--_current];
            _balance = m.Balance;
            return m;
        }

        public Memento Redo()
        {
            if (_current + 1 >= _changes.Count)
                return null;

            Memento m = _changes[++_current];
            _balance = m.Balance;
            return m;
        }

        public override string ToString()
        {
            return $"{nameof(_balance)}: {_balance}";
        }
    }
}