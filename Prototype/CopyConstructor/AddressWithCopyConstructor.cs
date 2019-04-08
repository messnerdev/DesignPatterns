using System;

namespace Prototype.CopyConstructor
{
    public class AddressWithCopyConstructor
    {
        public string StreetName;
        public int HouseNumber;

        public AddressWithCopyConstructor(string streetName, int houseNumber)
        {
            StreetName = streetName ?? throw new ArgumentNullException(nameof(streetName));

            HouseNumber = houseNumber;
        }

        // Copy constructor
        public AddressWithCopyConstructor(AddressWithCopyConstructor other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }
}