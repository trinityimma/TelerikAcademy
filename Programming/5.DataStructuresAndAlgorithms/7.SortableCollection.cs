namespace SortingHomework
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        private static readonly Random random = new Random();

        public SortableCollection()
            : this(Enumerable.Empty<T>())
        {
            return;
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get { return this.items; }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var el in this.items)
                if (item.Equals(el))
                    return true;

            return false;
        }

        public bool BinarySearch(T item)
        {
            for (int left = 0, right = this.items.Count - 1; left <= right; )
            {
                int middle = left + ((right - left) >> 1);

                if (this.items[middle].CompareTo(item) > 0)
                    left = middle + 1;

                else if (this.items[middle].CompareTo(item) < 0)
                    right = middle - 1;

                else return true;
            }

            return false;
        }

        public void Shuffle()
        {
            for (int i = this.items.Count - 1; i > 0; i--)
                this.Swap(i, random.Next(i + 1));
        }

        private void Swap(int i, int j)
        {
            T prev = this.items[i];
            this.items[i] = this.items[j];
            this.items[j] = prev;
        }

        public void PrintAllItemsOnConsole()
        {
            Console.WriteLine(string.Join(" ", this.items));
        }
    }
}
