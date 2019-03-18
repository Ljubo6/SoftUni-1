using System;
using System.Collections.Generic;
using System.Text;

class Engine
{
    private string model;
    private string power;
    private int displacement;

    public string Model
    {
        get
        {
            return this.model;
        }
        set
        {
            if(value != null)
            {
                this.model = value;
            }
        }
    }

    public string Power
    {
        get
        {
            return this.power;
        }
        set
        {
            if (value != null)
            {
                this.power = value;
            }
        }
    }

    public int Displacement
    {
        get => this.displacement ;
        set
        {
            this.displacement = value;
        }
    }

    public string Efficiency { get; set; }

    public Engine(string model, string power)
    {
        this.Model = model;
        this.Power = power;
    }

    public override string ToString()
    {
        string Displacement()
        {
            if (this.displacement > 0)
            {
                return $"{this.displacement}";
            }
            return "n/a";
        }
        string Efficiency()
        {
            if (this.Efficiency != null)
            {
                return $"{this.Efficiency}";
            }
            return "n/a";
        }

        return $"{this.model}:\n    Power: {this.power}\n    Displacement: {Displacement()}\n    Efficiency: {Efficiency()}";
    }
}