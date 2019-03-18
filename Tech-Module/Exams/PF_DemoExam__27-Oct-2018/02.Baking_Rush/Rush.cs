using System;
using System.Linq;

namespace _02.Baking_Rush
{
    class Rush
    {
        static void Main(string[] args)
        {
            int energy = 100;
            int coins = 100;

            string[] events = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < events.Length; i++)
            {
                string[] currentEvent = events[i].Split('-').ToArray();

                if (currentEvent[0] == "rest")
                {
                    int currentEnergy = int.Parse(currentEvent[1]);
                    if (energy + currentEnergy <= 100)
                    {
                        energy += currentEnergy;
                        Console.WriteLine($"You gained {currentEnergy} energy.");
                        Console.WriteLine($"Current energy: {energy}.");
                    }
                    else if (energy + currentEnergy > 100)
                    {
                        Console.WriteLine($"You gained {100 - energy} energy.");
                        energy = 100;
                        Console.WriteLine($"Current energy: {energy}.");
                    }
                }
                if (currentEvent[0] == "order")
                {
                    if (energy >= 30)
                    {
                        int currentCoins = int.Parse(currentEvent[1]);
                        Console.WriteLine($"You earned {currentCoins} coins.");
                        coins += currentCoins;
                        energy -= 30;
                    }
                    else
                    {
                        Console.WriteLine("You had to rest!");
                        energy += 50;
                        if (energy > 100)
                        {
                            energy = 100;
                        }
                    }
                }
                else
                {
                    string product = currentEvent[0];
                    int productPrice = int.Parse(currentEvent[1]);
                    if (coins > productPrice)
                    {
                        coins -= productPrice;
                        Console.WriteLine($"You bought {product}.");
                    }
                    else
                    {
                        Console.WriteLine($"Closed! Cannot afford {product}.");
                        return;
                    }
                }
            }
            Console.WriteLine("Day completed!");
            Console.WriteLine($"Coins: {coins}");
            Console.WriteLine($"Energy: {energy}");
        }
    }
}
