using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

partial class BinarySearchTree<T> : ICloneable, IEnumerable<T>
    where T : IComparable<T>, IEquatable<T>
{
    private Node root = null;

    public void Add(T key)
    {
        if (root == null)
        {
            root = new Node(key);
            return;
        }

        Node current = this.root;

        while (true)
        {
            int compared = current.Key.CompareTo(key);

            if (compared == 0) break;

            else if (compared < 0)
            {
                if (current.Right == null)
                {
                    current.Right = new Node(key);
                    break;
                }

                current = current.Right;
            }

            else if (compared > 0)
            {
                if (current.Left == null)
                {
                    current.Left = new Node(key);
                    break;
                }

                current = current.Left;
            }
        }
    }

    public void Remove(T key)
    {
        Node node = this.root;

        while (node != null)
        {
            int compared = node.Key.CompareTo(key);

            if (compared == 0) break;

            else if (compared < 0) node = root.Left;
            else if (compared > 0) node = root.Right;
        }

        node = null;
    }

    public bool IndexOf(T key)
    {
        Node node = this.root;

        while (node != null)
        {
            int compared = node.Key.CompareTo(key);

            if (compared == 0) return true;

            else if (compared < 0) node = root.Left;
            else if (compared > 0) node = root.Right;
        }

        return false;
    }

    public static bool operator ==(BinarySearchTree<T> array1, BinarySearchTree<T> array2)
    {
        return BinarySearchTree<T>.Equals(array1, array2);
    }

    public static bool operator !=(BinarySearchTree<T> array1, BinarySearchTree<T> array2)
    {
        return !BinarySearchTree<T>.Equals(array1, array2);
    }

    private IEnumerable<T> Traverse(Node root)
    {
        if (root != null)
        {
            yield return root.Key;

            foreach (T item in Traverse(root.Left))
                yield return item;

            foreach (T item in Traverse(root.Right))
                yield return item;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return Traverse(root).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public object Clone()
    {
        BinarySearchTree<T> tree = new BinarySearchTree<T>();

        foreach (T item in tree)
            tree.Add(item);

        return tree;
    }

    public override int GetHashCode()
    {
        int hash = 17;

        unchecked
        {
            foreach (T item in this)
                hash += 23 * item.GetHashCode();
        }

        return hash;
    }

    public override bool Equals(object obj)
    {
        IEnumerator<T> tree1 = this.GetEnumerator();
        IEnumerator<T> tree2 = (obj as BinarySearchTree<T>).GetEnumerator();

        while (tree1.MoveNext() && tree2.MoveNext())
            if (!tree1.Current.Equals(tree2.Current))
                return false;

        return !tree1.MoveNext() && !tree2.MoveNext();
    }

    public override string ToString()
    {
        return String.Join<T>(" ", this);
    }
}
