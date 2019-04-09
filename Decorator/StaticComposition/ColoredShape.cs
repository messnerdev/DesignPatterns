using System;

namespace Decorator.StaticComposition
{
    public class ColoredShape<T> : Shape where T : Shape, new()
    {
        private string _color;
        private T _shape = new T();

        public ColoredShape() : this("black") {  }

        public ColoredShape(string color)
        {
            _color = color ?? throw new ArgumentNullException(nameof(color));
        }

        public override string AsString() => $"{_shape.AsString()} has the color {_color}";
    }
}
