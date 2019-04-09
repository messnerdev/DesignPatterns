namespace Decorator.StaticComposition
{
    public class ShapeCircle : Shape
    {
        private float _radius;

        public ShapeCircle() : this(0.0f) { }

        public ShapeCircle(float radius)
        {
            this._radius = radius;
        }

        public void Resize(float factor)
        {
            _radius *= factor;
        }

        public override string AsString() => $"A {nameof(ShapeCircle)} with radius {_radius}";
    }
}