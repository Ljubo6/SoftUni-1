using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;

public class DraftManager
{
    private WorkingMode workingMode;
    private double totalStoredEnergy;
    private double totalMinedOre;

    private List<Harvester> harvesters;
    private List<Provider> providers;
    private Dictionary<string, Unit> byId;

    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;

    public DraftManager()
    {
        this.workingMode = WorkingMode.Full;
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
        this.byId = new Dictionary<string, Unit>();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var harvester = harvesterFactory.Create(arguments);
            this.harvesters.Add(harvester);
            this.byId.Add(arguments[1], harvester);
            return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var provider = providerFactory.Create(arguments);
            this.providers.Add(provider);
            this.byId.Add(arguments[1], provider);
            return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string Day()
    {
        var dailyProducedEnergy = this.CalculateDailyProducedEnergy();
        this.totalStoredEnergy += dailyProducedEnergy;

        var requiredEnergyForDay = this.CalculateTotalRequiredEnergy();
        double dailyOre = 0d;

        if (requiredEnergyForDay <= this.totalStoredEnergy && this.workingMode != WorkingMode.Energy)
        {
            this.totalStoredEnergy -= requiredEnergyForDay;
            dailyOre = this.CalculateDailyOre();
            this.totalMinedOre += dailyOre;
        }

        var output = new StringBuilder();
        output.AppendLine("A day has passed.");
        output.AppendLine($"Energy Provided: {dailyProducedEnergy}");
        output.AppendLine($"Plumbus Ore Mined: {dailyOre}");
        return output.ToString().TrimEnd();
    }

    private double CalculateDailyOre()
    {
        var dailyOre = this.harvesters.Sum(h => h.OreOutput);

        if(this.workingMode == WorkingMode.Half)
        {
            dailyOre *= 0.5;
        }

        return dailyOre;
    }

    private double CalculateDailyProducedEnergy()
    {
        return this.providers.Sum(p => p.EnergyOutput);
    }

    private double CalculateTotalRequiredEnergy()
    {
        var totalRequiredEnergy = this.harvesters.Sum(h => h.EnergyRequirement);

        if(this.workingMode == WorkingMode.Half)
        {
            totalRequiredEnergy *= 0.6;
        }

        return totalRequiredEnergy;
    }

    public string Mode(List<string> arguments)
    {
        string mode = arguments[0];
        Enum.TryParse(mode, out this.workingMode);

        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        if (!this.byId.ContainsKey(id))
        {
            return $"No element found with id - {id}";
        }

        var unit = this.byId[id];
        return unit.ToString();
    }

    public string ShutDown()
    {
        var info = new StringBuilder();
        info.AppendLine($"System Shutdown");
        info.AppendLine($"Total Energy Stored: {this.totalStoredEnergy}");
        info.AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");
        return info.ToString().TrimEnd();
    }


}
