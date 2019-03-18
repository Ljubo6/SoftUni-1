using System;
using System.Collections.Generic;
using System.Text;

class Car
{
    private string model;
    private Engine engine;
    private decimal weight;

    public string Model
    {
        get
        {
            return this.model;
        }
        set
        {
            if (value != null)
            {
                this.model = value;
            }
        }
    }

    public Engine Engine
    {
        get
        {
            return this.engine;
        }
        set
        {
            if (value != null)
            {
                this.engine = value;
            }
        }
    }

    public decimal Weight
    {
        get => this.weight;
        set
        {
            if (value > 0)
            {
                this.weight = value;
            }
        }
    }

    public string Color { get; set; }

    public Car(string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
    }

    public override string ToString()
    {
        string Weight()
        {
            if (this.weight > 0)
            {
                return $"{this.weight}";
            }
            return "n/a";
        }

        string Color()
        {
            if (this.Color != null)
            {
                return $"{this.Color}";
            }
            return "n/a";
        }
        return $"{this.model}:\n  {this.Engine.ToString()}\n  Weight: {Weight()}\n  Color: {Color()}";
    }
}
