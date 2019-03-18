using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DogHouse
{
    class Program
    {
        static void Main(string[] args)
        {
        double side = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());
        double totalAreaSides = (side * side) + 2 * (side / 2) * (side / 2) + 
            (side / 2) * (height - side / 2) - (side / 5) * (side / 5);
        double totalAreRoofs = side * side;
        double greenPaint = totalAreaSides / 3;
        double redPaint = totalAreRoofs / 5;

        Console.WriteLine($"{greenPaint:f2}");
        Console.WriteLine($"{redPaint:f2}");
        }
    }
}
