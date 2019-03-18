using System;
using System.Numerics;

namespace _08.Factorial_Division
{
    class FactorialDivision
    {
        static void Main(string[] args)
        {
            BigInteger firstFactorial = CalculatingFactorial(int.Parse(Console.ReadLine()));
            BigInteger secondFactorial = CalculatingFactorial(int.Parse(Console.ReadLine()));

            decimal result = (decimal)firstFactorial / (decimal)secondFactorial;

            Console.WriteLine($"{result:f2}");
        }

        static BigInteger CalculatingFactorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            return n * CalculatingFactorial(n - 1);
        }
    }
}
