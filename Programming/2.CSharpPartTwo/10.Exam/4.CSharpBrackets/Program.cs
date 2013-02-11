using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static int totalLines;
    static string indentationString;
    static List<string> unformattedCode;

    static List<string> formattedCode;

    static void Input()
    {
        totalLines = int.Parse(Console.ReadLine());
        indentationString = Console.ReadLine();

        unformattedCode = new List<string>(totalLines);
        formattedCode = new List<string>(totalLines);

        for (int i = 0; i < totalLines; i++)
            unformattedCode.Add(Console.ReadLine());
    }

    static string Trim(string line)
    {
        return Regex.Replace(line.TrimStart(), " +", " ");
    }

    static string MakeLine(string text, int level)
    {
        StringBuilder line = new StringBuilder();

        for (int i = 0; i < level; i++)
            line.Append(indentationString);

        line.Append(text);

        return line.ToString();
    }

    static void FormatCode()
    {
        int stack = 0;

        // Read line by line
        foreach (string line in unformattedCode)
        {
            // Read char by char
            for (int i = 0; i < line.Length; i++)
            {
                // Start new line for each bracket
                if (line[i] == '{')
                    formattedCode.Add(MakeLine("{", stack++));

                else if (line[i] == '}')
                    formattedCode.Add(MakeLine("}", --stack));

                // Else add contents to a new line
                else
                {
                    StringBuilder codeBuilder = new StringBuilder();

                    while (i < line.Length && line[i] != '{' && line[i] != '}')
                        codeBuilder.Append(line[i++]);

                    i--; // Go back one char

                    string code = codeBuilder.ToString();

                    // Skip empty lines
                    // See input3.txt - It has trailing spaces after the last bracket
                    if (!String.IsNullOrWhiteSpace(code))
                        formattedCode.Add(MakeLine(Trim(code), stack));
                }
            }
        }
    }

    static void Output()
    {
        foreach (string line in formattedCode)
            Console.WriteLine(line);
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input3.txt"));
#endif
        Input();

        FormatCode();

        Output();
    }
}
