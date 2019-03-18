using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int numberOfPersons = int.Parse(Console.ReadLine());
            double moneyLeftForTickets = 0.0;
            double totalPriceOfTickets = 0.0;
            

            if (numberOfPersons >= 1 && numberOfPersons <= 4)
            {
                moneyLeftForTickets = budget * 0.25;
                if (category == "Normal")
                {
                    totalPriceOfTickets = numberOfPersons * 249.99;
                }
                else if (category == "VIP")
                {
                    totalPriceOfTickets = numberOfPersons * 499.99;
                }
                double difference = Math.Abs(moneyLeftForTickets - totalPriceOfTickets);
                if (moneyLeftForTickets >= totalPriceOfTickets)
                { Console.WriteLine($"Yes! You have {difference:f2} leva left."); }
                else { Console.WriteLine($"Not enough money! You need {difference:f2} leva."); }
                
            }
            if (numberOfPersons >= 5 && numberOfPersons <= 9)
            {
                moneyLeftForTickets = budget * 0.4;
                if (category == "Normal")
                {
                    totalPriceOfTickets = numberOfPersons * 249.99;
                }
                else if (category == "VIP")
                {
                    totalPriceOfTickets = numberOfPersons * 499.99;
                }
                double difference = Math.Abs(moneyLeftForTickets - totalPriceOfTickets);
                if (moneyLeftForTickets >= totalPriceOfTickets)
                { Console.WriteLine($"Yes! You have {difference:f2} leva left."); }
                else { Console.WriteLine($"Not enough money! You need {difference:f2} leva."); }
            }
            if (numberOfPersons >= 10 && numberOfPersons <= 24)
            {
                moneyLeftForTickets = budget * 0.5;
                if (category == "Normal")
                {
                    totalPriceOfTickets = numberOfPersons * 249.99;
                }
                else if (category == "VIP")
                {
                    totalPriceOfTickets = numberOfPersons * 499.99;
                }
                double difference = Math.Abs(moneyLeftForTickets - totalPriceOfTickets);
                if (moneyLeftForTickets >= totalPriceOfTickets)
                { Console.WriteLine($"Yes! You have {difference:f2} leva left."); }
                else { Console.WriteLine($"Not enough money! You need {difference:f2} leva."); }
            }
            if (numberOfPersons >= 25 && numberOfPersons <= 49)
            {
                moneyLeftForTickets = budget * 0.6;
                if (category == "Normal")
                {
                    totalPriceOfTickets = numberOfPersons * 249.99;
                }
                else if (category == "VIP")
                {
                    totalPriceOfTickets = numberOfPersons * 499.99;
                }
                double difference = Math.Abs(moneyLeftForTickets - totalPriceOfTickets);
                if (moneyLeftForTickets >= totalPriceOfTickets)
                { Console.WriteLine($"Yes! You have {difference:f2} leva left."); }
                else { Console.WriteLine($"Not enough money! You need {difference:f2} leva."); }
            }
            if (numberOfPersons >= 50)
            {
                moneyLeftForTickets = budget * 0.75;
                if (category == "Normal")
                {
                    totalPriceOfTickets = numberOfPersons * 249.99;
                }
                else if (category == "VIP")
                {
                    totalPriceOfTickets = numberOfPersons * 499.99;
                }
                double difference = Math.Abs(moneyLeftForTickets - totalPriceOfTickets);
                if (moneyLeftForTickets >= totalPriceOfTickets)
                { Console.WriteLine($"Yes! You have {difference:f2} leva left."); }
                else { Console.WriteLine($"Not enough money! You need {difference:f2} leva."); }
            }
        }
    }
}
