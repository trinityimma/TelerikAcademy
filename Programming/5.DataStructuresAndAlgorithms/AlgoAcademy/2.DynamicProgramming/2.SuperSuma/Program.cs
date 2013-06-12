using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static Dictionary<Tuple<int, int>, int> dp = new Dictionary<Tuple<int, int>, int>();

    static int SuperSum(int k, int n)
    {
        var kn = new Tuple<int, int>(k, n);

        if (dp.ContainsKey(kn))
            return dp[kn];

        if (k == 0)
            return n;

        return dp[kn] = Enumerable.Range(1, n).Select(i => SuperSum(k - 1, i)).Sum();
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine(SuperSum(input[0], input[1]));
    }
}
