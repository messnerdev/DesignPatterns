using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.InterfaceSegregation
{
    public class PhotoCopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            Console.WriteLine($"{nameof(Print)}");
        }

        public void Scan(Document d)
        {
            Console.WriteLine($"{nameof(Scan)}");
        }
    }
}
