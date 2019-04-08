using System;

namespace Prototype.CopyConstructor
{
    public class PersonWithCopyConstructor
    {
        public string[] Names;
        public AddressWithCopyConstructor Address;

        public PersonWithCopyConstructor(string[] names, AddressWithCopyConstructor address)
        {
            Names = names ?? throw new ArgumentNullException(nameof(names));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        // Copy constructor
        public PersonWithCopyConstructor(PersonWithCopyConstructor other)
        {
            Names = (string[]) other.Names.Clone();
            Address = new AddressWithCopyConstructor(other.Address);
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(' ', Names)}, {nameof(Address)}: {Address}";
        }
    }
}