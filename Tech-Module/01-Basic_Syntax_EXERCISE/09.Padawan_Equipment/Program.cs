using System;

namespace _09.Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amount = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            int lightsaberCount = (int)Math.Ceiling(studentsCount * 1.1);
            int beltsCount = studentsCount - studentsCount / 6;

            double totalCost = lightsaberCount * lightsaberPrice + robePrice * studentsCount + beltsCount * beltPrice;

            if (totalCost <= amount)
            {
                Console.WriteLine($"The money is enough - it would cost {totalCost:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {Math.Abs(totalCost - amount):f2}lv more.");
            }
        }
    }
}
