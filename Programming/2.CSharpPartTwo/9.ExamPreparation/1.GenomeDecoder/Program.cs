using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class GenomeDecoder
{
    static int lineSize, groupSize, lineNumberLength, numberOfLines;
    static StringBuilder genome = new StringBuilder();
    static StringBuilder output = new StringBuilder();

    static void Input()
    {
        string[] dimensions = Console.ReadLine().Split();
        lineSize = int.Parse(dimensions[0]);
        groupSize = int.Parse(dimensions[1]);
    }

    static void Extract()
    {
        foreach (Match gene in Regex.Matches(Console.ReadLine(), @"(\d*)(\D)"))
        {
            char key = gene.Groups[2].Value[0];
            int value = String.IsNullOrEmpty(gene.Groups[1].Value) ? 1 : int.Parse(gene.Groups[1].Value);

            genome.Append(new String(key, value));
        }

        numberOfLines = (int)Math.Ceiling((double)genome.Length / lineSize);
        lineNumberLength = (int)Math.Log10(numberOfLines) + 1;
    }

    static void Format()
    {
        for (int lineNumber = 1, c = 0; lineNumber <= numberOfLines; lineNumber++)
        {
            output.Append(lineNumber.ToString().PadLeft(lineNumberLength));

            for (int i = 0; i < lineSize && c < genome.Length; i++)
            {
                if (i % groupSize == 0) output.Append(" ");

                output.Append(genome[c++]);
            }

            output.AppendLine();
        }
    }

    static void Output()
    {
        Console.Write(output);
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new StreamReader("../../input.txt"));
#endif

        Input();

        Extract();

        Format();

        Output();
    }
}
