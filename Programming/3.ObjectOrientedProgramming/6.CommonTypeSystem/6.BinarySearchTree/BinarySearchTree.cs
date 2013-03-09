using System;

partial class BinarySearchTree<T>
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
        //Node current = this.root;

        //while (current != null)
        //{
        //    int compared = current.Key.CompareTo(key);

        //    if (compared == 0) break;

        //    else if (compared < 0) current = root.Left;
        //    else if (compared > 0) current = root.Right;
        //}

        //current = null;
    }

    public bool Find(T key)
    {
        Node current = this.root;

        while (current != null)
        {
            int compared = current.Key.CompareTo(key);

            if (compared == 0) return true;

            else if (compared < 0) current = root.Left;
            else if (compared > 0) current = root.Right;
        }

        return false;
    }
}
