using System;
using System.Collections.Generic;
using P05.Mordor.FoodFactorying;
using P05.Mordor.Foods;

namespace P05.Mordor
{
    public class Program
    {
        public static void Main()
        {
            List<Food> allFoods = new List<Food>();
            string[] foodPassed = Console.ReadLine().ToLower().Split();

            foreach (var item in foodPassed)
            {
                var foodFactory = new FoodFactory();
                var currentFood = foodFactory.CreteFood(item);
                allFoods.Add(currentFood);
            }

            int happines = 0;

            for (int i = 0; i < allFoods.Count; i++)
            {
                happines += allFoods[i].Points;
            }

            Console.WriteLine(happines);
            if (happines < -5)
            {
                Console.WriteLine("Angry");
            }
            else if (happines >= -5 && happines <=0)
            {
                Console.WriteLine("Sad");
            }
            else if (happines >= 1 && happines <= 15)
            {
                Console.WriteLine("Happy");
            }
            else if (happines > 15)
            {
                Console.WriteLine("JavaScript");
            }
        }
    }
}
