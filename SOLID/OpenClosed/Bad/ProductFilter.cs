using System.Collections.Generic;
using System.Linq;

namespace SOLID.OpenClosed.Bad
{
    public class ProductFilter
    {
        public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            return products.Where(x => x.Size == size);
        }

        public static IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            return products.Where(x => x.Color == color);
        }

        #region Violates Open-Closed Priciple
        public static IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
        {
            return products.Where(x => x.Color == color && x.Size == size);
        }
        #endregion
    }
}
