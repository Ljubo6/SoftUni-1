using System;
using System.Numerics;

namespace Additional_03.Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            BigInteger[] Fibonacci = new BigInteger[input];

            if (input == 1 || input == 2)
            {
                Console.WriteLine("1");
            }
            else
            {
                for (int i = 0; i < input; i++)
                {
                    Fibonacci[0] = 1;
                    Fibonacci[1] = 1;

                    if (i > 1)
                    {
                        Fibonacci[i] = Fibonacci[i - 1] + Fibonacci[i - 2];
                    }
                }
                Console.WriteLine(Fibonacci[input - 1]);
            }
        }
    }
}
