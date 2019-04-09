using System;

namespace Decorator.DynamicComposition
{
    public class ColoredShape : IShape
    {
        private IShape _shape;
        private string _color;

        public ColoredShape(IShape shape, string color)
        {
            _shape = shape ?? throw new ArgumentNullException(nameof(shape));
            _color = color ?? throw new ArgumentNullException(nameof(color));
        }

        public string AsString() =>$"{_shape.AsString()} has the color {_color}";
    }
}