using System;
using System.Collections.Generic;
using System.Text;
using Flyweight.TextFormatting;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            DeduplicatedStrings();
            TextFormatting();
        }

        private static void DeduplicatedStrings()
        {
            // See Tests
        }

        private static void TextFormatting()
        {
            var ft = new FormattedText("This is a brave new world");
            ft.Capitalize(10, 15);
            Console.WriteLine(ft);

            var bft = new BetterFormattedText("This is a brave new world");
            bft.GetRange(10, 15).Capitalize = true;
            Console.WriteLine(bft);
        }
    }
}
