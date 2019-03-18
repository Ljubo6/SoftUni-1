using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

class Program
{
    static void Main(string[] args)
    {
        Battlecard cd1 = new Battlecard(2, CardType.SPELL, "joro", 5, 1);
        Battlecard cd2 = new Battlecard(1, CardType.SPELL, "joro", 6, 1);
        Battlecard cd3 = new Battlecard(4, CardType.SPELL, "joro", 7, 15.6);
        Battlecard cd4 = new Battlecard(3, CardType.SPELL, "joro", 8, 15.6);
        Battlecard cd5 = new Battlecard(8, CardType.RANGED, "joro", 11, 17.8);

        var a = new RoyaleArena();
        a.Add(cd1);
        a.Add(cd3);
        a.Add(cd2);
        a.Add(cd4);
        a.Add(cd5);

        var resultBySwag = a.GetByNameOrderedBySwagDescending("joro").ToList();
        var resultByDemage = a.GetByCardTypeAndMaximumDamage(CardType.SPELL, 17).ToList();

        Console.WriteLine();
    }
}
