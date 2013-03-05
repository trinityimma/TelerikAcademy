using System;

class Program
{
    static void Main()
    {
        {
            try
            {
                int start = 1;
                int end = 100;

                int x = 200;

                if (!(start < x && x < end))
                    throw new InvalidRangeException<int>(start, end);
            }

            catch (InvalidRangeException<int> e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Start: {0}; End {1};", e.Start, e.End);
            }
        }

        Console.WriteLine();

        {
            try
            {
                DateTime start = new DateTime(1980, 1, 1);
                DateTime end = new DateTime(2013, 12, 31);

                DateTime x = DateTime.MinValue;

                if (!(start < x && x < end))
                    throw new InvalidRangeException<DateTime>(start, end);
            }

            catch (InvalidRangeException<DateTime> e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Start: {0}; End {1};", e.Start, e.End);
            }
        }
    }
}
