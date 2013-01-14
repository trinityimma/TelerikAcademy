using System;
using System.Threading;

// TODO: Learn OOP in C#
class Program
{
    // Variables
    static int[,] rocks = new int[15, 5]; // [N rocks][x, y, width, char, color index]
    static double result = 0;
    static int playerPositionX;
    static int playerPositionY;
    static bool collision;
    static double fps;

    // Constants
    static string player = "(O)";
    static string playerColor = "White";
    static char[] rockCharacters = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';' };
    static String[] rockColors = { "Green", "Yellow", "Red" };
    static int rockMaxWidth = 3;
    static int rockBottomPaddingAtStart = rockMaxWidth + player.Length;
    static string resultColor = "Gray";
    static int minFps = 15, maxFps = 40;
    static Random randomGenerator = new Random();

    static void PrintAtPosition(int x, int y, string s, string color)
    {
        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
        Console.SetCursorPosition(x, y);

        Console.Write(s);
    }

    static void CalculateFPS()
    {
        fps += collision ? -15 : .5;
        fps = Math.Min(Math.Max(fps, minFps), maxFps);
    }

    static void CalculateResult()
    {
        result += collision ? -5 : .1;
        result = Math.Max(result, 0);
    }

    static void CalculateCollision()
    {
        for (int i = 0; i < rocks.GetLength(0) && !collision; i++)
        {
            collision = rocks[i, 1] == playerPositionY &&
                rocks[i, 0] + rocks[i, 2] > playerPositionX && playerPositionX + player.Length > rocks[i, 0];
        }
    }

    static void DrawResult()
    {
        PrintAtPosition(0, 0, "Speed: " + (int)(fps - minFps) + " Result: " + (int)result, resultColor);
    }

    // Rocks
    static void GetRock(int i)
    {
        rocks[i, 2] = 1 + randomGenerator.Next(rockMaxWidth); // width
        rocks[i, 0] = randomGenerator.Next(Console.WindowWidth - rocks[i, 2] + 1); // x
        rocks[i, 1] = -1 + randomGenerator.Next(Console.WindowHeight - rockBottomPaddingAtStart); // y
        rocks[i, 3] = randomGenerator.Next(rockCharacters.Length); // char
        rocks[i, 4] = randomGenerator.Next(rockColors.Length); // color
    }

    static void MoveRockTop(int i)
    {
        GetRock(i);
        rocks[i, 1] = 0;
    }

    static void MoveRockDown(int i)
    {
        rocks[i, 1]++;
    }

    static void DrawRock(int i)
    {
        PrintAtPosition(rocks[i, 0], rocks[i, 1], new String(rockCharacters[rocks[i, 3]], rocks[i, 2]), rockColors[rocks[i, 4]]);
    }

    static bool IsRockVisible(int i)
    {
        return rocks[i, 1] < Console.WindowHeight;
    }

    static void InitRocks()
    {
        for (int i = 0; i < rocks.GetLength(0); i++) GetRock(i);
    }

    static void MoveRocks()
    {
        for (int i = 0; i < rocks.GetLength(0); i++)
        {
            MoveRockDown(i);

            if (!IsRockVisible(i)) MoveRockTop(i);
        }
    }

    static void DrawRocks()
    {
        for (int i = 0; i < rocks.GetLength(0); i++) DrawRock(i);
    }

    // Player
    static void CenterPlayer()
    {
        playerPositionX = (Console.WindowWidth - player.Length) / 2;
        playerPositionY = Console.WindowHeight - 1;
    }

    static void DrawPlayer()
    {
        PrintAtPosition(playerPositionX, playerPositionY, player, playerColor);
    }

    static void MovePlayer(ConsoleKeyInfo keyInfo)
    {
        if (keyInfo.Key == ConsoleKey.LeftArrow && playerPositionX > 0) playerPositionX--;
        if (keyInfo.Key == ConsoleKey.RightArrow && playerPositionX + player.Length - 1 < Console.WindowWidth - 1) playerPositionX++;

        if (keyInfo.Key == ConsoleKey.UpArrow && playerPositionY > 0) playerPositionY--;
        if (keyInfo.Key == ConsoleKey.DownArrow && playerPositionY < Console.WindowHeight - 1) playerPositionY++;
    }

    static void Main()
    {
        CenterPlayer();
        InitRocks();
        while (true)
        {
            collision = false;

            if (Console.KeyAvailable) MovePlayer(Console.ReadKey());
            MoveRocks();

            CalculateCollision();
            CalculateResult();
            CalculateFPS();

            Console.Clear();

            DrawPlayer();
            DrawRocks();
            DrawResult();

            Thread.Sleep(1000 / (int)fps);
        }
    }
}
