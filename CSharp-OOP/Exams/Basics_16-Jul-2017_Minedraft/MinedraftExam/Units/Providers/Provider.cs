using System;
using System.Text;

public abstract class Provider : Unit
{
    private double energyOutput;
    private const double MaxEnergyOutput = 10000;

    protected Provider(string id, double energyOutput) : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get => this.energyOutput;
        private set
        {
            if (value < 0 || value > MaxEnergyOutput)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(this.EnergyOutput)}");
            }
            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        var type = this.GetType().Name.Substring(0, this.GetType().Name.Length - "Provider".Length);

        var info = new StringBuilder();
        info.AppendLine($"{type} Provider - {this.Id}");
        info.AppendLine($"Energy Output: {this.EnergyOutput}");
        return info.ToString().TrimEnd();
    }
}
