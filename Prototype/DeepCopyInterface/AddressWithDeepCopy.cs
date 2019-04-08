using System;

namespace Prototype
{
    public class AddressWithDeepCopy : IPrototype<AddressWithDeepCopy>
    {
        public string StreetName;
        public int HouseNumber;

        public AddressWithDeepCopy(string streetName, int houseNumber)
        {
            StreetName = streetName ?? throw new ArgumentNullException(nameof(streetName));

            HouseNumber = houseNumber;
        }

        public AddressWithDeepCopy DeepCopy()
        {
            return new AddressWithDeepCopy(StreetName, HouseNumber);
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }
}