using System;

namespace _11.Multiplication_Table_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());

            if (multiplier > 10)
            {
                Console.WriteLine($"{number} X {multiplier} = " + number * multiplier );
            }
            else
            {
                for (int i = multiplier; i <= 10; i++)
                {
                    int result = number * i;
                    Console.WriteLine($"{number} X {i} = {result}");
                    result = 0;
                }
            }
        }
    }
}
