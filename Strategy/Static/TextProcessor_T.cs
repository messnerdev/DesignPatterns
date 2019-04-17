using System;
using System.Collections.Generic;
using System.Text;
using Strategy.Dynamic;

namespace Strategy.Static
{
    class TextProcessor<T> where T : IListStrategy, new()
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();
        private readonly IListStrategy _listStrategy = new T();

        public void AppendList(IEnumerable<string> items)
        {
            _listStrategy.Start(_stringBuilder);
            foreach (string item in items)
                _listStrategy.AddListItem(_stringBuilder, item);
            _listStrategy.End(_stringBuilder);
        }

        public StringBuilder Clear()
        {
            return _stringBuilder.Clear();
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }
    }
}
