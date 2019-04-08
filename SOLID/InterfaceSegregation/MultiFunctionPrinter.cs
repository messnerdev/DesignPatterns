using System;
using System.Collections.Generic;
using System.Text;
using SOLID.InterfaceSegregation.Bad;

namespace SOLID.InterfaceSegregation
{
    public class MultiFunctionPrinter : IMachine
    {
        public void Print(Document d)
        {
            Console.WriteLine($"{nameof(Print)}");
        }

        public void Scan(Document d)
        {
            Console.WriteLine($"{nameof(Scan)}");
        }

        public void Fax(Document d)
        {
            Console.WriteLine($"{nameof(Fax)}");
        }
    }
}
