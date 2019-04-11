using GrandPrix.CustomExceptions;
using System;

public class Car : ICar
{
    private int hp;
    private double fuelAmount;
    private Tyre tyre;
    private const double MaxCapacity = 160;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp
    {
        get => this.hp;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("HP cannot be zero or less!");
            }
            this.hp = value;
        }
    }

    public double FuelAmount
    {
        get => this.fuelAmount;
        private set
        {
            this.fuelAmount = Math.Min(value, MaxCapacity);
        }
    }

    public Tyre Tyre
    {
        get => this.tyre;
        private set
        {
            this.tyre = value ?? throw new ArgumentException("Tyre cannot be null!");
        }
    }

    public void Refuel(double fuel)
    {
        this.FuelAmount += fuel;
    }

    public void ChangeTyre(Tyre tyre)
    {
        this.tyre = tyre;
    }

    public void ReduceFuel(double fuelBurnt)
    {
        this.fuelAmount -= fuelBurnt;
        if (this.fuelAmount < 0)
        {
            throw new OutOfFuelException("Driver cannot continue the race!");
        }
    }
}
