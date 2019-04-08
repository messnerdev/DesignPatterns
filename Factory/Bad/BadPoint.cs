using System;

namespace Factory
{
    public class BadPoint
    {
        private double x, y;

        /// <summary>
        /// Initializes a point in Cartesian or Polar coordinates
        /// </summary>
        /// <param name="a">x if cartesian, rho if polar</param>
        /// <param name="b">y is cartesian, theta if polar </param>
        /// <param name="system"></param>
        public BadPoint(double a, double b, CoordinateSystem system = CoordinateSystem.Cartesian)
        {
            // Not a good approach, users need to refer to XML documentation to know what point a and b are
            switch (system)
            {
                case CoordinateSystem.Cartesian:
                    x = a;
                    y = b;
                    break;
                case CoordinateSystem.Polar:
                    x = a * Math.Cos(b);
                    y = a * Math.Sign(b);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(system), system, null);
            }
        }

        // Can't do this, equivalent constructors
        //public Point(double rho, double theta)
        //{

        //}
    }
}