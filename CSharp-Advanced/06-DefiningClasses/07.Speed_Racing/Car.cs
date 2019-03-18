using System;
using System.Collections.Generic;
using System.Text;

class Car
{
    private string model;
    private double fuelAmount;
    private double consumption;
    private double travelledDistance;

    /// <summary>
    ///  Represents a class Car holding the following properties: Model, Fuel Amount, Consumption Per 1km, Total Travelled Distance
    /// </summary>
    /// <param name="model"></param>
    /// <param name="fuelAmount"></param>
    /// <param name="consumption"></param>
    public Car(string model, double fuelAmount, double consumption)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.Consumption = consumption;
        this.travelledDistance = 0;
    }

    public string Model
    {
        get { return this.model; }
        private set
        {
            if (!string.IsNullOrEmpty(value))
            {
                this.model = value;
            }

        }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        private set
        {
            if (value >= 0)
            {
                this.fuelAmount = value;
            }
        }
    }

    public double Consumption
    {
        get { return this.consumption; }
        set
        {
            if (value >= 0)
            {
                this.consumption = value;
            }
        }
    }

    public double TravelledDistance
    {
        get
        {
            return this.travelledDistance;
        }
    }

    public void IncreaseTravelledDistance(double newDistance)
    {
        this.travelledDistance += newDistance;
    }

    public bool IsFuelEnough(double distance)
    {
        return this.fuelAmount >= distance * this.consumption;
    }

    public void ReduceFuel(double distance)
    {
        double fuelConsumpted = distance * this.consumption;
        this.fuelAmount -= fuelConsumpted;
    }
}
