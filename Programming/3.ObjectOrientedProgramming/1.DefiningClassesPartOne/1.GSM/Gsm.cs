using System;
using System.Collections.Generic;

class Gsm
{
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public string Owner { get; set; }
    public decimal? Price { get; set; }

    public Display Display { get; set; }
    public Battery Battery { get; set; }

    public Gsm(string model, string manufacturer, string owner = null,
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
