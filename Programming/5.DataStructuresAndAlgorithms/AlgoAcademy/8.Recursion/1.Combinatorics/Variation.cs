using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class Variation<T> : IEnumerable<IEnumerable<T>>
{
    private readonly IList<T> elements = null;

    private readonly IList<int> indices = null;

    public Variation(IEnumerable<T> elements)
    {
        this.elements = elements.ToArray();

        this.indices = new int[this.elements.Count];
    }

    private IEnumerable<IEnumerable<T>> Generate(int start)
    {
        if (start == this.indices.Count)
        {
            yield return this.indices.Select(i => this.elements[i]);
        }
        else
        {
            for (int i = 0; i < this.indices.Count; i++)
            {
                this.indices[start] = i;

                foreach (var item in this.Generate(start + 1))
                    yield return item;
            }
        }
    }

    public IEnumerator<IEnumerable<T>> GetEnumerator()
    {
        return this.Generate(0).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
