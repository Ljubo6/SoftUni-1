using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Crown
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            // TOP ROW
            Console.Write("@");
            Console.Write(new string(' ', n - 2));
            Console.Write("@");
            Console.Write(new string(' ', n - 2));
            Console.WriteLine("@");

            // TOP PART
            for (int i = 0; i < n / 2; i++)
            {
                Console.Write("*");
                Console.Write(new string('.', i));
                Console.Write("*");
                if (i == n / 2 - 1)
                {
                    Console.Write("");
                }
                else
                {
                    Console.Write(new string(' ', n - 3 - 2 * i));
                }

                if (i == 0)
                {
                    Console.Write("*");
                }
                else
                {
                    if (i == n / 2-1)
                    {
                        Console.Write(new string('.', n - 3));
                    }
                    else
                    {
                        Console.Write("*");
                        Console.Write(new string('.', 2 * i - 1));
                        Console.Write("*");
                    }
                }

                if (i == n / 2 - 1)
                {
                    Console.Write("");
                }
                else
                {
                    Console.Write(new string(' ', n - 3 - 2 * i));
                }
                Console.Write("*");
                Console.Write(new string('.', i));
                Console.WriteLine("*");
            }
            Console.Write("*");
            Console.Write(new string('.', n/2));
            Console.Write(new string('*', n / 2-2));
            Console.Write(".");
            Console.Write(new string('*', n / 2 - 2));
            Console.Write(new string('.', n / 2));
            Console.WriteLine("*");
            for (int a = 0; a < 2; a++)
            {
                Console.WriteLine(new string('*', 2 * n - 1));
            }
        }
    }
}
