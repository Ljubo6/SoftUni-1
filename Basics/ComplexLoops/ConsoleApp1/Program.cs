    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int number = int.Parse(Console.ReadLine());
                bool isPrime = true;
         
                if (number < 2)
                {
                    isPrime = false;
                }
                else
                {
                    for (int i = 2; i <= Math.Sqrt(number); i++)
                    {
                        if (number % i == 0) { isPrime = false; }
                    }
                }
                if (isPrime)
                {
                    Console.WriteLine("Prime");
                }
                else
                {
                    Console.WriteLine("Not Prime");
                }
            }
        }
    }
