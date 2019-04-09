using System.Collections.Generic;
using System.Linq;

namespace Facade
{
    // Facade
    public class MagicSquareGenerator
    {
        private Verifier _verifier = new Verifier();
        private Generator _generator = new Generator();
        private Splitter _splitter = new Splitter();

        public List<List<int>> Generate(int size)
        {
            List<List<int>> array;
            do
            {
                array = GenerateArray(size).ToList();
            } while (!IsMagic(array));

            return array;
        }

        private bool IsMagic(List<List<int>> array)
        {
            return _verifier.Verify(_splitter.Split(array));
        }

        private IEnumerable<List<int>> GenerateArray(int size)
        {
            for (int i = 0; i < size; i++)
            {
                yield return _generator.Generate(size);
            }
        }
    }
}