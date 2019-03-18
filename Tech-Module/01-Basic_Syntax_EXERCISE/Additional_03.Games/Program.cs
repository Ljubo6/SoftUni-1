using System;
using System.Collections.Generic;

namespace Additional_03.Games
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Dictionary<string, decimal> availableGames = new Dictionary<string, decimal>();
            availableGames.Add("OutFall 4", 39.99m);
            availableGames.Add("CS: OG", 15.99m);
            availableGames.Add("Zplinter Zell", 19.99m);
            availableGames.Add("Honored 2", 59.99m);
            availableGames.Add("RoverWatch", 29.99m);
            availableGames.Add("RoverWatch Origins Edition", 39.99m);

            List<string> gamesBought = new List<string>();

            decimal currentBalance = decimal.Parse(Console.ReadLine());
            decimal fundsAvailable = currentBalance;
            decimal totalSpent = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Game Time")
                {
                    if (fundsAvailable == 0m)
                    {
                        Console.WriteLine("Out of money!");
                        break;
                    }
                    Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${fundsAvailable:f2}");
                    break;
                }
                else if (availableGames.ContainsKey(input))
                {
                    if (fundsAvailable >= availableGames[input])
                    {
                        Console.WriteLine($"Bought {input}");
                        fundsAvailable -= availableGames[input];
                        totalSpent += availableGames[input];
                    }
                    else if (fundsAvailable == 0m)
                    {
                            Console.WriteLine("Out of money!");
                            break;
                    }
                    else if (fundsAvailable < availableGames[input])
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
            }
        }
    }
}
