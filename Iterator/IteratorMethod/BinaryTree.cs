using System.Collections.Generic;
using Iterator.IteratorObject;

namespace Iterator.IteratorMethod
{
    public class BinaryTree<T>
    {
        private Node<T> _root;

        public BinaryTree(Node<T> root)
        {
            _root = root;
        }

        public IEnumerable<Node<T>> InOrder
        {
            get
            {
                IEnumerable<Node<T>> Traverse(Node<T> current)
                {
                    if (current.Left != null)
                    {
                        foreach (Node<T> left in Traverse(current.Left))
                            yield return left;
                    }

                    yield return current;

                    if (current.Right != null)
                    {
                        foreach (Node<T> right in Traverse(current.Right))
                            yield return right;
                    }
                }

                foreach (Node<T> node in Traverse(_root))
                    yield return node;
            }
        }

        public InOrderIterator<T> GetEnumerator()
        {
            return new InOrderIterator<T>(_root);
        }
    }
}