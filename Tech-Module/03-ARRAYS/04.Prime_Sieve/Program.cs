using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Prime_Sieve
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            bool[] primes = new bool[n];
            primes[0] = false;
            primes[1] = false;

            for (int p = 2; p < n; p++)
            {
                Console.Write(primes[p] + " ");

            }
        }
    }
}
