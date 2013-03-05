using System;
using System.Collections.Generic;
using GSM.Software;

namespace GSM.Hardware
{
    public class Gsm
    {
        // Private Constants
        private static readonly Gsm iPhone4S = new Gsm("iPhone 4s", "Apple", null, 1000M,
            new Display(960, 640, 1 << 24), new Battery(Battery.Type.LiIon, 60, 30));

        private const uint MaxDisplayWidth = 4096;
        private const uint MaxDisplayHeight = 2160;
        private const decimal MaxPrice = 1E6M;

        // Private Fields
        private string model = null;
        private string manufacturer = null;
        private Display display = null;
        private decimal? price = 0;

        // Properties
        public static Gsm IPhone4S
        {
            get { return iPhone4S; }
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("Model can't be null!");

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("Manufacturer can't be null!");

                this.manufacturer = value;
            }
        }

        public string Owner { get; set; }

        public decimal? Price
        {
            get { return this.price; }

            private set
            {
                // Null or in range
                if (!(!value.HasValue || (0 <= value && value <= MaxPrice)))
                    throw new ArgumentOutOfRangeException("Price not in range!");

                this.price = value;
            }
        }

        public Display Display
        {
            get { return this.display; }

            private set
            {
                if (value != null)
                {
                    if (value.Width > MaxDisplayWidth)
                        throw new ArgumentOutOfRangeException("Display width too big!");

                    if (value.Height > MaxDisplayHeight)
                        throw new ArgumentOutOfRangeException("Display height too big!");
                }

                this.display = value;
            }
        }

        public Battery Battery { get; private set; }

        public CallHistory CallHistory { get; private set; }

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
}
