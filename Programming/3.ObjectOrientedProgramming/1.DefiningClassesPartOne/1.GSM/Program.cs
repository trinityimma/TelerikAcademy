using System;
using System.Collections.Generic;

class Display
{
    // Private Constants
    const uint MaxWidth = 1 << 16;
    const uint MaxHeight = MaxWidth * 2;
    const uint MaxNumberOfColors = 1 << 32;

    // Private Fields
    uint width = 0;
    uint height = 0;
    uint? numberOfColors = null;

    // Properties
    public uint Width
    {
        get { return this.width; }

        set
        {
            if (value > MaxWidth)
                throw new ArgumentOutOfRangeException();

            this.width = value;
        }
    }

    public uint Height
    {
        get { return this.height; }

        set
        {
            if (value > MaxHeight)
                throw new ArgumentOutOfRangeException();

            this.height = value;
        }
    }

    public uint? NumberOfColors
    {
        get { return this.numberOfColors; }

        set
        {
            if (value.GetValueOrDefault() > MaxNumberOfColors)
                throw new ArgumentOutOfRangeException();

            this.numberOfColors = value;
        }
    }

    // Constructors
    public Display(uint width, uint height, uint? numberOfColors = null)
    {
        this.Width = width;
        this.Height = height;
        this.NumberOfColors = numberOfColors;
    }

    // Methods
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
    public enum Type { LiIon, NiMH, NiCd }; // static by default

    // Private Constants
    const uint MaxIdleHours = 1000;
    const uint MaxTalkHours = 500;

    // Private Fields
    Type model = 0;
    uint? hoursIdle = null;
    uint? hoursTalk = null;

    // Properties
    public Type Model { get; set; }

    public uint? HoursIdle
    {
        get { return this.hoursIdle; }

        set
        {
            if (value.GetValueOrDefault() > MaxIdleHours)
                throw new ArgumentOutOfRangeException();

            this.hoursIdle = value;
        }
    }

    public uint? HoursTalk
    {
        get { return this.hoursTalk; }

        set
        {
            if (value.GetValueOrDefault() > MaxTalkHours)
                throw new ArgumentOutOfRangeException();

            this.hoursIdle = value;
        }
    }

    // Constructors
    public Battery(Type model, uint? hoursIdle = null, uint? hoursTalk = null)
    {
        this.Model = model;
        this.HoursIdle = hoursIdle;
        this.HoursTalk = hoursTalk;
    }

    // Methods
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
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public string Owner { get; set; }
    public decimal? Price { get; set; }

    public Display Display { get; set; }
    public Battery Battery { get; set; }

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
        Battery battery = new Battery(Battery.Type.LiIon);
        
        GSM phone = new GSM("iPhone 5", "Apple", display: display, battery: battery);

        Console.WriteLine(phone);
    }
}
