using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.LadyBird
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.Write(new string(' ', n - 2));
            Console.WriteLine("@   @");

            Console.Write(new string(' ', n -1));
            Console.WriteLine("\\_/");

            Console.Write(new string(' ', n- 1));
            Console.WriteLine("/ \\");

            Console.Write(new string(' ', n- 1));
            Console.WriteLine("|_|");

            for (int i = 1; i <= n; i++)
            {
                Console.Write(new string(' ', n - i));
                Console.Write("/");
                Console.Write(new string(' ', i-1));
                Console.Write("|");
                Console.Write(new string(' ', i-1));
                Console.WriteLine("\\");
            }
            for (int a = 0; a < n/2; a++)
            {
                Console.Write("|");
                Console.Write(new string(' ', (n - 2) / 2));
                Console.Write("@");
                Console.Write(new string(' ', n - 2 - (n - 2) / 2));
                Console.Write("|");
                Console.Write(new string(' ', n - 2 - (n - 2) / 2));
                Console.Write("@");
                Console.Write(new string(' ', (n - 2) / 2));
                Console.WriteLine("|");
            }
            if (n > 2)
            {
                for (int b = 0; b < n/2; b++)
                {
                    Console.Write(new string(' ', b));
                    Console.Write("\\");
                    Console.Write(new string(' ', n  - b - 1));
                    Console.Write("|");
                    Console.Write(new string(' ', n - b - 1));
                    Console.Write("/");
                    Console.WriteLine(new string(' ', b));

                }
            }
            Console.Write(new string(' ', n - n / 2));
            Console.Write(new string('^', n / 2));
            Console.Write("|");
            Console.Write(new string('^', n / 2));
            Console.Write(new string(' ', n - n / 2));

        }
    }
}
