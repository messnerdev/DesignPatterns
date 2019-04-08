using System;

namespace Prototype
{
    public class PersonWithDeepCopy : IPrototype<PersonWithDeepCopy>
    {
        public string[] Names;
        public AddressWithDeepCopy Address;

        public PersonWithDeepCopy(string[] names, AddressWithDeepCopy address)
        {
            Names = names ?? throw new ArgumentNullException(nameof(names));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        // Can be tedious to implement if object is "deep"
        public PersonWithDeepCopy DeepCopy()
        {
            return new PersonWithDeepCopy((string[]) Names.Clone(), Address.DeepCopy());
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(' ', Names)}, {nameof(Address)}: {Address}";
        }
    }
}