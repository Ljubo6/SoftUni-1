using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.PIN
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.Write("/`");
            Console.Write(new string('P', n * 2));
            Console.Write(new string(' ', n));
            Console.Write("/`I");
            Console.Write(new string(' ', n));
            Console.Write("/`N");
            Console.Write(new string(' ', 2 * n + 1));
            Console.WriteLine("N");


            for (int i = 0; i <= n - 1; i++)
            {
                Console.Write("| P");
                if (i == n - 1)
                {
                    Console.Write(new string('P', n * 2 - 1));
                }
                else
                {
                    Console.Write(new string(' ', 2 * n - 2));
                    Console.Write("P");
                }
                Console.Write(new string(' ', n));
                Console.Write("| I");
                Console.Write(new string(' ', n));
                Console.Write("| N");
                Console.Write(new string(' ', i));
                Console.Write("N");
                Console.Write(new string(' ', 2 * n - i));
                Console.WriteLine("N");
            }
            for (int i = n; i <= 2 * n; i++)
            {
                if (i == 2 * n)
                {
                    Console.Write("\\_");
                    Console.Write(new string('P', n / 2));

                }
                else
                {
                    Console.Write("| ");
                    Console.Write(new string('P', n / 2));
                }

                Console.Write(new string(' ', 3 * n - n/2));
                if (i == 2 * n)
                {
                    Console.Write("\\_I");
                }
                else
                {
                    Console.Write("| I");
                }

                Console.Write(new string(' ', n));
                if (i == 2 * n)
                {
                    Console.Write("\\_N");
                }
                else
                {
                    Console.Write("| N");
                }

                Console.Write(new string(' ', i));
                Console.Write("N");
                Console.Write(new string(' ', 2 * n - i));
                Console.WriteLine("N");
            }

        }
    }
}
