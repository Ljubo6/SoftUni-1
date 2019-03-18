using System;
using System.Collections.Generic;
using System.Text;


class Topping
{
    private int weight;
    private string type;
    private double totalKCals;

    public int Weight
    {
        set
        {
            if (value >= 1 && value <= 50)
            {
                this.weight = value;
            }
            else
            {
                throw new InvalidOperationException($"{this.type} weight should be in the range [1..50].");
            }
        }
    }

    public string Type
    {
        set
        {
            if (value.ToLower() == "meat" || value.ToLower() == "veggies" ||
                value.ToLower() == "cheese" || value.ToLower() == "sauce")
            {
                this.type = value;
            }
            else
            {
                throw new InvalidOperationException($"Cannot place {value} on top of your pizza.");
            }
        }
    }

    public double CalculateKCals()
    {
        this.totalKCals = this.weight * 2;

        if (this.type.ToLower() == "meat")
        {
            this.totalKCals *= 1.2;
        }
        else if (this.type.ToLower() == "veggies")
        {
            this.totalKCals *= 0.8;
        }
        else if (this.type.ToLower() == "cheese")
        {
            this.totalKCals *= 1.1;
        }
        else if (this.type.ToLower() == "sauce")
        {
            this.totalKCals *= 0.9;
        }

        return this.totalKCals;
    }
}
