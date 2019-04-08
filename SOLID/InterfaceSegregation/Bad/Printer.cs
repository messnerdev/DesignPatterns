using System;

namespace SOLID.InterfaceSegregation.Bad
{
    public class Printer : IMachine
    {
        public void Print(Document d)
        {
            Console.WriteLine($"{nameof(Print)}");
        }

        #region Violates Interface Segregation, we don't want implementations that aren't fully implemented 
        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }

        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
