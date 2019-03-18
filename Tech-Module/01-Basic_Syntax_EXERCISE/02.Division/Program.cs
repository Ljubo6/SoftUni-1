using System;

namespace _02.Division
{
    class Program
    {
        static void Main(string[] args)
        {
            double inputNumber = double.Parse(Console.ReadLine());
            int[] dividers = { 10, 7, 6, 3, 2 };
            bool isFound = false;


            for (int i = 0; i < 5; i++)
            {
                if (inputNumber % dividers[i] == 0)
                {
                    Console.WriteLine($"The number is divisible by {dividers[i]}");
                    isFound = true;
                    break;
                }
            }

            if (isFound == false)
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}
