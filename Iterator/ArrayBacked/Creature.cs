using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Iterator.ArrayBacked
{
    public class Creature : IEnumerable<int>
    {
        private readonly int[] _stats = new int[3];
        private static int strengthIndex = 0;
        private static int agilityIndex = 1;
        private static int intelligenceIndex = 2;

        public int Strength
        {
            get => _stats[strengthIndex];
            set => _stats[strengthIndex] = value;
        }

        public int Agility
        {
            get => _stats[agilityIndex];
            set => _stats[agilityIndex] = value;
        }

        public int Intelligence
        {
            get => _stats[intelligenceIndex];
            set => _stats[intelligenceIndex] = value;
        }

        //public double AverageStat => (Strength + Agility + Intelligence) / 3.0;

        public double AverageStat => _stats.Average();
        public IEnumerator<int> GetEnumerator()
        {
            return _stats.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _stats.GetEnumerator();
        }

        public int this[int index]
        {
            get => _stats[index];
            set => _stats[index] = value;
        }
    }
}