using System;

namespace _01.Smallest_Of_Three_Numbers
{
    class SmallestOfThree
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetTheSmallestNumber());
        }

        private static int GetTheSmallestNumber()
        {
            int smallestNumber = int.MaxValue;
            for (int i = 0; i < 3; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (currentNumber < smallestNumber)
                {
                    smallestNumber = currentNumber;
                }
            }
            return smallestNumber;
        }
    }
}
