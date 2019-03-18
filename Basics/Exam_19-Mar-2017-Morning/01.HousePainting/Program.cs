using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PaintingHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double totalAreaOfWalls = (x * x + x * x - 1.2 * 2) + 2 * (x * y - 1.5 * 1.5);
            double totalAreaofRoof = 2 * x * y + x * h;
            double totalLitresOfGreenPaint = totalAreaOfWalls / 3.4;
            double totalLitresOfRedPaint = totalAreaofRoof / 4.3;

            Console.WriteLine($"{totalLitresOfGreenPaint:f2}");
            Console.WriteLine($"{totalLitresOfRedPaint:f2}");
        }
    }
}
