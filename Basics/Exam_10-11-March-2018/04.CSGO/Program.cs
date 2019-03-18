using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CSGO
{
    class Program
    {
        static void Main(string[] args)
        {
            int itemsCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            if (itemsCount > 7)
            {
                Console.WriteLine("Sorry, you can't carry so many things!");
            }
            else
            {
                for (int i = 0; i < itemsCount; i++)
                {
                    string gun = Console.ReadLine();


                    if (gun == "ak47") { budget = budget - 2700; }
                    if (gun == "swp") { budget = budget - 4750; }
                    if (gun == "sg553") { budget = budget - 3500; }
                    if (gun == "grenade") { budget = budget - 300; }
                    if (gun == "flash") { budget = budget - 250; }
                    if (gun == "glock") { budget = budget - 500; }
                    if (gun == "bazooka") { budget = budget - 5600; }
                }
                int difference = Math.Abs(budget);

                if (budget >= 0)
                {
                    Console.WriteLine($"You bought all {itemsCount} items! Get to work and defeat the bomb!");
                }
                else
                {
                    Console.WriteLine($"Not enough money! You need {difference} more money.");
                }
            }
           
        }
    }
}
