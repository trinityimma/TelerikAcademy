using System;
using System.Threading;

static class FuncExtensions
{
    public static void SetInterval(this Action f, int t)
    {
        while (true)
        {
            Thread.Sleep(t * 1000);

            f();
        }
    }
}

class Program
{
    static void Main()
    {
        ((Action)(() => Console.WriteLine(DateTime.Now))).SetInterval(1);
    }
}
