using System.Collections.Generic;

public class HarvesterFactory
{
    public Harvester Create(IList<string> arguments)
    {
        Harvester harvester = null;

        string type = arguments[0];
        string id = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyRequirements = double.Parse(arguments[3]);

        if (type == "Hammer")
        {
            harvester = new HammerHarvester(id, oreOutput, energyRequirements);
        }
        else if(type == "Sonic")
        {
            int sonicFactor = int.Parse(arguments[4]);
            harvester = new SonicHarvester(id, oreOutput, energyRequirements, sonicFactor);
        }

        return harvester;
    }
}
