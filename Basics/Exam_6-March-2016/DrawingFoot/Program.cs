using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingFoot
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.Write('/');
            for (int i = 0; i < n / 2; i++)
            {
                Console.Write('^');
            }
            Console.Write('\\');

            for (int a = 0; a < 2 * n - (4 + 2 * (n / 2)); a++)
            {
                Console.Write('_');
            }
            Console.Write('/');
            for (int i = 0; i < n / 2; i++)
            {
                Console.Write('^');
            }
            Console.WriteLine('\\');

            if (n / 2.0 > 2.0)
            {
                for (int b = 1; b <= n - 3; b++)
                {
                    Console.Write('|');
                    for (int c = 1; c <= 2 * n - 2; c++)
                    {
                        Console.Write(' ');
                    }
                    Console.WriteLine('|');
                }


                for (int e = n - 2; e <= n - 2; e++)
                {
                    Console.Write('|');
                    for (int i = 0; i < n / 2; i++)
                    {
                        Console.Write(' ');
                    }
                    Console.Write(' ');

                    for (int a = 0; a < 2 * n - (4 + 2 * (n / 2)); a++)
                    {
                        Console.Write('_');
                    }
                    Console.Write(' ');
                    for (int i = 0; i < n / 2; i++)
                    {
                        Console.Write(' ');
                    }
                    Console.WriteLine('|');
                }

            }
            else
            {
                for (int f = 1; f <= n - 2; f++)
                {
                    Console.Write('|');
                    for (int i = 1; i <= 2 * n - 2; i++)
                    {
                        Console.Write(' ');
                    }
                    Console.WriteLine('|');
                }
            }

            for (int d = n; d <= n; d++)
            {
                Console.Write('\\');
                for (int i = 0; i < n / 2; i++)
                {
                    Console.Write('_');
                }
                Console.Write('/');

                for (int a = 0; a < 2 * n - (4 + 2 * (n / 2)); a++)
                {
                    Console.Write(' ');
                }
                Console.Write('\\');
                for (int i = 0; i < n / 2; i++)
                {
                    Console.Write('_');
                }
                Console.WriteLine('/');
            }

        }
    }
}
