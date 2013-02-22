using System;

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
}

class Battery
{
    public readonly string Model;
    public readonly int? HoursIdle, HoursTalk;

    public Battery(string model, int? hoursIdle = null, int? hoursTalk = null)
    {
        this.Model = model;
        this.HoursIdle = hoursIdle;
        this.HoursTalk = hoursTalk;
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
}

class Program
{
    static void Main()
    {
        GSM phone;
        
        phone = new GSM("iPhone 4", "Apple", display: new Display(480, 320));
        Console.WriteLine(phone.Display.Height);

        phone = new GSM("iPhone 5", "Apple", battery: new Battery("Lithium ion"), price: 1000);
        Console.WriteLine(phone.Battery.Model);
        Console.WriteLine(phone.Price);
    }
}
