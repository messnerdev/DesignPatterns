namespace SOLID.InterfaceSegregation.Bad
{
    // Too many responsibilities for granular implementations
    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }
}
