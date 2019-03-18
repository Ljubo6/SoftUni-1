using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Peperuda
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n - 2; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(new string('*', n-2));
                    Console.Write("\\ /");
                    Console.WriteLine(new string ('*', n - 2));
                }
                else
                {
                    Console.Write(new string('-', n - 2));
                    Console.Write("\\ /");
                    Console.WriteLine(new string('-', n - 2));
                }
            }
            Console.Write(new string(' ', n - 1));
            Console.WriteLine("@");
            for (int a = n; a <= 2 * (n - 2) + 1; a++)
            {
                if (a % 2 == 0)
                {
                    Console.Write(new string('-', n - 2));
                    Console.Write("/ \\");
                    Console.WriteLine(new string('-', n - 2));
                }
                else
                {
                    Console.Write(new string('*', n - 2));
                    Console.Write("/ \\");
                    Console.WriteLine(new string('*', n - 2));
                }
            }
        }
    }
}
