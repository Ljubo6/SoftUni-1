using System;

namespace _10.Top_Number
{
    class TopNumber
    {
        static void Main(string[] args)
        {
            int endNumber = int.Parse(Console.ReadLine());
            FindingTopNumbers(endNumber);
        }

        private static void FindingTopNumbers(int boundary)
        {
            

            for (int i = 1; i <= boundary; i++)
            {
                int sumOfDigits = 0;
                bool hasOddDigit = false;
                int currentNumber = i;

                while (currentNumber != 0)
                {
                    int lastDigit = currentNumber % 10;
                    sumOfDigits += lastDigit;

                    if (lastDigit % 2 == 1)
                    {
                        hasOddDigit = true;
                    }

                    currentNumber /= 10;
                }

                if (hasOddDigit && sumOfDigits % 8 == 0)
                {
                    Console.WriteLine(i);
                }

            }
        }
    }
}
