using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_24_April_2018
{
    class Program
    {
        static void Main(string[] args)
        {
            int SquareSide = int.Parse(Console.ReadLine());
            double tileWidth = double.Parse(Console.ReadLine());
            double tileLength = double.Parse(Console.ReadLine());
            int benchWidth = int.Parse(Console.ReadLine());
            int benchLength = int.Parse(Console.ReadLine());

            double tilesNeeded = (SquareSide * SquareSide - benchLength * benchWidth) / (tileLength * tileWidth);
            double timeRequired = tilesNeeded * 0.2;

            Console.WriteLine($"{tilesNeeded:f2}");
            Console.WriteLine($"{timeRequired:f2}");
        }
    }
}
