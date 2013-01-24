using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string str = "Static void Main() jasssonpet@gmail.com. using System,jason@abv.bg return";

        foreach (var item in Regex.Matches(str, @"\b\w+@\w+\.\w+\b"))
            Console.WriteLine(item);
    }
}
