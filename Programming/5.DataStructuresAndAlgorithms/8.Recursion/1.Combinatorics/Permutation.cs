using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class Permutation<T> : IEnumerable<IEnumerable<T>>
{
    private readonly IList<T> elements = null;

    private readonly IList<int> indices = null;

    private readonly IList<bool> used = null;

    public Permutation(IEnumerable<T> elements)
    {
        this.elements = elements.ToArray();

        this.indices = new int[this.elements.Count];
        this.used = new bool[this.elements.Count];
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
                if (this.used[i]) continue;

                this.indices[start] = i;

                this.used[i] = true;

                foreach (var item in this.Generate(start + 1))
                    yield return item;

                this.used[i] = false;
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
