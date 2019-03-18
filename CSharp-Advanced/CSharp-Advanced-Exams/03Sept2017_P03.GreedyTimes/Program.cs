using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _03Sept2017_P03.GreedyTimes
{
    public class StartUp
    {
        public static void Main()
        {
            long bagCapacity = long.Parse(Console.ReadLine());

            var bag = new Dictionary<string, Dictionary<string, int>>()
            {
                { "Cash", new Dictionary<string, int>() },
                { "Gold", new Dictionary<string, int>() },
                { "Gem", new Dictionary<string, int>() }
            };

            string[] itemsInput = Console.ReadLine().Split();
            var itemsQueue = new Queue<string>(itemsInput);

            while (itemsQueue.Any())
            {
                string currentItem = itemsQueue.Dequeue();
                int currentValue = int.Parse(itemsQueue.Dequeue());

                long currentGemAmount = CalculateTotalAmountByType(bag, "Gem");
                long currentCashAMount = CalculateTotalAmountByType(bag, "Cash");
                long currentGoldAmount = CalculateTotalAmountByType(bag, "Gold");

                if (currentItem.Length == 3) // cash
                {
                    if (currentGemAmount >= currentCashAMount + currentValue && CanFitInsideBag(bagCapacity, currentValue))
                    {
                        if (!bag["Cash"].ContainsKey(currentItem))
                        {
                            bag["Cash"].Add(currentItem, currentValue);
                        }
                        else
                        {
                            bag["Cash"][currentItem] += currentValue;
                        }
                        bagCapacity -= currentValue;
                    }
                }
                else if (currentItem.ToLower().EndsWith("gem")) // gem
                {
                    if (currentGoldAmount >= currentGemAmount + currentValue && CanFitInsideBag(bagCapacity, currentValue))
                    {
                        if (!bag["Gem"].ContainsKey(currentItem))
                        {
                            bag["Gem"].Add(currentItem, currentValue);
                        }
                        else
                        {
                            bag["Gem"][currentItem] += currentValue;
                        }
                        bagCapacity -= currentValue;
                    }
                }
                else if (currentItem.ToLower() == "gold") // gold
                {
                    if (CanFitInsideBag(bagCapacity, currentValue))
                    {
                        if (!bag["Gold"].ContainsKey("Gold"))
                        {
                            bag["Gold"].Add("Gold", currentValue);
                        }
                        else
                        {
                            bag["Gold"]["Gold"] += currentValue;
                        }
                        bagCapacity -= currentValue;
                    }
                }
            }

            bag = bag
                .OrderByDescending(x => x.Value.Sum(y => y.Value))
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var itemType in bag)
            {
                if (itemType.Value.Count > 0)
                {
                    Console.WriteLine($"<{itemType.Key}> ${CalculateTotalAmountByType(bag, itemType.Key)}");

                    foreach (var item in itemType.Value
                                             .OrderByDescending(x => x.Key)
                                             .ThenBy(x => x.Value)
                                             .ToDictionary(x => x.Key, x => x.Value))
                    {
                        Console.WriteLine($"##{item.Key} - {item.Value}");
                    }
                }
            }
        }

        public static long CalculateTotalAmountByType(Dictionary<string, Dictionary<string, int>> bag, string itemType)
        {
            return bag.Where(x => x.Key == itemType).Sum(y => y.Value.Sum(z => z.Value));
        }

        public static bool CanFitInsideBag(long bagCapacity, int currentValue)
        {
            return bagCapacity >= currentValue;
        }
    }
}
