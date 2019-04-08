using System;
using System.Net.Sockets;
using Prototype.Bad;
using Prototype.CopyConstructor;
using Prototype.CopyThroughSerialization;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(nameof(BadExampleReferenceEquality));
            BadExampleReferenceEquality();

            Console.WriteLine(nameof(BadExampleICloneable));
            BadExampleICloneable();

            Console.WriteLine(nameof(CopyConstructorExample));
            CopyConstructorExample();

            Console.WriteLine(nameof(DeepCopyInterfaceExample));
            DeepCopyInterfaceExample();

            Console.WriteLine(nameof(CopyThroughBinarySerialization));
            CopyThroughBinarySerialization();

            Console.WriteLine(nameof(CopyThroughXmlSerialization));
            CopyThroughXmlSerialization();
        }

        public static void BadExampleReferenceEquality()
        {
            var john = new CloneablePerson(new[] { "John", "Smith" }, new CloneableAddress("London Rd", 123));
            // Reference equality, jane AND john will change!
            var jane = john;
            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 456;

            Console.WriteLine(john);
            Console.WriteLine(jane);
        }

        public static void BadExampleICloneable()
        {
            // ICloneable is often not a great solution because it is often unclear if it is a shallow clone or deep clone
            // ICloneable also returns object which can be annoying to constantly cast
            var john = new CloneablePerson(new[] { "John", "Smith" }, new CloneableAddress("London Rd", 123));
            var jane = (CloneablePerson)john.Clone();
            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 456;

            Console.WriteLine(john);
            Console.WriteLine(jane);
        }

        public static void CopyConstructorExample()
        {
            var john = new PersonWithCopyConstructor(new[] { "John", "Smith" }, new AddressWithCopyConstructor("London Rd", 123));
            var jane = new PersonWithCopyConstructor(john);

            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 456;

            Console.WriteLine(john);
            Console.WriteLine(jane);
        }

        public static void DeepCopyInterfaceExample()
        {
            var john = new PersonWithDeepCopy(new[] { "John", "Smith" }, new AddressWithDeepCopy("London Rd", 123));
            var jane = john.DeepCopy();

            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 456;

            Console.WriteLine(john);
            Console.WriteLine(jane);
        }

        public static void CopyThroughBinarySerialization()
        {
            var john = new Person(new[] { "John", "Smith" }, new Address("London Rd", 123));
            var jane = john.DeepCopy();

            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 456;

            Console.WriteLine(john);
            Console.WriteLine(jane);
        }

        public static void CopyThroughXmlSerialization()
        {
            var john = new Person(new[] { "John", "Smith" }, new Address("London Rd", 123));
            var jane = john.DeepCopyXml();

            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 456;

            Console.WriteLine(john);
            Console.WriteLine(jane);
        }
    }
}
