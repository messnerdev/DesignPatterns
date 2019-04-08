using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.OpenClosed
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
}
