using System;
using System.Globalization;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string str = "Static void Main() 12.10.2012, 50.13.2012";

        foreach (Match item in Regex.Matches(str, @"\b[0-9]{2}.[0-9]{2}.[0-9]{4}\b"))
        {
            DateTime date;

            if (DateTime.TryParse(item.Value, out date))
                Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
        }
    }
}
