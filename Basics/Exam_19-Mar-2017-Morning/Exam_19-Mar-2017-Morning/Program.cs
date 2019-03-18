using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_19_Mar_2017_Morning
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCups = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            double totalWorkingHours = workers * days * 8;
            int totalCups = (int)(totalWorkingHours / 5);
            double moneyDiff = Math.Abs(numberCups - totalCups) * 4.20;

            if (numberCups > totalCups)
            {
                Console.WriteLine($"Losses: {moneyDiff:f2}");
            }
            else if(numberCups <= totalCups)
            {
                Console.WriteLine($"{moneyDiff:f2} extra money");
            }
        }
    }
}
