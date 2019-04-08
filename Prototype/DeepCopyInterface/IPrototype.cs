namespace Prototype
{
    public interface IPrototype<T>
    {
        T DeepCopy();
    }
}