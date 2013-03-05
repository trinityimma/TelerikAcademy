using System;
using System.Threading;

class Program
{
    static void SetInterval(Action f, int t)
    {
        while (true)
        {
            Thread.Sleep(t * 1000);

            f();
        }
    }

    static void Main()
    {
        SetInterval(new Action(() =>
            Console.WriteLine(DateTime.Now)
        ), 1);
    }
}
