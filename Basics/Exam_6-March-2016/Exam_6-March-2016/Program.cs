using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_6_March_2016
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double heigth = double.Parse(Console.ReadLine());

            if (3 <= heigth && heigth <= width && width <= 100)
            {

                width = width * 100.00;
                heigth = heigth * 100.00;

                double rows = Math.Floor((heigth - 100) / 70);
                double columns = Math.Floor(width / 120);

                Console.WriteLine(rows * columns - 3);
            }
            else { Console.WriteLine("Invalid number"); }
        }
    }
}
