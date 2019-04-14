using System;
using System.Linq;
using Iterator.IteratorObject;
using Iterator.IteratorMethod;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            //    1
            //   / \
            //  2   3

            // in-order: 213
            IteratorObjectExample();
            IteratorMethodExample();
            IteratorDuckTypingExample();
        }

        private static void IteratorObjectExample()
        {
            var root = new Node<int>(1, new Node<int>(2), new Node<int>(3));
            var it = new InOrderIterator<int>(root);
            while (it.MoveNext())
            {
                Console.Write($"{it.Current.Value},");
            }
            Console.WriteLine();
        }

        private static void IteratorMethodExample()
        {
            var root = new Node<int>(1, new Node<int>(2), new Node<int>(3));
            var tree = new BinaryTree<int>(root);
            Console.WriteLine(string.Join(',', tree.InOrder.Select(x => x.Value)));
        }

        private static void IteratorDuckTypingExample()
        {
            var root = new Node<int>(1, new Node<int>(2), new Node<int>(3));
            var tree = new BinaryTree<int>(root);
            foreach (Node<int> node in tree)
                Console.WriteLine(node.Value);
        }

        private static void ArrayBacking()
        {
            // See Creature
        }
    }
}
