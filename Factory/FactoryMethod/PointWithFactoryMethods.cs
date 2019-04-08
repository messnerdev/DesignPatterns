using System;

namespace Factory.FactoryMethod
{
    public class PointWithFactoryMethods
    {
        // Factory method
        public static PointWithFactoryMethods NewCartesianPoint(double x, double y)
        {
            return new PointWithFactoryMethods(x, y);
        }

        // Factory method
        public static PointWithFactoryMethods NewPolarPoint(double rho, double theta)
        {
            return new PointWithFactoryMethods(rho*Math.Cos(theta), rho*Math.Sin(theta));
        }

        private double x, y;

        private PointWithFactoryMethods(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }
}
