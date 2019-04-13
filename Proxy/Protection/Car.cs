using System;

namespace Proxy.Protection
{
    public class Car : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Car driving");
        }
    }
}