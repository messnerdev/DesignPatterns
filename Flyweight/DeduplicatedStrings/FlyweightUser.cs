using System.Collections.Generic;
using System.Linq;

namespace Flyweight.DeduplicatedStrings
{
    public class FlyweightUser
    {
        // Use of list here is inefficient, but provides the best direct comparison between User in terms of memory storage 
        private static readonly List<string> Strings = new List<string>();
        private readonly int[] _names;

        public FlyweightUser(string fullName)
        {
            int GetOrAdd(string s)
            {
                int index = Strings.IndexOf(s);
                if (index != -1)
                    return index;
                else
                {
                    Strings.Add(s);
                    return Strings.Count - 1;
                }
            }

            _names = fullName.Split(' ').Select(GetOrAdd).ToArray();
        }

        public string FullName => string.Join(' ', _names.Select(i => Strings[i]));
    }
}