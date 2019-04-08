using System;

namespace Prototype.Bad
{
    public class CloneableAddress : ICloneable
    {
        public string StreetName;
        public int HouseNumber;

        public CloneableAddress(string streetName, int houseNumber)
        {
            StreetName = streetName ?? throw new ArgumentNullException(nameof(streetName));

            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public object Clone()
        {
            return new CloneableAddress(StreetName, HouseNumber);
        }
    }
}