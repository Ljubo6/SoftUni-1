using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Mask
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n - 1; i++)
            {
                Console.Write(new string(' ', (2 * n + 2 - 6) / 2 - i));
                Console.Write("/");
                Console.Write(new string(' ', i));
                Console.Write("|  |");
                Console.Write(new string(' ', i));
                Console.Write("\\");
                Console.WriteLine(new string(' ', (2 * n + 2 - 6) / 2 - i));
            }
            Console.WriteLine(new string('-', 2 * n + 2));

            Console.Write("|");
            Console.Write(new string(' ', n / 3));
            Console.Write("_");
            Console.Write(new string(' ',2 * n - 2 - 2 * (n / 3)));
            Console.Write("_");
            Console.Write(new string(' ', n / 3));
            Console.WriteLine("|");

            Console.Write("|");
            Console.Write(new string(' ', n / 3));
            Console.Write("@");
            Console.Write(new string(' ', 2 * n - 2 - 2 * (n / 3)));
            Console.Write("@");
            Console.Write(new string(' ', n / 3));
            Console.WriteLine("|");

            for (int a = 0; a < n/2; a++)
            {
                Console.Write("|");
                Console.Write(new string(' ', 2 * n));
                Console.WriteLine("|");
            }

            Console.Write("|");
            Console.Write(new string(' ', n - 1));
            Console.Write("OO");
            Console.Write(new string(' ', n - 1));
            Console.WriteLine("|");

            Console.Write("|");
            Console.Write(new string(' ', n - 2));
            Console.Write("/");
            Console.Write("  ");
            Console.Write("\\");
            Console.Write(new string(' ', n - 2));
            Console.WriteLine("|");

            Console.Write("|");
            Console.Write(new string(' ', n - 2));
            Console.Write("||||");
            Console.Write(new string(' ', n - 2));
            Console.WriteLine("|");
            for (int b = 1; b <= n + 1; b++)
            {
                Console.Write(new string('\\', b));
                Console.Write(new string('`', 2 * n + 2 - 2 * b));
                Console.WriteLine(new string('/', b));


            }
        }
    }
}
