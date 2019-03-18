using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            decimal km = meters / 1000M;
            Console.WriteLine($"{km:f2}");
        }
    }
}
