using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Marguerita
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.Write("'&$");
            Console.WriteLine(new string('\'', 8 * n - 1));
            for (int i = 0; i < n - 1; i++)
            {
                Console.Write(new string('\'', 2 + i));
                Console.Write("\\");
                Console.WriteLine(new string('\'', 8 * n + 1 - 2 - i));
            }
            Console.Write(String.Join("", Enumerable.Repeat("^*", 4 * n)));
            Console.WriteLine("^\'");
            for (int a = 0; a < n - 1; a++)
            {
                Console.Write(new string('\'', a));
                Console.Write("\\\\");
                Console.Write(new string(' ', n));
                Console.Write("\\");
                Console.Write(new string(' ', 7 * n - 4 - 2 * a));
                Console.Write("//");
                Console.WriteLine(new string('\'', a + 1));
            }
            for (int a = n - 1; a <= 3 * n + n - 2; a++)
            {
                Console.Write(new string('\'', a));
                Console.Write("\\");
                if (a == n-1)
                {
                    Console.Write(new string('~', 8 * n - a - a - 1));
                }
                else if (a == 2 * n - 2)
                {
                    Console.Write(new string('_', 8 * n - a - a - 1));
                }
                else if (a == 2 * n - 1)
                {
                    Console.Write(new string('.', 8 * n - a - a - 1));
                }
                else if (a == 3 * n + n - 2)
                {
                    Console.Write(new string('_', 8 * n - a - a - 1));
                }
                else
                {
                    Console.Write(new string(' ', 8 * n - a - a - 1));
                }
                Console.Write("/");
                Console.WriteLine(new string('\'', a + 1));
            }
            for (int b = 0; b < 2 * n + 1; b++)
            {
                Console.Write(new string('\'', 4 * n - 1));
                Console.Write("|||");
                Console.WriteLine(new string('\'', 4 * n));
            }
            Console.Write(new string('_', 8 * n + 1));
            Console.WriteLine("'");

            Console.Write("'");
            Console.Write(new string('-', 8 * n - 1));
            Console.WriteLine("''");
        }
    }
}
