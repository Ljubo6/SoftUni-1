using System;
using System.Collections.Generic;
using System.Text;


class Rectangle
{
    private Point bottomRightCorner;
    private string id;
    private int width;
    private int height;

    public string Id
    {
        get
        {
            return this.id;
        }
        set
        {
            if (value != null)
            {
                this.id = value;
            }
        }
    }
    public int Width
    {
        get
        {
            return this.width;
        }
        set
        {
            if (value > 0)
            {
                this.width = value;
            }
        }
    }
    public int Height
    {
        get
        {
            return this.height;
        }
        set
        {
            if (value > 0)
            {
                this.height = value;
            }
        }
    }

    public Point TopLeftCorner { get; set; }
    public Point BottomRightCorner { get => this.bottomRightCorner; }

    public Rectangle(string id, int width, int height, Point topLeftCorner)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.TopLeftCorner = topLeftCorner;
        this.bottomRightCorner = new Point(this.TopLeftCorner.X + this.Width, this.TopLeftCorner.Y - this.Height);
    }

    public bool DoIntersect(Rectangle B)
    {
        if (this.TopLeftCorner.X > B.BottomRightCorner.X || B.TopLeftCorner.X > this.BottomRightCorner.X)
        {
            return false;
        }

        if (this.TopLeftCorner.Y < B.BottomRightCorner.Y || B.TopLeftCorner.Y < this.BottomRightCorner.Y)
        {
            return false;
        }

        return true;
    }
}

class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}
