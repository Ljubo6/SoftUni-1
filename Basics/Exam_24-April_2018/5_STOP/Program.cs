using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_STOP
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.Write(new string('.', n + 1));
            Console.Write(new string('_', 2 * n + 1));
            Console.WriteLine(new string('.', n + 1));

            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('.', n - i));
                Console.Write("//");
                Console.Write(new string('_', 2 * n - 1 + 2 * i));
                Console.Write("\\\\");
                Console.WriteLine(new string('.', n - i));
            }
            Console.Write("//");
            Console.Write(new string('_', (n * 4 + 3 - 9) / 2));
            Console.Write("STOP!");
            Console.Write(new string('_', (n * 4 + 3 - 9) / 2));
            Console.WriteLine("\\\\");

            for (int a = n + 1; a <= 2 * n; a++)
            {
                Console.Write(new string('.', a - n - 1));
                Console.Write("\\\\");
                Console.Write(new string('_', n * 4 - 1 - 2 * (a - n - 1)));
                Console.Write("//");
                Console.WriteLine(new string('.', a - n - 1));

            }
        }
    }
}
