using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class GenomeDecoder
{
    static int cols, cells;
    static string compressedGenome;

    static int lineNumberLength, rows;
    static StringBuilder genome = new StringBuilder();
    static StringBuilder output = new StringBuilder();

    static void Input()
    {
        string[] dimensions = Console.ReadLine().Split();
        cols = int.Parse(dimensions[0]);
        cells = int.Parse(dimensions[1]);
        compressedGenome = Console.ReadLine();
    }

    static void Extract()
    {
        foreach (Match gene in Regex.Matches(compressedGenome, @"(\d*)(\D)"))
        {
            char key = gene.Groups[2].Value[0];
            int value = String.IsNullOrEmpty(gene.Groups[1].Value) ? 1 : int.Parse(gene.Groups[1].Value);

            genome.Append(new String(key, value));
        }

        rows = (int)Math.Ceiling((double)genome.Length / cols);
        lineNumberLength = (int)Math.Log10(rows) + 1;
    }

    static void Format()
    {
        for (int row = 1, c = 0; row <= rows; row++)
        {
            output.Append(row.ToString().PadLeft(lineNumberLength));

            for (int col = 0; col < cols && c < genome.Length; col++)
            {
                if (col % cells == 0) output.Append(" ");

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
