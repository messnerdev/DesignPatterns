namespace Decorator.StaticComposition
{
    public class ShapeSquare : Shape
    {
        private float _sideLength;

        public ShapeSquare() : this(0.0f) { }

        public ShapeSquare(float sideLength)
        {
            _sideLength = sideLength;
        }

        public override string AsString() => $"A {nameof(ShapeSquare)} with side-length {_sideLength}";
    }
}