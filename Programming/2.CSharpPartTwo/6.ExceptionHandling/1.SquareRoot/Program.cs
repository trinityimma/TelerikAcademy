using System;

class Program
{
    static void Main()
    {
        try
        {
            int n = int.Parse(Console.ReadLine());

            if (n < 0) throw new FormatException();

            Console.WriteLine(Math.Sqrt(n));
        }

        catch (Exception)
        {
            Console.WriteLine("Invalid number");
        }

        finally
        {
            Console.WriteLine("Good bye!");
        }
    }
}
