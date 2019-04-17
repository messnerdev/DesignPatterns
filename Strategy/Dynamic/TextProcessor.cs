using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy.Dynamic
{
    public class TextProcessor
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();
        private IListStrategy _listStrategy;

        public void SetOutputFormat(OutputFormat format)
        {
            switch (format)
            {
                case OutputFormat.Markdown:
                    _listStrategy = new MarkdownListStrategy();
                    break;
                case OutputFormat.Html:
                    _listStrategy = new HtmlListStrategy();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(format), format, null);
            }
        }

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