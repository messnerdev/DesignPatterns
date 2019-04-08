using System;
using System.Collections.Generic;
using System.Linq;

namespace Singleton
{
    public class ConfigurableRecordFinder
    {
        private readonly IDatabase _database;

        // Able to inject dummy database for testing
        public ConfigurableRecordFinder(IDatabase database)
        {
            this._database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public int GetTotalPopulation(IEnumerable<string> names)
        {
            return names.Sum(name => _database.GetPopulation(name));
        }
    }
}