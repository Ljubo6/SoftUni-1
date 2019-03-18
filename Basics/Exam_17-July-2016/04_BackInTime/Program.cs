using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_BackInTime
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyHeritage = double.Parse(Console.ReadLine());
            int yearToLiveTo = int.Parse(Console.ReadLine());
            double moneyNeededToLive = 0.0;
            int currentAge = 18;

            for (int i = 1800; i <= yearToLiveTo; i++)
            {
                if (i % 2 == 0)
                {
                    moneyNeededToLive = moneyNeededToLive + 12000;
                    currentAge++;
                }
                else
                {
                    moneyNeededToLive = moneyNeededToLive + 12000 + 50 * currentAge;
                    currentAge++;
                }
            }

            double difference = Math.Abs(moneyHeritage - moneyNeededToLive);

            if (moneyNeededToLive <= moneyHeritage)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {difference:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {difference:f2} dollars to survive.");
            }
        }
    }
}
