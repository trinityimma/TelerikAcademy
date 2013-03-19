using System;
using System.Linq;
using System.Media;
using System.Threading;

static class Tetris
{
    // 20x10 is the standart field size

    private const int FieldCols = 11; // Prefer odd numbers of cols for perfect centering
    private const int AsideCols = 15;

    private const int Rows = 20;
    private const int Cols = 1 + FieldCols + 1 + AsideCols; // "#...Field...# Aside "

    private static readonly KeyboardUserInterface userInterface = null;
    private static readonly ConsoleRenderer renderer = null;

    private static readonly Engine engine = null;

    static Tetris()
    {
        userInterface = new KeyboardUserInterface();
        renderer = new ConsoleRenderer(Tetris.Rows, Tetris.Cols);

        engine = new Engine(renderer, userInterface);

        engine.InitializeField(1, Tetris.FieldCols);
    }

    private static void ShowIntro()
    {
        PrintMessage(
            "Best viewed in bold Lucida Console with size 28." + Environment.NewLine,
            "Play music? Y/N"
        );

        if (Console.ReadKey(true).Key == ConsoleKey.Y)
        {
            try { new SoundPlayer("../../Music.wav").PlayLooping(); }
            catch { }
        }

        Console.Clear();
    }

    private static void InitializeField()
    {
        // Bottom border
        for (int i = 1; i < Tetris.FieldCols + 1; i++)
            engine.Add(new Block(new Coordinates(Tetris.Rows - 1, i)));

        // Starts from negative number to avoid moving
        // the tetromino outside the borders when created.
        //
        //       xx
        //        xx            xx
        // #             #  ->  #xx           #
        // #             #      #             #
        // ###############      ###############

        // Left border
        for (int i = -5; i < Tetris.Rows; i++)
            engine.Add(new Block(new Coordinates(i, 0)));

        // Right border
        for (int i = -5; i < Tetris.Rows; i++)
            engine.Add(new Block(new Coordinates(i, Tetris.FieldCols + 1)));
    }

    private static void InitializeAside()
    {
        int numberOfLines = 4;

        int row = (Tetris.Rows - numberOfLines) / 2;
        int col = 1 + Tetris.FieldCols + 1 + 1;

        engine.Add(
            new TextLine("Move left:  \u2190", new Coordinates(row++, col)),
            new TextLine("Move right: \u2192", new Coordinates(row++, col)),
            new TextLine("Rotate:     \u2191", new Coordinates(row++, col)),
            new TextLine("Drop:       \u2193", new Coordinates(row++, col))
        );
    }

    private static void AttachEvents()
    {
        userInterface.OnLeft += engine.MoveLeft;
        userInterface.OnRight += engine.MoveRight;
        userInterface.OnRotate += engine.Rotate;
        userInterface.OnDrop += engine.Drop;

        engine.OnMoveEnd += (sender, e) =>
            Console.Beep(100, 125); // Not async

        //engine.OnMoveEnd += (sender, e) =>
        //    engine.Add(new MovingObject(new char[,] { { 'o' } }, Color.Red,
        //        new Coordinates(Rows / 2, FieldCols / 2), Coordinates.Random));

        engine.OnClearedRows += (sender, numberOfClearedRows) =>
        {
            for (int i = 0; i < numberOfClearedRows; i++)
            {
                Console.Beep(1000, 300);

                Thread.Sleep(50);
            }
        };

        engine.OnGameOver += (sender, e) =>
        {
            Console.ForegroundColor = ConsoleColor.White;

            string message = "Thank you for playing...";

            Console.SetCursorPosition((Cols - message.Length) / 2, Rows / 2);

            Console.WriteLine(message);

            Console.ReadKey(true);
        };
    }

    private static void AddControlled()
    {
        Action addControlled = () =>
            engine.AddControlled(Tetromino.Get(new Coordinates(0, Tetris.FieldCols / 2)));

        addControlled();

        engine.OnMoveEnd += (sender, e) =>
            addControlled();
    }

    public static void PrintMessage(params string[] messages)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Clear();

        foreach (string message in messages)
            Console.WriteLine(message);
    }

    public static void Main()
    {
        Console.Title = "Tetris";

        ShowIntro();

        InitializeField();
        InitializeAside();

        AttachEvents();

        AddControlled();

        try { engine.Run(); }

        catch (OTetrominoRotatedException ex)
        {
            PrintMessage(ex.Message);
        }
    }
}