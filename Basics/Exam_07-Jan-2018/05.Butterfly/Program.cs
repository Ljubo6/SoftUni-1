using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Butterfly
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //TOP PART
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write(String.Join("",Enumerable.Repeat("*\\", i + 1)));
                Console.Write(new string(' ', 4 * n - 4 - 4 * (i + 1)));
                Console.WriteLine(String.Join("", Enumerable.Repeat("/*", i + 1)));
            }
            Console.WriteLine(String.Join("", Enumerable.Repeat("\\/", 2 * n - 2)));
            for (int i = 0; i < n / 2; i++)
            {
                Console.Write(new string('<', 2 * n - 5));
                Console.Write("*|**|*");
                Console.WriteLine(new string('>', 2 * n - 5));
            }
            Console.WriteLine(String.Join("", Enumerable.Repeat("/\\", 2 * n - 2)));

            for (int i = n - 2; i >= 0; i--)
            {
                Console.Write(String.Join("", Enumerable.Repeat("*/", i + 1)));
                Console.Write(new string(' ', 4 * n - 4 - 4 * (i + 1)));
                Console.WriteLine(String.Join("", Enumerable.Repeat("\\*", i + 1)));
            }
        }
    }
}
