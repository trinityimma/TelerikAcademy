// Declare two string variables and assign them with following value:
// The "use" of quotations causes difficulties.
// Do the above in two different ways: with and without using quoted strings.

using System;

class Program
{
    static void Main()
    {
        string strintWithQuotes = "The \"use\" of quotations causes difficulties.";
        string strintWithoutQuotes = "The \u0022use\u0022 of quotations causes difficulties.";
        Console.WriteLine(strintWithQuotes);
        Console.WriteLine(strintWithoutQuotes);
    }
}
