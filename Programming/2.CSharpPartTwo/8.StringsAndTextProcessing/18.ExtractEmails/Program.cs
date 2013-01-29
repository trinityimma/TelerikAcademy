using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string str = "Static void Main() nakov@telerik.com. using System,nakov@gmail.com return";

        foreach (var item in Regex.Matches(str, @"\w+@\w+\.\w+"))
            Console.WriteLine(item);
    }
}
