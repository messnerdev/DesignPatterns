namespace Iterator.IteratorObject
{
    // C++ Style, no need to make it so complicated in C#
    public class InOrderIterator<T>
    {
        private readonly Node<T> _root;
        public Node<T> Current { get; set; }
        private bool _yieldedStart;

        public InOrderIterator(Node<T> root)
        {
            _root = root;
            Current = root;

            while (Current.Left != null)
                Current = Current.Left;
        }

        public bool MoveNext()
        {
            if (!_yieldedStart)
            {
                _yieldedStart = true;
                return true;
            }

            if (Current.Right != null)
            {
                Current = Current.Right;
                while (Current.Left != null)
                    Current = Current.Left;

                return true;
            }

            Node<T> parent = Current.Parent;
            while (parent != null && Current == parent.Right)
            {
                Current = parent;
                parent = parent.Parent;
            }
            Current = parent;
            return Current != null;
        }

        public void Reset() {
            Current = _root;
            _yieldedStart = false;
        }
    }
}