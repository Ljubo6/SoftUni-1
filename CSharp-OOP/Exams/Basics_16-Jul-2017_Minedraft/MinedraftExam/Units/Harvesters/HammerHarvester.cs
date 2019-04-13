public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirements)
        : base(id, oreOutput * 3, energyRequirements * 2)
    {
    }
}
