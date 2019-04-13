using System;
using System.Text;

public abstract class Harvester : Unit
{
    private double oreOutput;
    private double energyRequirement;
    private const double MaxEnergyRequirement = 20000;

    protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get => this.oreOutput;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(this.OreOutput)}");
            }
            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get => this.energyRequirement;
        protected set
        {
            if (value < 0 || MaxEnergyRequirement < value)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(this.EnergyRequirement)}");
            }

            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        var type = this.GetType().Name.Substring(0, this.GetType().Name.Length - "Harvester".Length);

        var info = new StringBuilder();
        info.AppendLine($"{type} Harvester - {this.Id}");
        info.AppendLine($"Ore Output: {this.OreOutput}");
        info.AppendLine($"Energy Requirement: {this.EnergyRequirement}");
        return info.ToString().TrimEnd();
    }
}
