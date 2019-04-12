using System;
using System.Linq;
using System.Reflection;

public class TyreFactory
{
    public Tyre CreateTyre(string[] args)
    {
        Tyre tyre = null;

        string type = args[0];
        double tyreHardness = double.Parse(args[1]);
        double tyreGrip = 0d;

        if(type == "Hard")
        {
            tyre = new HardTyre(tyreHardness);
        }
        if (type == "Ultrasoft")
        {
            tyreGrip = double.Parse(args[2]);
            tyre = new UltrasoftTyre(tyreHardness, tyreGrip);
        }

        return tyre;
    }
}
