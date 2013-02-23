using System;
using System.Collections.Generic;

class Gsm
{
    // Private Constants
    private const uint MaxDisplayWidth = 4096;
    private const uint MaxDisplayHeight = 2160;
    private const decimal MaxPrice = 1e6M;

    // Private Fields
    private Display display = null;
    private decimal? price = 0;

    // TODO: Constant
    public static Gsm IPhone4S = new Gsm("iPhone 4s", "Apple", null, 1000M,
        new Display(960, 640, 1 << 24), new Battery(Battery.Type.LiIon, 60, 30));

    // Properties
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public string Owner { get; set; }

    public decimal? Price
    {
        get { return this.price; }

        set
        {
            // Null or in range
            if (!(!value.HasValue || (0 <= value && value <= MaxPrice)))
                throw new ArgumentOutOfRangeException();

            this.price = value;
        }
    }

    public Display Display
    {
        get { return this.display; }

        set
        {
            if (value.Width > MaxDisplayWidth)
                throw new ArgumentOutOfRangeException();

            if (value.Height > MaxDisplayHeight)
                throw new ArgumentOutOfRangeException();

            this.display = value;
        }
    }

    public Battery Battery { get; set; }

    public CallHistory CallHistory { get; set; }

    // Constructors
    public Gsm(string model, string manufacturer, string owner = null,
        decimal? price = null, Display display = null, Battery battery = null)
    {
        this.Model = model;
        this.Manufacturer = manufacturer;
        this.Owner = owner;
        this.Price = price;
        this.Display = display;
        this.Battery = battery;

        this.CallHistory = new CallHistory();
    }

    // Methods
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

        if (this.CallHistory.Count != 0)
        {
            info.Add("Call History -");

            info.Add(this.CallHistory.ToString());
        }

        return String.Join(Environment.NewLine, info);
    }
}
