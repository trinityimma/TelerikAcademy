using System;

class KeyboardUserInterface : IUserInterface
{
    public event EventHandler OnLeft = null;
    public event EventHandler OnRight = null;

    public event EventHandler OnRotate = null;
    public event EventHandler OnDrop = null;

    public void ProcessInput()
    {
        // Consume all keys
        while (Console.KeyAvailable)
        {
            // Don't display them on the console
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.H:         // VIM edition
                case ConsoleKey.A:         // Gamer edition
                case ConsoleKey.LeftArrow: // Standart edition
                    this.OnLeft(this, new EventArgs());
                    break;

                case ConsoleKey.L:
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    this.OnRight(this, new EventArgs());
                    break;

                case ConsoleKey.K:
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    this.OnRotate(this, new EventArgs());
                    break;

                case ConsoleKey.J:
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    this.OnDrop(this, new EventArgs());
                    break;
            }
        }
    }
}
