using System;
using System.Collections.Generic;

class Display
{
    public readonly int Width, Height;
    public readonly int? NumberOfColors;

    public Display(int width, int height, int? numberOfColors = null)
    {
        this.Width = width;
        this.Height = height;
        this.NumberOfColors = numberOfColors;
    }

    public override string ToString()
    {
        List<string> info = new List<string>();

        info.Add("Width: " + this.Width);
        info.Add("Height: " + this.Height);

        if (this.NumberOfColors.HasValue)
            info.Add("Number of Colors: " + this.NumberOfColors);

        return String.Join(", ", info);
    }
}

class Battery
{
    public readonly Type Model;
    public readonly int? HoursIdle, HoursTalk;

    public enum Type { LiIon, NiMH, NiCd }; // static by default

    public Battery(Type model, int? hoursIdle = null, int? hoursTalk = null)
    {
        this.Model = model;
        this.HoursIdle = hoursIdle;
        this.HoursTalk = hoursTalk;
    }

    public override string ToString()
    {
        List<string> info = new List<string>();

        info.Add("Model: " + this.Model);

        if (this.HoursIdle.HasValue)
            info.Add("Hours Idle: " + this.HoursIdle);

        if (this.HoursTalk.HasValue)
            info.Add("Hours Talk: " + this.HoursTalk);

        return String.Join(", ", info);
    }
}

class GSM
{
    public readonly string Model, Manufacturer;
    public readonly string Owner;
    public readonly decimal? Price;

    public readonly Display Display;
    public readonly Battery Battery;

    public GSM(string model, string manufacturer, string owner = null,
        decimal? price = null, Display display = null, Battery battery = null)
    {
        this.Model = model;
        this.Manufacturer = manufacturer;
        this.Owner = owner;
        this.Price = price;
        this.Display = display;
        this.Battery = battery;
    }

    public override string ToString()
    {
        List<string> info = new List<string>();

        info.Add("Model - " + this.Model);
        info.Add("Manufacturer - " + this.Manufacturer);

        if (this.Owner != null)
            info.Add("Owner - " + this.Owner);

        if (this.Price != null)
            info.Add("Price - " + this.Price);

        if (this.Display != null)
            info.Add("Display - " + this.Display);

        if (this.Battery != null)
            info.Add("Battery - " + this.Battery);

        return String.Join(Environment.NewLine, info);
    }
}

class Program
{
    static void Main()
    {
        Display display = new Display(480, 320);
        Battery battery = new Battery(Battery.Type.LiIon, hoursTalk: 10);

        GSM phone = new GSM("iPhone 5", "Apple", display: display, battery: battery);

        Console.WriteLine(phone);
    }
}
