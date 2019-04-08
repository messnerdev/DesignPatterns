using System;

namespace Factory.Factory
{
    public class Point
    {
        public static Point Origin = new Point(0,0);
        private double x, y;

        // Ideally we wouldn't want a public constructor since it doesn't support both cartesian and polar
        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

        public static class Factory
        {
            // Factory method
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            // Factory method
            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
    }
}
