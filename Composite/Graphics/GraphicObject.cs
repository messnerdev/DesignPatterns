using System;
using System.Collections.Generic;
using System.Text;

namespace Composite.Graphics
{
    public class GraphicObject
    {
        public string Color;
        public virtual string Name { get; set; } = "Group";

        private readonly Lazy<List<GraphicObject>> _children = new Lazy<List<GraphicObject>>();

        public List<GraphicObject> Children => _children.Value;

        private void Print(StringBuilder sb, int depth)
        {
            sb.Append(new string('\t', depth))
                .Append(string.IsNullOrWhiteSpace(Color) ? string.Empty : $"{Color}")
                .AppendLine($"{Name}");

            foreach (GraphicObject child in Children)
            {
                child.Print(sb, depth+1);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Print(sb, 0);
            return sb.ToString();
        }
    }
}