using System;

namespace Decorator.StaticComposition
{
    public class TransparentShape<T> : Shape where T : Shape, new()
    {
        private float _alpha;
        private T _shape = new T();

        public TransparentShape() : this(1.0f) {  }

        public TransparentShape(float alpha)
        {
            _alpha = alpha;
        }

        public override string AsString() => $"{_shape.AsString()} has transparency {_alpha}";
    }
}
