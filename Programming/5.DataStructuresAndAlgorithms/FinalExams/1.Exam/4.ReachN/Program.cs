using System;
using System.Linq;
using Wintellect.PowerCollections;
using State = System.Collections.Generic.KeyValuePair<long, long>;

class Program
{
    static long Pow(long n, long power)
    {
        long result = 1;

        for (long i = 0; i < power; i++)
            result *= n;

        return result;
    }

    static long Calc(long n)
    {
        if (n == 1)
            return 0;

        var queue = new OrderedBag<State>((pair1, pair2) =>
            pair1.Value.CompareTo(pair2.Value)
        );

        queue.Add(new State(n, 0));

        while (queue.Count != 0)
        {
            var currentState = queue.RemoveFirst();

            if (currentState.Key == 1)
                return currentState.Value;

            for (int power = 2; power < 60; power++)
            {
                var powerBase = Math.Pow(currentState.Key, 1.0 / power);

                var nextNumber = (long)Math.Round(powerBase);
                var nextSteps = Math.Abs(Pow(nextNumber, power) - currentState.Key);

                var nextState = new State(nextNumber, currentState.Value + nextSteps + 1);
                queue.Add(nextState);
            }
        }

        throw new ArgumentException();
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var input = Enumerable.Range(0, 4)
            .Select(i => long.Parse(Console.ReadLine()))
            .ToArray();

        foreach (var i in input)
            Console.WriteLine(Calc(i));
    }
}
