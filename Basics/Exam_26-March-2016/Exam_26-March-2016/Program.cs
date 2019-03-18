using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_26_March_2016
{
    class Program
    {
        static void Main(string[] args)
        {
            double VegPrice = double.Parse(Console.ReadLine());
            double FruitPrice = double.Parse(Console.ReadLine());
            int VegWeight = int.Parse(Console.ReadLine());
            int FruitWeight = int.Parse(Console.ReadLine());

            Console.WriteLine((VegPrice * VegWeight + FruitPrice * FruitWeight) / 1.94);
        }
    }
}
