using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            double GBP = double.Parse(Console.ReadLine());
            decimal USD = (decimal)GBP * 1.31M;
            Console.WriteLine($"{USD:f3}");
        }
    }
}
