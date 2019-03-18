using System;

namespace _06.Strong_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int startNumber = number;
            int sum = 0;

            while (number != 0)
            {
                int currentDigit = number % 10;
                int factorial = currentDigit;

                if (currentDigit == 0)
                {
                    factorial = 1;
                }

                for (int i = 1; i < currentDigit; i++)
                {
                    factorial = factorial * i;
                }
                sum += factorial;

                number = number / 10;
            }

            if (sum == startNumber)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
