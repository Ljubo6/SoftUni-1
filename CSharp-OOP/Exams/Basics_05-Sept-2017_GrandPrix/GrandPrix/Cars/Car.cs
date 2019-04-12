using GrandPrix.CustomExceptions;
using System;

public class Car : ICar
{
    private double fuelAmount;
    private const double MaxCapacity = 160;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; }

    public double FuelAmount
    {
        get => this.fuelAmount;
        private set
        {
            this.fuelAmount = Math.Min(value, MaxCapacity);
        }
    }

    public Tyre Tyre { get; private set; }
    
    public void Refuel(double fuel)
    {
        this.FuelAmount += fuel;
    }

    public void ChangeTyre(Tyre newTyre)
    {
        this.Tyre = newTyre;
    }

    public void ReduceFuel(double fuelBurnt)
    {
        this.fuelAmount -= fuelBurnt;
        if (this.fuelAmount < 0)
        {
            throw new OutOfFuelException(ErrorMessages.OutOfFuel);
        }
    }
}
