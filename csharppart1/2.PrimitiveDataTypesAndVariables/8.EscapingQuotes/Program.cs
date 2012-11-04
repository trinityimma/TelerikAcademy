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
