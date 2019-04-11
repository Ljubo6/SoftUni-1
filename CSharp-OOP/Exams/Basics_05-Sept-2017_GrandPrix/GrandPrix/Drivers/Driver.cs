using System;

public abstract class Driver : IDriver
{
    private string name;
    private Car car;

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Driver's name is invalid!");
            }
            this.name = value;
        }
    }

    public double TotalTime { get; private set; }

    public Car Car
    {
        get => this.car;
        private set
        {
            this.car = value ?? throw new ArgumentException("Car cannot be null!");
        }
    }

    public abstract double FuelConsumptionPerKm { get; }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public void IncreaseTotalTime(double time)
    {
        this.TotalTime += time;
    }

    public void DecreaseTotalTime(double time)
    {
        this.TotalTime -= time;
    }

    public string FailureReason { get; set; }
}
