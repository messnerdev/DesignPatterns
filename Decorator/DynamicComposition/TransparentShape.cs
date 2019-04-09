using System;

namespace Decorator.DynamicComposition
{
    public class TransparentShape : IShape
    {
        private IShape _shape;
        private float _alpha;

        public TransparentShape(IShape shape, float alpha)
        {
            _shape = shape ?? throw new ArgumentNullException(nameof(shape));
            _alpha = alpha;
        }

        public string AsString() => $"{_shape.AsString()} has transparency {_alpha}";
    }
}