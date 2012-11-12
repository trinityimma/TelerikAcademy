using System;
using System.Threading;

// TODO: Learn OOP in C#
class Program
{
    static int playerPosition = 0;
    static bool collision = false;
    static int result = 0;

    static string player = "(0)";
    static int[,] rocks = new int[15, 4]; // [N rocks][x, y, width, char]
    static char[] rockCharacters = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';' };
    static int rockMaxWidth = 3;
    static int rockBottomPaddingAtStart = 4;
    static int fps = 20;
    static Random randomGenerator = new Random();

    static void PrintAtPosition(int x, int y, string s)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(s);
    }

    static void GetRock(int i)
    {
        rocks[i, 2] = 1 + randomGenerator.Next(rockMaxWidth); // width
        rocks[i, 3] = randomGenerator.Next(rockCharacters.Length); // char
        rocks[i, 0] = randomGenerator.Next(Console.WindowWidth - rocks[i, 2] + 1); // x
        rocks[i, 1] = -1 + randomGenerator.Next(Console.WindowHeight - rockBottomPaddingAtStart); // y
    }

    static bool CheckCollision(int x, int y, int l)
    {
        return y == Console.WindowHeight - 1 && x + l > playerPosition && playerPosition + player.Length > x;
    }

    static void SetInitialPositions()
    {
        playerPosition = (Console.WindowWidth - player.Length) / 2;
        for (int i = 0; i < rocks.GetLength(0); i++) GetRock(i);
    }

    static void MovePlayer(ConsoleKeyInfo keyInfo)
    {
        if (keyInfo.Key == ConsoleKey.LeftArrow && playerPosition > 0) playerPosition--;
        if (keyInfo.Key == ConsoleKey.RightArrow && playerPosition + player.Length < Console.WindowWidth) playerPosition++;
    }

    static void DrawPlayer()
    {
        PrintAtPosition(playerPosition, Console.WindowHeight - 1, player);
    }

    static void DrawEnviroment()
    {
        collision = false;
        for (int i = 0; i < rocks.GetLength(0); i++)
        {
            rocks[i, 1]++; // y++
            collision = collision || CheckCollision(rocks[i, 0], rocks[i, 1], rocks[i, 2]);
            PrintAtPosition(rocks[i, 0], rocks[i, 1], new String(rockCharacters[rocks[i, 3]], rocks[i, 2]));

            // Fallen below viewport -> add new one on top
            if (rocks[i, 1] == Console.WindowHeight - 1)
            {
                GetRock(i);
                rocks[i, 1] = -1;
            }
        }
    }

    static void DrawResult()
    {
        result += collision ? -50 : 1;
        PrintAtPosition(0, 0, Convert.ToString(result / 10));
    }

    static void Main(string[] args)
    {
        SetInitialPositions();
        while (true)
        {
            if (Console.KeyAvailable) MovePlayer(Console.ReadKey());
            Console.Clear();
            DrawPlayer();
            DrawEnviroment();
            DrawResult();
            Thread.Sleep(1000 / fps);
        }
    }
}
