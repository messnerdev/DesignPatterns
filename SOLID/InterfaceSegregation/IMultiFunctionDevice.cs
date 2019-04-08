using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.InterfaceSegregation
{
    public interface IMultiFunctionDevice : IPrinter, IScanner, IFaxer
    {
    }
}
