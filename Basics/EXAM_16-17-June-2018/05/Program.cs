using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n - 2; i++)
            {
                Console.Write(new string(' ', 2));
                Console.Write("||");
                Console.Write(new string('_', n -2));
                Console.WriteLine("||");
            }
            Console.Write(new string(' ', 1));
            Console.Write("//");
            Console.Write(new string(' ', n));
            Console.WriteLine("\\\\");

            for (int b = 1; b <= n - 4; b++)
            {
                Console.Write("||");
                Console.Write(new string(' ', n + 2));
                if (n % 2 == 0 && b == (n - 4) / 2)
                {
                    Console.WriteLine("||]");
                }
                else if (n % 2 == 1 && b == (n - 4) / 2 + 1)
                {
                    Console.WriteLine("||]");
                }
                else
                {
                    Console.WriteLine("||");
                }

               
            }
            Console.Write(new string(' ', 1));
            Console.Write("\\\\");
            Console.Write(new string(' ', n));
            Console.WriteLine("//");

            for (int i = 0; i < n - 2; i++)
            {
                Console.Write(new string(' ', 2));
                Console.Write("||");
                Console.Write(new string('_', n - 2));
                Console.WriteLine("||");
            }
        }
    }
}
