using System;

namespace Prototype.CopyThroughSerialization
{
    [Serializable]
    public class Person
    {
        public string[] Names;
        public Address Address;

        public Person()
        {
            
        }

        public Person(string[] names, Address address)
        {
            Names = names ?? throw new ArgumentNullException(nameof(names));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(' ', Names)}, {nameof(Address)}: {Address}";
        }
    }
}