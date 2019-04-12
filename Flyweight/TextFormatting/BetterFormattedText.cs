using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flyweight.TextFormatting
{
    public class BetterFormattedText
    {
        private readonly string _plainText;
        private readonly List<TextRange> _formatting = new List<TextRange>();

        public BetterFormattedText(string plainText)
        {
            _plainText = plainText;
        }

        public TextRange GetRange(int start, int end)
        {
            var range = new TextRange(){Start = start, End = end};
            _formatting.Add(range);

            return range;
        }

        public class TextRange
        {
            public int Start, End;
            public bool Capitalize, Bold, Italic;

            public bool Covers(int position)
            {
                return position >= Start && position <= End;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < _plainText.Length; i++)
            {
                string c = _plainText[i].ToString();
                foreach (TextRange textRange in _formatting.Where(range => range.Covers(i)))
                {
                    if (textRange.Capitalize)
                        c = c.ToUpper();

                    // TODO Bold & Italic
                }

                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}