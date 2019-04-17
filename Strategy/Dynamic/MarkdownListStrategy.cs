using System.Text;

namespace Strategy.Dynamic
{
    public class MarkdownListStrategy : IListStrategy
    {
        public void Start(StringBuilder sb)
        {

        }

        public void End(StringBuilder sb)
        {

        }

        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($" * {item}");
        }
    }
}