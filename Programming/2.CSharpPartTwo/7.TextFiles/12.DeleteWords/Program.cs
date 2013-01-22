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
            string[] words = File.ReadAllLines("../../words.txt"); // See exercise 6 for implementation

            using (StreamReader input = new StreamReader("../../input.txt"))
            using (StreamWriter output = new StreamWriter("../../output.txt"))
            {
                for (string line; (line = input.ReadLine()) != null; )
                {
                    // Remove each word
                    foreach (string word in words)
                        line = Regex.Replace(line, @"(\W|^)" + word + @"(\W|$)", "$1$2");

                    output.WriteLine(line);
                }
            }
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
