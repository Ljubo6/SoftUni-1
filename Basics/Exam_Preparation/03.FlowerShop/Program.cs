using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int hrizantemiCount = int.Parse(Console.ReadLine());
            int roziCount = int.Parse(Console.ReadLine());
            int tulipsCount = int.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();
            char holiday = char.Parse(Console.ReadLine());

            int totalFlowersBought = hrizantemiCount + roziCount + tulipsCount;
            double hrizantemiPrice = 0.00;
            double roziPrice = 0.00;
            double tulipsPrice = 0.00;
            double allFlowersPrice = 0.00;

            if (season == "spring" || season == "summer")
            {
                hrizantemiPrice = 2.00;
                roziPrice = 4.10;
                tulipsPrice = 2.50;
                
                allFlowersPrice = hrizantemiCount * hrizantemiPrice + roziCount * roziPrice + tulipsCount * tulipsPrice;
                if (holiday == 'Y')
                {
                    allFlowersPrice = allFlowersPrice * 1.15;
                }
                if (season == "spring" && tulipsCount > 7 )
                {
                    allFlowersPrice = allFlowersPrice * 0.95;
                }
                if (totalFlowersBought > 20)
                {
                    allFlowersPrice = allFlowersPrice * 0.8;
                }

                double totalPrice = allFlowersPrice + 2;
                Console.WriteLine($"{totalPrice:f2}");

            }


            if (season == "autumn" || season == "winter")
            {
                hrizantemiPrice = 3.75;
                roziPrice = 4.50;
                tulipsPrice = 4.15;

                allFlowersPrice = hrizantemiCount * hrizantemiPrice + roziCount * roziPrice + tulipsCount * tulipsPrice;
                if (holiday == 'Y')
                {
                    allFlowersPrice = allFlowersPrice * 1.15;
                }
                if (season == "winter" && roziCount >= 10)
                {
                    allFlowersPrice = allFlowersPrice * 0.9;
                }
                if (totalFlowersBought > 20)
                {
                    allFlowersPrice = allFlowersPrice * 0.8;
                }

                double totalPrice = allFlowersPrice + 2;
                Console.WriteLine($"{totalPrice:f2}");

            }
        }
    }
}
