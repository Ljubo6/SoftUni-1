using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.FriendlyTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int distance = int.Parse(Console.ReadLine());
            int consumption = int.Parse(Console.ReadLine());
            double fuelPrice = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double cost = distance * consumption * fuelPrice / 100.0;
            double diff = Math.Abs(budget - cost);
            double leftoverPerPerson = budget / 5;

            if (cost <= budget)
            {
                Console.WriteLine($"You can take a trip. {diff:f2} money left.");
            }
            else
            {
                Console.WriteLine($"Sorry, you cannot take a trip. Each will receive {leftoverPerPerson:f2} money.");
            }
        }
    }
}
