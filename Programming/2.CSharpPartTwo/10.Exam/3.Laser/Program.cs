using System;

// TODO: Struct point
class Program
{
    static int width, height, depth;
    static int dirW, dirH, dirD;
    static int currentW, currentH, currentD;

    static bool[, ,] cube;

    static void PrintCube()
    {
#if DEBUG
        for (int h = 0; h < height; h++)
        {
            for (int d = 0; d < depth; d++)
                for (int w = 0; w < width; w++)
                    Console.Write((cube[w, h, d] ? 1 : 0) + (w == width - 1 ? "\n" : " "));

            Console.WriteLine();
        }
#endif
    }

    static void PrintPoint(int w, int h, int d)
    {
        Console.WriteLine("{0} {1} {2}", w + 1, h + 1, d + 1);
    }

    static bool IsInsideCube(int w, int h, int d)
    {
        return 0 <= w && w < cube.GetLength(0)
            && 0 <= h && h < cube.GetLength(1)
            && 0 <= d && d < cube.GetLength(2)
        ;
    }

    static void Input()
    {
        string[] dimensions = Console.ReadLine().Split();
        width  = int.Parse(dimensions[0]);
        height = int.Parse(dimensions[1]);
        depth  = int.Parse(dimensions[2]);

        cube = new bool[width, height, depth]; // Bool

        string[] start = Console.ReadLine().Split();
        currentW = int.Parse(start[0]) - 1;
        currentH = int.Parse(start[1]) - 1;
        currentD = int.Parse(start[2]) - 1;

        string[] dir = Console.ReadLine().Split();
        dirW = int.Parse(dir[0]);
        dirH = int.Parse(dir[1]);
        dirD = int.Parse(dir[2]);
    }

    static void BurnEdges()
    {
        for (int w = 0; w < width; w++)
        {
            cube[w, 0, 0] = true;
            cube[w, height - 1, 0] = true;
            cube[w, 0, depth - 1] = true;
            cube[w, height - 1, depth - 1] = true;
        }

        for (int h = 0; h < height; h++)
        {
            cube[0, h, 0] = true;
            cube[width - 1, h, 0] = true;
            cube[0, h, depth - 1] = true;
            cube[width - 1, h, depth - 1] = true;
        }

        for (int d = 0; d < depth; d++)
        {
            cube[0, 0, d] = true;
            cube[width - 1, 0, d] = true;
            cube[0, height - 1, d] = true;
            cube[width - 1, height - 1, d] = true;
        }
    }

    static void Start()
    {
        while (true)
        {
            int nextW = currentW + dirW;
            int nextH = currentH + dirH;
            int nextD = currentD + dirD;

            // Available - Go to next
            if (IsInsideCube(nextW, nextH, nextD))
            {
                // Not visited
                if (!cube[nextW, nextH, nextD])
                {
#if DEBUG
                    PrintPoint(currentW, currentH, currentD);
#endif
                    cube[currentW, currentH, currentD] = true; // Mark as visited

                    // Go to next
                    currentW = nextW;
                    currentH = nextH;
                    currentD = nextD;
                }

                // Visited - Break loop
                else break;
            }

            // Not available - Reflect
            else
            {
                if (!(0 <= nextW && nextW < width))  dirW = -dirW;
                if (!(0 <= nextH && nextH < height)) dirH = -dirH;
                if (!(0 <= nextD && nextD < depth))  dirD = -dirD;
            }
        }
    }

    static void Output()
    {
        PrintPoint(currentW, currentH, currentD);
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif
        Input();

        BurnEdges();

        PrintCube();

        Start();

        Output();
    }
}
