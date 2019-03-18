using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SkyScrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n - 3; i++)
            {
                Console.Write(new string(' ', n));
                Console.Write("|");
                Console.WriteLine(new string(' ', n));
            }
            Console.Write(new string(' ', n-1));
            Console.Write("_|_");
            Console.WriteLine(new string(' ', n-1));
            for (int a = 0; a < n - 3; a++)
            {
                Console.Write(new string(' ', n - 1));
                Console.Write("|-|");
                Console.WriteLine(new string(' ', n - 1));
            }
            Console.Write(new string(' ', n - 2));
            Console.Write("_|-|_");
            Console.WriteLine(new string(' ', n - 2));
            for (int a = 0; a < n - 3; a++)
            {
                Console.Write(new string(' ', n - 2));
                Console.Write("|***|");
                Console.WriteLine(new string(' ', n - 2));
            }
            Console.Write(new string(' ', n - 3));
            Console.Write("_|***|_");
            Console.WriteLine(new string(' ', n - 3));
        }
    }
}
