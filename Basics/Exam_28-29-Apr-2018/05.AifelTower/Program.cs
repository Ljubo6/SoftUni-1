using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.AifelTower
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('-', n + 2));
                Console.Write("**");
                Console.WriteLine(new string('-', n + 2));
            }
            for (int a = 0; a < n-3; a++)
            {
                Console.Write(new string('-', n + 1));
                Console.Write("****");
                Console.WriteLine(new string('-', n + 1));
            }
            Console.Write(new string('-', n));
            Console.Write("******");
            Console.WriteLine(new string('-', n));
            for (int b = 0; b < n-4; b++)
            {
                Console.Write(new string('-', n));
                Console.Write("**--**");
                Console.WriteLine(new string('-', n));
            }
            for (int c = 0; c < n-3; c++)
            {
                Console.Write(new string('-', n - 1));
                Console.Write("**----**");
                Console.WriteLine(new string('-', n - 1));
            }
            Console.Write(new string('-', n - 2));
            Console.Write("**********");
            Console.WriteLine(new string('-', n - 2));
            for (int d = 1; d <= n - 3; d++)
            {
                Console.Write(new string('-', n - 2 - d));
                Console.Write("**");
                Console.Write(new string('-', 2 * n + 2 - 2 * (n - 2 - d)));
                Console.Write("**");
                Console.WriteLine(new string('-', n - 2 - d));
            }
            Console.Write("***");
            Console.Write(new string('-', 2 * n));
            Console.WriteLine("***");
        }
    }
}
