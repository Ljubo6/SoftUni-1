using System;

namespace _01.Baking_Masterclass
{
    class Baking
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            decimal flourPrice = decimal.Parse(Console.ReadLine());
            decimal eggPrice = decimal.Parse(Console.ReadLine());
            decimal apronPrice = decimal.Parse(Console.ReadLine());

            int flourPackagesFree = students / 5;
            int apronNumber = (int)Math.Ceiling(students * 1.2);

            decimal totalPrice = (students - flourPackagesFree) * flourPrice + eggPrice * 10 * students + apronNumber * apronPrice;

            if (totalPrice <= budget)
            {
                Console.WriteLine($"Items purchased for {totalPrice:f2}$.");
            }
            else
            {
                Console.WriteLine($"{Math.Abs(totalPrice - budget):f2}$ more needed.");
            }
        }
    }
}
