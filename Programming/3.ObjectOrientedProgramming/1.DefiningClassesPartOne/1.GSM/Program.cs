using System;

class Display
{
    public readonly int Width, Height;
    public readonly int NumberOfColors;
}

class Battery
{
    public readonly string Model;
    public readonly int HoursIdle, HoursTalk;
}

class GSM
{
    public readonly string Model, Manufacturer;
    public readonly string Owner;
    public readonly decimal Price;

    public readonly Display Display = new Display();
    public readonly Battery Battery = new Battery();
}

class Program
{
    static void Main()
    {
        Console.WriteLine(new GSM().Display.Height);
    }
}
