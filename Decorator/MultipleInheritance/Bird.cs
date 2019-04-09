using System;

namespace Decorator.MultipleInheritance
{
    public class Bird : IBird
    {
        public int Weight { get; set; }

        public void Fly()
        {
            Console.WriteLine("Soaring in the sky");
        }
    }
}