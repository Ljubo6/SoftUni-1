using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Launcher
{
    public static void Main()
    {
        var a = new Dictionary<int, List<string>>();
        a.Add(1, new List<string>());
        a.Add(2, new List<string>());
        a[1].Add("Pesho");
        a[1].Add("Gosho");
        a[2].Add("Joro");
        a[1].Add("Pesho");

        //a.Add(1, "Pesho");
        //a.Add(2, "Gosho");
        //a.Add(1, "Joro");
        //a.Add(1, "Pesho");

        var b = a.Values.SelectMany(x => x).ToList();

        for (int i = 0; i < 4; i++)
        {
            System.Console.WriteLine(b[i]);
        }
    }
}
