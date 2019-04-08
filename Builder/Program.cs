using System;
using System.Text;

namespace Builder
{
    partial class Program
    {
        static void Main(string[] args)
        {
            WithoutBuilder();
            WithBuilder();
            BuilderWithInheritance();
            FacetedBuilder();
        }

        static void WithoutBuilder()
        {
            var hello = "hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            Console.WriteLine(sb);

            var words = new[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");
            foreach (string word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }
            sb.Append("</ul>");
            Console.WriteLine(sb);
        }

        static void WithBuilder()
        {
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello");
            builder.AddChild("li", "world");
            Console.WriteLine(builder);

            // Fluent
            builder.Clear();
            builder.AddChild("li", "hello").AddChild("li", "world");
            Console.WriteLine(builder);

        }

        static void BuilderWithInheritance()
        {
            Person person = Person.New.Called("dmitri").WorksAsA("quant").Build();
            Console.WriteLine(person);
        }

        static void FacetedBuilder()
        {
            var pb = new ComplexPersonBuilder();
            ComplexPerson person = pb
                .Works.At("Intel").AsA("engineer").Earning(123000)
                .Lives.At("1234").In("Phoenix").WithPostCode("121");
        }

        public class ComplexPerson
        {
            // address
            public string StreetAddress, Postcode, City;

            // employment
            public string CompanyName, Position;
            public int AnnualIncome;

            public override string ToString()
            {
                return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
            }
        }

        // facade
        public class ComplexPersonBuilder
        {
            // reference!
            protected ComplexPerson person = new ComplexPerson();

            public ComplexPersonJobBuilder Works => new ComplexPersonJobBuilder(person);
            public ComplexPersonAddressBuilder Lives => new ComplexPersonAddressBuilder(person);

            public static implicit operator ComplexPerson (ComplexPersonBuilder pb)
            {
                return pb.person;
            }
        }

        public class ComplexPersonAddressBuilder : ComplexPersonBuilder
        {
            public ComplexPersonAddressBuilder(ComplexPerson person)
            {
                this.person = person;
            }

            public ComplexPersonAddressBuilder At(string streetAddress)
            {
                person.StreetAddress = streetAddress;
                return this;
            }

            public ComplexPersonAddressBuilder WithPostCode(string postCode)
            {
                person.Postcode = postCode;
                return this;
            }

            public ComplexPersonAddressBuilder In(string city)
            {
                person.City = city;
                return this;
            }
        }

        public class ComplexPersonJobBuilder : ComplexPersonBuilder
        {
            public ComplexPersonJobBuilder(ComplexPerson person)
            {
                this.person = person;
            }

            public ComplexPersonJobBuilder At(string companyName)
            {
                person.CompanyName = companyName;
                return this;
            }

            public ComplexPersonJobBuilder AsA(string position)
            {
                person.Position = position;
                return this;
            }

            public ComplexPersonJobBuilder Earning(int amount)
            {
                person.AnnualIncome = amount;
                return this;
            }
        }


    }
}
