using System.Collections.Generic;
using System.Linq;

namespace Singleton
{
    public class ProductionRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            // Hard-coded reference to the REAL database instance.
            // Not very testable
            // Downside of defining class as Singleton
            return names.Sum(name => SingletonDatabase.Instance.GetPopulation(name));
        }
    }
}