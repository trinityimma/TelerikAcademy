using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public string Name { get; private set; }
    public int Weight { get; private set; }
    public int Price { get; private set; }

    public Product(string name, int weight, int price)
    {
        this.Name = name;
        this.Weight = weight;
        this.Price = price;
    }

    public override string ToString()
    {
        return string.Format("Name: {0}, Weight: {1}, Price: {2}", this.Name, this.Weight, this.Price);
    }
}

class Program
{
    static void Main()
    {
        var numbers = new[]
        {
            new Product("beer", 3, 2),
            new Product("vodka", 8, 12),
            new Product("cheese", 4, 5),
            new Product("nuts", 1, 4),
            new Product("ham", 2, 3),
            new Product("whiskey", 8, 13),
        };

        int capacity = 10;

        var best = Enumerable.Repeat(1, numbers.Length).ToArray();
        var parents = Enumerable.Repeat(-1, numbers.Length).ToArray();

        var bestLength = 1;
        var bestEnd = 0;

        for (int i = 0; i < capacity; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (numbers[i] > numbers[j] && best[j] + 1 > best[i])
                {
                    best[i] = best[j] + 1;
                    parents[i] = j;
                }

                if (bestLength < best[i])
                {
                    bestLength = best[i];
                    bestEnd = i;
                }
            }
        }

        var sequence = new Stack<int>();

        for (; bestEnd != -1; bestEnd = parents[bestEnd])
        {
            sequence.Push(numbers[bestEnd]);
        }

        Console.WriteLine(string.Join(" ", sequence));

        Console.WriteLine(string.Join(" ", numbers));
        Console.WriteLine(string.Join(" ", best));
        Console.WriteLine(string.Join(" ", parents));
    }
}
