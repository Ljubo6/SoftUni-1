using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SublimeLogo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write(new string(' ', 2 * n - 2 - 2 * i));
                Console.WriteLine(new string('*', 2 * (1 + i)));
            }
            for (int a = 1; a <=2; a++)
            {
                Console.Write(new string('*', 2 * n - 2 * a));
                Console.WriteLine(new string(' ', 2 * a));
            }
            for (int b = 1; b <= 2; b++)
            {
                Console.Write(new string('*', 2 * n - (2 + 2 * b)));
                Console.WriteLine(new string(' ', 2));
            }
           
        }
    }
}
