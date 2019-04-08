using System;

namespace Prototype.Bad
{
    public class CloneablePerson : ICloneable
    {
        public string[] Names;
        public CloneableAddress Address;

        public CloneablePerson(string[] names, CloneableAddress address)
        {
            Names = names ?? throw new ArgumentNullException(nameof(names));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(' ', Names)}, {nameof(Address)}: {Address}";
        }

        public object Clone()
        {
            return new CloneablePerson((string[])Names.Clone(), (CloneableAddress)Address.Clone());
        }
    }
}