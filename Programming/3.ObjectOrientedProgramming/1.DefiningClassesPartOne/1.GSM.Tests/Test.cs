using System;

namespace GSM.Tests
{
    public class Test
    {
        public static void Print(string heading, string body = null)
        {
            Console.WriteLine("# {0}", heading);

            if (!String.IsNullOrEmpty(body))
                Console.WriteLine(body);

            Console.WriteLine();
        }
    }
}
