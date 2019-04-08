using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.InterfaceSegregation
{
    // Decorator pattern
    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private IPrinter printer;
        private IScanner scanner;
        private IFaxer faxer;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner, IFaxer faxer)
        {
            this.printer = printer ?? throw new ArgumentNullException(paramName: nameof(printer));
            this.scanner = scanner ?? throw new ArgumentNullException(paramName: nameof(scanner));
            this.faxer = faxer ?? throw new ArgumentNullException(paramName: nameof(faxer));
        }

        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Fax(Document d)
        {
            faxer.Fax(d);
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
        }
    }
}
