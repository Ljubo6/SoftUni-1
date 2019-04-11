using GrandPrix.CustomExceptions;
using System;

public abstract class Tyre : ITyre
{
    private string name;
    private double hardness;
    private double degradation;

    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Tyre's name is invalid!");
            }
            this.name = value;
        }
    }

    public double Hardness
    {
        get => this.hardness;
        private set
        {
            if(value <= 0)
            {
                throw new ArgumentException("Hardness cannot be zero or less!");
            }
            this.hardness = value;
        }
    }

    protected virtual double MinimalDegradation => 0;

    public double Degradation
    {
        get => this.degradation;
        protected set
        {
            this.degradation = value;

            if (value < MinimalDegradation)
            {
                throw new BlownTyreException("Tyre has blown up!");
            }
        }
    }

    public virtual void ReduceDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}
