using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.Wardrobe
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string,int>>(); // colour -> clothing item

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string colour = line[0].Trim();

                if (!wardrobe.ContainsKey(colour)) //check for color
                {
                    wardrobe.Add(colour, new Dictionary<string, int>());
                }

                string[] items = line[1].Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int j = 0; j < items.Length; j++)
                {
                    string item = items[j].Trim();

                    if (!wardrobe[colour].ContainsKey(item))
                    {
                        wardrobe[colour].Add(item, 1);
                    }
                    else
                    {
                        wardrobe[colour][item]++;
                    }
                }
            }

            string[] toFind = Console.ReadLine().Split();
            string colorToFind = toFind[0];
            string itemToFind = toFind[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var item in color.Value)
                {
                    Console.Write($"* {item.Key} - {item.Value}");
                    if (color.Key == colorToFind && itemToFind == item.Key)
                    {
                        Console.Write(" (found!)");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
