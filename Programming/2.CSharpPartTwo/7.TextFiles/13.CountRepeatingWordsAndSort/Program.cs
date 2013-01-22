using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Security;

class Program
{
    static void Main()
    {
        try
        {
            string[] words = System.IO.File.ReadAllLines("../../words.txt"); // See exercise 6 for implementation
            int[] values = new int[words.Length];

            using (StreamReader input = new StreamReader("../../input.txt"))
                for (string line; (line = input.ReadLine()) != null; )
                    for (int i = 0; i < words.Length; i++)
                        values[i] += Regex.Matches(line, @"(\W|^)" + words[i] + @"(\W|$)").Count;

            Array.Sort(values, words);

            using (StreamWriter output = new StreamWriter("../../output.txt"))
                for (int i = 0; i < words.Length; i++)
                    output.WriteLine("{0}: {1}", words[i], values[i]);
        }

        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (SecurityException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
