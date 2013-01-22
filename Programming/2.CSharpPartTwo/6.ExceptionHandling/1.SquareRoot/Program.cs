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

        catch (ArgumentNullException)
        {
            Console.Error.WriteLine("Invalid number");
        }

        catch (FormatException)
        {
            Console.Error.WriteLine("Invalid number");
        }

        catch (OverflowException)
        {
            Console.Error.WriteLine("Invalid number");
        }

        finally
        {
            Console.WriteLine("Good bye!");
        }
    }
}
