using System;

namespace Interpreter
{
    public class BinaryOperation : IElement
    {
        public Type MyType;
        public IElement Left, Right;

        public int Value
        {
            get
            {
                switch (MyType)
                {
                    case Type.Addition:
                        return Left.Value + Right.Value;
                    case Type.Subtraction:
                        return Left.Value - Right.Value;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public enum Type
        {
            Addition, Subtraction
        }
    }
}