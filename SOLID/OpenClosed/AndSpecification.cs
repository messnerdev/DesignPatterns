﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOLID.OpenClosed
{
    public class AndSpecification<T> : ISpecification<T>
    {
        private readonly IEnumerable<ISpecification<T>> specifications;

        public AndSpecification(params ISpecification<T>[] specifications)
        {
            if (specifications.Any(x => x == null))
                throw  new ArgumentNullException($"One or more {nameof(ISpecification<T>)} in {nameof(specifications)} was null");

            this.specifications = specifications;
        }

        public bool IsSatisfied(T t)
        {
            return specifications.All(x => x.IsSatisfied(t));
        }
    }
}
