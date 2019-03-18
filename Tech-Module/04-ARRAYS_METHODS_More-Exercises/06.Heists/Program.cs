using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Heists
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int jewelPrice = prices[0];
            int goldPrice = prices[1];

            int jewelCounter = 0;
            int goldCounter = 0;
            int totalExpenses = 0;

            while (true)
            {
                string command = Console.ReadLine();
                int totalEarnings = goldCounter * goldPrice + jewelCounter * jewelPrice;

                if (command != "Jail Time")
                {
                    string[] lootExpenses = command.Split(' ').ToArray();
                    char[] loot = lootExpenses[0].ToCharArray();

                    int expenses = Int32.Parse(lootExpenses[1]);

                    for (int i = 0; i < loot.Length; i++)
                    {
                        if (loot[i] == '%')
                        {
                            jewelCounter++;
                        }
                        else if (loot[i] == '$')
                        {
                            goldCounter++;
                        }
                    }
                    totalExpenses = totalExpenses + expenses;
                }
                else
                {
                    if (totalEarnings >= totalExpenses)
                    {
                        Console.WriteLine($"Heists will continue. Total earnings: {totalEarnings - totalExpenses}.");
                    }
                    else
                    {
                        Console.WriteLine($"Have to find another job. Lost: {totalExpenses - totalEarnings}.");
                    }
                    break;
                }
            }
        }
    }
}
