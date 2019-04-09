namespace Decorator.DynamicComposition
{
    public class Circle : IShape
    {
        private float _radius;

        public Circle(float radius)
        {
            this._radius = radius;
        }

        public void Resize(float factor)
        {
            _radius *= factor;
        }

        public string AsString() => $"A {nameof(Circle)} with radius {_radius}";
    }
}