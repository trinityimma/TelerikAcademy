using System;

class Program
{
    static void Main()
    {
        GenericList<int> list = new GenericList<int>();

        {
            Console.WriteLine("# Auto grow/shrink");

            for (int i = 0; i < 20; i++)
            {
                list.Add(i);

                Console.WriteLine("Count: {0}, Capacity: {1}", list.Count, list.Capacity);
            }

            for (int i = 0; i < 15; i++)
            {
                list.Remove(list.Count - 1);

                Console.WriteLine("Count: {0}, Capacity: {1}", list.Count, list.Capacity);
            }

            Console.WriteLine();
        }

        {
            Console.WriteLine("# List is");

            Console.WriteLine(list);

            Console.WriteLine();
        }

        {
            Console.WriteLine("Min: {0}", list.Min());
            Console.WriteLine("Max: {0}", list.Max());

            Console.WriteLine();
        }

        {
            Console.WriteLine("# Indexer");

            Console.WriteLine(list[2]);

            Console.WriteLine();
        }

        {
            Console.WriteLine("# Remove element");

            list.Remove(3);

            Console.WriteLine(list);
            Console.WriteLine();
        }

        {
            Console.WriteLine("# Add element");

            list.Insert(list.Count, 10);

            Console.WriteLine(list);
            Console.WriteLine();
        }

        {
            Console.WriteLine("# Index of");
            Console.WriteLine(list.IndexOf(4));
            Console.WriteLine();
        }

        {
            Console.WriteLine("# Clear");

            list.Clear();

            Console.WriteLine(list);
        }
    }
}
