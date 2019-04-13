using System.Collections.Generic;

public class ProviderFactory
{
    public Provider Create(IList<string> arguments)
    {
        Provider provider = null;

        string type = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        if(type == "Solar")
        {
            provider = new SolarProvider(id, energyOutput);
        }
        else if(type == "Pressure")
        {
            provider = new PressureProvider(id, energyOutput);
        }

        return provider;
    }
}
