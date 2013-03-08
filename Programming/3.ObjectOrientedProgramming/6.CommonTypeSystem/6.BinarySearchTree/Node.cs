using System;

partial class BinarySearchTree<T>
{
    private class Node
    {
        public T Key { get; private set; }

        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(T key)
        {
            this.Key = key;
        }
    }
}
