using System;

class Program
{
    static event EventHandler<ConsoleKey> XPressed;
    static event EventHandler<ConsoleKey> YPressed;

    static void OnKeyDown(ConsoleKey key)
    {
        if (key == ConsoleKey.X) XPressed(null, ConsoleKey.X);
        if (key == ConsoleKey.Y) YPressed(null, ConsoleKey.Y);
    }

    static void HandleKeyPress(object sender, ConsoleKey key)
    {
        Console.Clear();

        Console.WriteLine("You pressed {0}.", key.ToString());
    }

    static void Main()
    {
        Console.WriteLine("Press X or Y.");

        // Attach event handlers
        XPressed = HandleKeyPress;

        YPressed = HandleKeyPress;
        YPressed += (a, b) =>
            Console.WriteLine("Trigger one more handler.");

        // Watch
        while (true) OnKeyDown(Console.ReadKey().Key);
    }
}
