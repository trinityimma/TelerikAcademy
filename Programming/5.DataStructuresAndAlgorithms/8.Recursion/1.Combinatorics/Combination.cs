using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class Combination<T> : IEnumerable<IEnumerable<T>>
{
    private readonly IList<T> elements = null;

    private readonly IList<int> indices = null;

    private readonly int n = 0;

    public Combination(IEnumerable<T> elements, int n)
    {
        this.elements = elements.ToArray();
        this.n = n;

        this.indices = new int[n];
    }

    private IEnumerable<IEnumerable<T>> Generate(int start, int next)
    {
        if (start == this.indices.Count)
        {
            yield return this.indices.Select(x => this.elements[x]);
        }
        else
        {
            for (int i = next; i < this.elements.Count; i++)
            {
                this.indices[start] = i;

                foreach (var item in this.Generate(start + 1, i + 1))
                    yield return item;
            }
        }
    }

    public IEnumerator<IEnumerable<T>> GetEnumerator()
    {
        return this.Generate(0, 0).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
