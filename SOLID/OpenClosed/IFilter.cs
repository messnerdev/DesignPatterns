using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.OpenClosed
{
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }
}
