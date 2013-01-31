using System;

class Program
{
    static void Main()
    {
        try
        {
            uint n = uint.Parse(Console.ReadLine());

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
