namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            MagicSquareGenerator msg = new MagicSquareGenerator();
            var k = msg.Generate(4);
        }
    }
}
