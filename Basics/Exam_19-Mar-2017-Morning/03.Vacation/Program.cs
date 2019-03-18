using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();
            string accomodation = "";
            string location = "";
            double cost = 0.0;

            if (budget <= 1000)
            {
                accomodation = "Camp";
                if (season == "summer")
                {
                    location = "Alaska";
                    cost = budget * 0.65;
                }
                else if (season == "winter")
                {
                    location = "Morocco";
                    cost = budget * 0.45;
                }
            }
            if (budget > 1000 && budget <= 3000)
            {
                accomodation = "Hut";
                if (season == "summer")
                {
                    location = "Alaska";
                    cost = budget * 0.8;
                }
                else if (season == "winter")
                {
                    location = "Morocco";
                    cost = budget * 0.6;
                }
            }
                if (budget > 3000)
                {
                    accomodation = "Hotel";
                    if (season == "summer")
                    {
                        location = "Alaska";
                        cost = budget * 0.9;
                    }
                    else if (season == "winter")
                    {
                        location = "Morocco";
                        cost = budget * 0.9;
                    }
                }
            
            Console.WriteLine($"{location} - {accomodation} - {cost:f2}");

        }
    }
}
