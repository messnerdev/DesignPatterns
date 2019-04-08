using System.Collections.Generic;

namespace Singleton.Tests
{
    public class TestDatabase : IDatabase
    {
        private readonly Dictionary<string, int> _data = new Dictionary<string, int>()
        {
            ["alpha"] = 1,
            ["beta"] = 2,
            ["gamma"] = 3
        };

        public int GetPopulation(string city)
        {
            return _data[city];
        }
    }
}