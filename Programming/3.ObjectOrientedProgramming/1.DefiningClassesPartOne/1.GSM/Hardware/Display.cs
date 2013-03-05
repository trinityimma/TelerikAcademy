using System;
using System.Collections.Generic;

namespace GSM.Hardware
{
    public class Display
    {
        // Private Constants
        private const uint MaxWidth = 1 << 16;
        private const uint MaxHeight = MaxWidth * 2;
        private const long MaxNumberOfColors = 1L << 32; // Long

        // Private Fields
        private uint width = 0;
        private uint height = 0;
        private long? numberOfColors = null;

        // Properties
        public uint Width
        {
            get { return this.width; }

            set
            {
                if (value > MaxWidth)
                    throw new ArgumentOutOfRangeException("Display width too big!");

                this.width = value;
            }
        }

        public uint Height
        {
            get { return this.height; }

            set
            {
                if (value > MaxHeight)
                    throw new ArgumentOutOfRangeException("Display height too big!");

                this.height = value;
            }
        }

        public long? NumberOfColors
        {
            get { return this.numberOfColors; }

            set
            {
                if (value.GetValueOrDefault() > MaxNumberOfColors)
                    throw new ArgumentOutOfRangeException("Number of Colors too big!");

                this.numberOfColors = value;
            }
        }

        // Constructors
        public Display(uint width, uint height, long? numberOfColors = null)
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
}
