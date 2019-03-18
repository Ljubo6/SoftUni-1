using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ArenaTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = int.Parse(Console.ReadLine());
            string arenaName = Console.ReadLine();
            string day = Console.ReadLine();
            string condition = Console.ReadLine();
            double totalPrice = 0;

            if (condition == "Poor")
            {
                totalPrice = 7000;
            }
            else if (condition == "Normal")
            {
                totalPrice = 14000;
            }
            else if (condition == "Legendary")
            {
                totalPrice = 21000;
            }

            switch (arenaName)
            {
                case "Nagrand":
                    if (day == "Monday" || day == "Wednesday")
                    {
                        totalPrice = totalPrice * 0.95;
                    }
                    break;
                case "Gurubashi":
                    if (day == "Tuesday" || day == "Thursday")
                    {
                        totalPrice = totalPrice * 0.9;
                    }
                    break;
                case "Dire Maul":
                    if (day == "Friday" || day == "Saturday")
                    {
                        totalPrice = totalPrice * 0.93;

                    }
                    break;
            }
            double itemPrice = totalPrice / 5;
            int itemsBought = (int)(points / itemPrice);
            if (itemsBought > 5)
            {
                itemsBought = 5;
            }
            double diff = Math.Abs(points - itemsBought * itemPrice);
            

            if (itemsBought >= 5)
            {
                Console.WriteLine("Items Bought: 5");
                Console.WriteLine($"Arena points left:{diff}");
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine($"Items Bought: {itemsBought}");
                Console.WriteLine($"Arena points left:{diff}");
                Console.WriteLine("Failure!");
            }
        }
    }
}
