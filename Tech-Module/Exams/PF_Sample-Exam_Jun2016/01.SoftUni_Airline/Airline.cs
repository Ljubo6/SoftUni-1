using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SoftUni_Airline
{
    class Airline
    {
        static void Main(string[] args)
        {
            int flightsNumber = int.Parse(Console.ReadLine());
            List<decimal> profits = new List<decimal>();

            for (int i = 0; i < flightsNumber; i++)
            {
                int adultCount = int.Parse(Console.ReadLine());
                decimal adultTicketPrice = decimal.Parse(Console.ReadLine());
                int youthCount = int.Parse(Console.ReadLine());
                decimal youthTicketPrice = decimal.Parse(Console.ReadLine());
                decimal fuelPriceH = decimal.Parse(Console.ReadLine());
                decimal fuelConsumptionH = decimal.Parse(Console.ReadLine());
                int flightDuration = int.Parse(Console.ReadLine());

                decimal income = adultCount * adultTicketPrice + youthCount * youthTicketPrice;
                decimal expenses = flightDuration * fuelConsumptionH * fuelPriceH;
                decimal currentFlightProfit = income - expenses;
                profits.Add(currentFlightProfit);

                if (income >= expenses)
                {
                    Console.WriteLine($"You are ahead with {currentFlightProfit:f3}$.");
                }
                else
                {
                    Console.WriteLine($"We've got to sell more tickets! We've lost {currentFlightProfit:f3}$.");
                }
            }

            Console.WriteLine($"Overall profit -> {profits.Sum():f3}$.");
            Console.WriteLine($"Average profit -> {profits.Average():f3}$.");
        }
    }
}
