using System;

namespace _02.Circle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal radius = decimal.Parse(Console.ReadLine());
            decimal ciricleArea = radius * radius * (decimal)Math.PI;
            Console.WriteLine($"{ciricleArea:f12}");
        }
    }
}
