using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.HourGlass
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n % 2 == 0)
            {
                Console.WriteLine("Enter an odd number.");
            }
            //  FIRST ROW
            Console.WriteLine(new string('*', 2 * n + 1));
            // SECOND ROW
            Console.Write(".");
            Console.Write("*");
            Console.Write(new string(' ', 2 * n + 1 - 4));
            Console.Write("*");
            Console.WriteLine(".");
            // TOP PART
            for (int i = 1; i <= n - 2; i++)
            {
                Console.Write(new string('.', i + 1));
                Console.Write("*");
                Console.Write(new string('@', 2 * n + 1 - 2 * (i + 1) - 2));
                Console.Write("*");
                Console.WriteLine(new string('.', i + 1));
            }
            // MIDDLE ROW
            Console.Write(new string('.', n));
            Console.Write("*");
            Console.WriteLine(new string('.', n));
            //BOTTOM PART
            for (int a = 0; a < n - 2; a++)
            {
                Console.Write(new string('.', n - 1 - a));
                Console.Write("*");
                Console.Write(new string(' ', a));
                Console.Write("@");
                Console.Write(new string(' ', a));
                Console.Write("*");
                Console.WriteLine(new string('.', n - 1 - a));
            }
            // FINISHING ROW
            Console.Write(".");
            Console.Write("*");
            Console.Write(new string('@', 2 * n + 1 - 4));
            Console.Write("*");
            Console.WriteLine(".");
            //  LAST ROW
            Console.WriteLine(new string('*', 2 * n + 1));
        }
    }
}
