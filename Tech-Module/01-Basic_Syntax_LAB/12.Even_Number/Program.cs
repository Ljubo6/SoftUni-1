using System;

namespace _12.Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int number = int.Parse(Console.ReadLine());
                
                if (Math.Abs(number) % 2 == 1)
                {
                    Console.WriteLine("Please write an even number.");
                    continue;
                }
                else
                {
                    Console.WriteLine($"The number is: {number}");
                    break;
                }
            }
        }
    }
}
