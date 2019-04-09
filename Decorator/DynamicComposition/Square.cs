namespace Decorator.DynamicComposition
{
    public class Square : IShape
    {
        private float _sideLength;

        public Square(float sideLength)
        {
            _sideLength = sideLength;
        }

        public string AsString() => $"A {nameof(Square)} with side-length {_sideLength}";
    }
}