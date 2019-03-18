using System;
using System.Collections.Generic;
using System.Text;

class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        set
        {
            if (!ValidateSide(value))
            {
                throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
            }

            this.length = value;
        }
    }

    public double Width
    {
        set
        {
            if (!ValidateSide(value))
            {
                throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
            }

            this.width = value;
        }
    }

    public double Height
    {
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
            }

            this.height = value;
        }
    }

    public double GetSurfaceArea()
    {
        return 2 * (this.length * this.width + this.length * this.height + this.width * this.height);
    }

    public double GetLateralSurfaceArea()
    {
        return 2 * this.height * (this.length + this.width);
    }

    public double GetVolume()
    {
        return this.height * this.length * this.width;
    }

    private bool ValidateSide(double side)
    {
        return side > 0;
    }
}

