using P02.KingsGambit.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.KingsGambit
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string kingName = Console.ReadLine();
            string[] royalGuardsNames = Console.ReadLine().Split();
            string[] footmenNames = Console.ReadLine().Split();

            var king = new King(kingName);
            var soldiers = new List<Soldier>();

            foreach (var name in royalGuardsNames)
            {
                var royalGuard = new RoyalGuard(name);
                soldiers.Add(royalGuard);

                king.KingUnderAttack += royalGuard.ReactToKingAttack;
            }

            foreach (var name in footmenNames)
            {
                var footman = new Footman(name);
                soldiers.Add(footman);

                king.KingUnderAttack += footman.ReactToKingAttack;
            }

            while (true)
            {
                string command = Console.ReadLine();

                if(command == "End")
                {
                    return;
                }
                else if(command == "Attack King")
                {
                    king.GetAttacked();
                }
                else if(command.StartsWith("Kill"))
                {
                    var soldierName = command.Split().Skip(1).Take(1).First();
                    soldiers.FirstOrDefault(s => s.Name == soldierName)?.Kill();
                }
            }
        }
    }
}
