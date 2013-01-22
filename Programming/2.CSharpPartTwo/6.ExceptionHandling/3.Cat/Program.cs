using System;
using System.IO;
using System.Security;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine(File.ReadAllText(@"C:\Windows\win.ini"));
        }

        catch (ArgumentNullException)
        {
            Console.Error.WriteLine("Path is null.");
        }

        catch (ArgumentException)
        {
            Console.Error.WriteLine("Path is a zero-length string, contains only white space, or contains one or more invalid characters.");
        }

        catch (PathTooLongException)
        {
            Console.Error.WriteLine("The specified path, file name, or both exceed the system-defined maximum length.");
        }

        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("The specified path is invalid.");
        }

        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("The file specified in path was not found.");
        }

        catch (IOException)
        {
            Console.Error.WriteLine("An I/O error occurred while opening the file.");
        }

        catch (UnauthorizedAccessException)
        {
            Console.Error.WriteLine("The caller does not have the required permission.");
        }

        catch (NotSupportedException)
        {
            Console.Error.WriteLine("Path is in an invalid format.");
        }

        catch (SecurityException)
        {
            Console.Error.WriteLine("The caller does not have the required permission.");
        }
    }
}
