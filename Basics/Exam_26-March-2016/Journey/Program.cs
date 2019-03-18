using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double Expenditure = 0.0;

            if (budget >= 10 && budget <= 100)
            {
                if (season == "summer")
                {
                    Expenditure = budget * 30.00 / 100.00;
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine($"Camp - {Expenditure:f2}");
                }
                else if (season == "winter")
                {
                    Expenditure = budget * 70.00 / 100.00;
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine($"Hotel - {Expenditure:f2}");
                }
            }

            if (budget > 100 && budget <= 1000)
            {
                if (season == "summer")
                {
                    Expenditure = budget * 40.00 / 100.00;
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine($"Camp - {Expenditure:f2}");
                }
                else if (season == "winter")
                {
                    Expenditure = budget * 80.00 / 100.00;
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine($"Hotel - {Expenditure:f2}");
                }
            }
            if (budget > 1000 && budget <= 5000)
            {
                Expenditure = budget * 90.00 / 100.00;
                Console.WriteLine("Somewhere in Europe");
                Console.WriteLine($"Hotel - {Expenditure:f2}");
            }
        }
    }
}
