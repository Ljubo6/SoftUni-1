using System;
using System.Numerics;

namespace _01
{
    class Party
    {
        static void Main(string[] args)
        {
            int partySize = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            
            BigInteger totalSum = 0;

            for (int i = 1; i <= days; i++)
            {
                if (i % 10 == 0)
                {
                    partySize -= 2;
                }
                if (i % 15 == 0)
                {
                    partySize += 5;
                }

                totalSum += 50 - 2 * partySize;

                if (i % 3 == 0)
                {
                    totalSum -= 3 * partySize;
                }
                if (i % 5 == 0)
                {
                    totalSum += 20 * partySize;
                }
                if (i % 15 == 0)
                {
                    totalSum -= 2 * partySize;
                }
            }

            BigInteger coinsPerCompanion = totalSum / partySize;

            Console.WriteLine($"{partySize} companions received {coinsPerCompanion} coins each.");
        }
    }
}
