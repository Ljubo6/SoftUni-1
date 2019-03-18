using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.FoodShortage
{
    public class StartUp
    {
        public static void Main()
        {
            List<IBuyer> allBuyers = new List<IBuyer>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split();
                allBuyers.Add(BuyerFactory.CreateEntity(input));
            }

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "End")
                {
                    break;
                }

                if (allBuyers.Any(x => x.Name == name))
                {
                    allBuyers.First(x => x.Name == name).BuyFood();
                }
            }

            Console.WriteLine(allBuyers.Sum(x => x.Food));
        }
    }
}
