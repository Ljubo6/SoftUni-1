using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Dance_Award
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n / 2; i++)
            {
                Console.Write(new string('.', n + i));
                Console.Write(new string('#', 3 * n - 2 * i));
                Console.WriteLine(new string('.', n + i));
            }
            for (int a = 0; a < n / 2 + 1; a++)
            {
                Console.Write(new string('.', (3 * n) / 2 + a));
                Console.Write('#');
                Console.Write(new string('.', (5 * n) - 2 - (3 * n) - 2 * a));
                Console.Write('#');
                Console.WriteLine(new string('.', (3 * n) / 2 + a));
            }
            Console.Write(new string('.', 2 * n));
            Console.Write(new string('#', n));
            Console.WriteLine(new string('.', 2 * n));
            for (int b = 0; b < n / 2; b++)
            {
                Console.Write(new string('.', 2 * n - 2));
                Console.Write(new string('#', n + 4));
                Console.WriteLine(new string('.', 2 * n - 2));
            }
            Console.Write(new string('.', ((5 * n) - 10) / 2));
            Console.Write("D^A^N^C^E^");
            Console.WriteLine(new string('.', ((5 * n) - 10) / 2));
            for (int c = 0; c < n / 2 + 1; c++)
            {
                Console.Write(new string('.', 2 * n - 2));
                Console.Write(new string('#', n + 4));
                Console.WriteLine(new string('.', 2 * n - 2));
            }
        }
    }
}
