namespace SOLID.LiskovSubstitution.Bad
{
    public class BadSquare : Rectangle
    {
        public new int Width
        {
            set => base.Width = base.Height = value;
        }

        public new int Height
        {
            set => Width = value;
        }
    }
}
