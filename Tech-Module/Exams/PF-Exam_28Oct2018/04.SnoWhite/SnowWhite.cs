using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SnoWhite
{
    public class SnowWhite
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new string[] { " ", "<:>" }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            List<Dwarf> allDwarfs = new List<Dwarf>();

            while (string.Join(" ", input) != "Once upon a time")
            {
                string name = input[0];
                string hatColor = input[1];
                int physics = int.Parse(input[2]);

                var currentDwarf = new Dwarf()
                {
                    Name = name,
                    HatColor = hatColor,
                    Physics = physics
                };

                if (allDwarfs.FirstOrDefault(x => x.Name == currentDwarf.Name) == null)
                {
                    allDwarfs.Add(currentDwarf);
                }
                else
                {
                    Dwarf presentDwarf = allDwarfs.First(x => x.Name == currentDwarf.Name);

                    if (presentDwarf.HatColor != currentDwarf.HatColor)
                    {
                        allDwarfs.Add(currentDwarf);
                    }
                    else
                    {
                        if (presentDwarf.Physics < currentDwarf.Physics)
                        {
                            presentDwarf.Physics = currentDwarf.Physics;
                        }
                        else
                        {
                            input = Console.ReadLine().Split(new string[] { " ", "<:>" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                            continue;
                        }
                    }
                }

                input = Console.ReadLine().Split(new string[] { " ", "<:>" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            allDwarfs = allDwarfs
                .OrderByDescending(x => x.Physics)
                .ThenByDescending(y => allDwarfs.Count(x => y.HatColor == x.HatColor))
                .ToList();

            foreach (Dwarf dwarf in allDwarfs)
            {
                Console.WriteLine($"({dwarf.HatColor}) {dwarf.Name} <-> {dwarf.Physics}");
            }
        }
    }

    public class Dwarf
    {
        public string Name { get; set; }
        public string HatColor { get; set; }
        public int Physics { get; set; }
    }
}
