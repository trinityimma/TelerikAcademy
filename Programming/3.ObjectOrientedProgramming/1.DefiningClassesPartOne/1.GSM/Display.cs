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