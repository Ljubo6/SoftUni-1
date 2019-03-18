using System;
using System.Linq;

namespace Additional_02
{
    class Program
    {
        static void SummingDigits(long number)
        {
            long sum = 0;
            number = Math.Abs(number);
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }
            Console.WriteLine(sum);
        }

        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                long[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                if (numbers[0] > numbers[1])
                {
                    SummingDigits(numbers[0]);
                }
                else
                {
                    SummingDigits(numbers[1]);
                }
            }
        }
    }
}
