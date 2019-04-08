using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Core;
using System;
using System.Linq;

namespace DungeonsAndCodeWizards
{
	public class StartUp
	{
		// DO NOT rename this file's namespace or class name.
		// However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
		public static void Main(string[] args)
		{
            var str = "ivan attacks gosho for 40 hit points! gosho has 100/100 HP and 10/50 AP left!";

            var cleric = new Cleric("Gosho", Data.Faction.CSharp);
            cleric.Rest();

            Console.WriteLine(str.Length);
            Console.WriteLine(str[36]);

            var input1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            var input2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            var input3 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            var input4 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();


            var dungeon = new DungeonMaster();
            dungeon.JoinParty(input1);
            dungeon.AddItemToPool(input2);
            dungeon.PickUpItem(input3);
            dungeon.UseItem(input4);

            Console.WriteLine();
		}
	}
}