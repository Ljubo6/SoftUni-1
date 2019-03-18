using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Diamond
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            // ROW 1
            Console.Write(new string('.', n));
            Console.Write(new string('*', 3 * n));
            Console.WriteLine(new string('.', n));

            // TOP PART
            for (int i = 1; i < n; i++)
            {
                Console.Write(new string ('.', n - i));
                Console.Write("*");
                Console.Write(new string('.', 5 * n - 2 - 2 * (n - i)));
                Console.Write("*");
                Console.WriteLine(new string('.', n - i));
            }

            // MIDDLE ROW
            Console.WriteLine(new string ('*', 5 * n));

            // BOTTOM PART
            for (int k = n + 1; k < 3 * n + 1; k++)
            {
                Console.Write(new string ('.', k - n));
                Console.Write("*");
                Console.Write(new string('.', 5 * n - 2 - 2 * (k - n)));
                Console.Write("*");
                Console.WriteLine(new string('.', k - n));
            }

            // LAST ROW
            Console.Write(new string ('.', (5 * n - (n-2)) / 2));
            Console.Write(new string ('*', n - 2));
            Console.WriteLine(new string('.', (5 * n - (n - 2)) / 2));

        }
    }
}
