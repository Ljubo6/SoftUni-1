using System;

public abstract class Driver : IDriver
{
    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
        this.TotalTime = 0d;
    }

    public string Name { get; }
   
    public double TotalTime { get; private set; }

    public Car Car { get; }
    
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
