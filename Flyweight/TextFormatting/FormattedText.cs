using System.Text;

namespace Flyweight.TextFormatting
{
    public class FormattedText
    {
        private readonly string _plainText;
        private readonly bool[] _capitalize;

        public FormattedText(string plainText)
        {
            _plainText = plainText;
            _capitalize = new bool[plainText.Length];
        }

        public void Capitalize(int start, int end)
        {
            for (int i = start; i <= end; i++)
                _capitalize[i] = true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var index = 0; index < _plainText.Length; index++)
            {
                char c = _plainText[index];
                sb.Append(_capitalize[index] ? char.ToUpper(c) : c);
            }

            return sb.ToString();
        }
    }
}