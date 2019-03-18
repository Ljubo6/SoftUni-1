using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new Dictionary<string, string>();
            items.Add("shards", "Shadowmourne");
            items.Add("fragments", "Valanyr");
            items.Add("motes", "Dragonwrath");
            string winningMaterial = string.Empty;

            var materialsQnty = new Dictionary<string, int>();
            materialsQnty.Add("shards", 0);
            materialsQnty.Add("fragments", 0);
            materialsQnty.Add("motes", 0);

            var junk = new Dictionary<string, int>();
            bool found = false; 

            while (true)
            {
                string[] input = Console.ReadLine().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int i = 0; i < input.Length; i+=2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1];

                    if (materialsQnty.ContainsKey(material))
                    {
                        materialsQnty[material] += quantity;
                        if (materialsQnty[material] >= 250)
                        {
                            winningMaterial = material;
                            materialsQnty[material] -= 250;
                            found = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!junk.ContainsKey(material))
                        {
                            junk.Add(material, quantity);
                        }
                        else
                        {
                            junk[material] += quantity;
                        }
                    }
                }
                if (found == true)
                {
                    break;
                }
            }

            materialsQnty = materialsQnty
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            junk = junk
                 .OrderBy(x => x.Key)
                 .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"{items[winningMaterial]} obtained!");
            foreach (var kvp in materialsQnty)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            foreach (var kvp in junk)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
