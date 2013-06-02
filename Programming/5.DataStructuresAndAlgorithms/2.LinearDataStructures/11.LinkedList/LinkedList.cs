using System;
using System.Collections;
using System.Collections.Generic;

class LinkedList<T> : IEnumerable<T>
{
    public Node<T> First { get; private set; }
    public Node<T> Last { get; private set; }

    public int Count { get; private set; }

    public void AddFirst(T value)
    {
        this.Count++;

        var node = new Node<T>(value);

        if (this.First == null)
        {
            this.First = this.Last = node;
        }
        else
        {
            node.Next = this.First;

            this.First.Previous = node;
            this.First = node;
        }
    }

    public Node<T> RemoveFirst()
    {
        if (this.First == null)
            return null;

        this.Count--;

        var first = this.First;

        // The list contains only one node
        if (this.First.Next == null)
        {
            this.Clear();
        }
        else
        {
            this.First = this.First.Next;
            this.First.Previous = null;
        }

        first.Next = first.Previous = null;
        return first;
    }

    public void AddLast(T value)
    {
        this.Count++;

        var node = new Node<T>(value);

        if (this.Last == null)
        {
            this.First = this.Last = node;
        }
        else
        {
            node.Previous = this.Last;

            this.Last.Next = node;
            this.Last = node;
        }
    }

    public Node<T> RemoveLast()
    {
        if (this.Last == null)
            return null;

        this.Count--;

        var last = this.Last;

        // The list contains only one node
        if (this.Last.Previous == null)
        {
            this.Clear();
        }
        else
        {
            this.Last = this.Last.Previous;
            this.Last.Next = null;
        }

        last.Next = last.Previous = null;
        return last;
    }

    public void Clear()
    {
        this.First = this.Last = null;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var current = this.First; current != null; current = current.Next)
            yield return current.Value;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public override string ToString()
    {
        return string.Join(" <-> ", this);
    }
}
