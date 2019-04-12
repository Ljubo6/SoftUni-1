using GrandPrix.CustomExceptions;

public class UltrasoftTyre : Tyre
{
    public UltrasoftTyre(double hardness, double grip)
        : base("Ultrasoft", hardness)
    {
        this.Grip = grip;
    }

    public double Grip { get; private set; }

    protected override double MinimalDegradation => 30;

    public override void ReduceDegradation()
    {
        this.Degradation -= this.Hardness + this.Grip;
        if (this.Degradation < MinimalDegradation)
        {
            throw new BlownTyreException(ErrorMessages.BlownTyre);
        }
    }
}
