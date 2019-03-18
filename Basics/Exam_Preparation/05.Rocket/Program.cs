using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Rocket
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            // TOP PART
            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('.', (3 * n - 2 - 2 * i) / 2));
                Console.Write("/");
                Console.Write(new string(' ', 2 * i));
                Console.Write("\\");
                Console.WriteLine(new string('.', (3 * n - 2 - 2 * i)/ 2));
            }
            // END ROW OF TOP PART
            Console.Write(new string ('.', n / 2));
            Console.Write(new string('*', 2* n));
            Console.WriteLine(new string('.', n / 2));
            // MAIN PART
            for (int a = 0; a < 2 * n; a++)
            {
                Console.Write(new string('.', n / 2));
                Console.Write("|");
                Console.Write(new string('\\', 2 * n - 2));
                Console.Write("|");
                Console.WriteLine(new string('.', n / 2));
            }
            // BOTTOM PART
            for (int b = 0; b < n / 2; b++)
            {
                Console.Write(new string('.', n / 2 - b));
                Console.Write("/");
                Console.Write(new string('*', 2 * n - 2 + 2 * b));
                Console.Write("\\");
                Console.WriteLine(new string('.', n / 2 - b));
            }
        }
    }
}
