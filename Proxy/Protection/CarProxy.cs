using System;

namespace Proxy.Protection
{
    public class CarProxy : ICar
    {
        private readonly Driver _driver;
        private readonly Car _car = new Car();

        public CarProxy(Driver driver)
        {
            _driver = driver;
        }

        public void Drive()
        {
            if (_driver.Age >= 16)
                _car.Drive();
            else
                Console.WriteLine("too young");
        }
    }
}