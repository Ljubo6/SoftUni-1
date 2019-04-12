using GrandPrix.CustomExceptions;

public abstract class Tyre : ITyre
{
    private double degradation;

    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public string Name { get; }

    public double Hardness { get; }

    protected virtual double MinimalDegradation => 0;

    public double Degradation
    {
        get => this.degradation;
        protected set
        {
            this.degradation = value;
            if (value < MinimalDegradation)
            {
                throw new BlownTyreException(ErrorMessages.BlownTyre);
            }
        }
    }

    public virtual void ReduceDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}
