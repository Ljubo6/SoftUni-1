using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SoftUni_logo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < 2*n; i++)
            {
                Console.Write(new string('.', ((12 * n - 5 - (6 * i + 1))) / 2));
                Console.Write(new string('#', 6 * i + 1));
                Console.WriteLine(new string('.', ((12 * n - 5 - (6 * i + 1))) / 2));

            }
            for (int a = 2 * n; a < 2 * n + n - 2; a++)
            {
                Console.Write("|");
                Console.Write(new string('.', (12 * n - 5 - (6 * n + 1)) / 2 - 1));
                Console.Write(new string('#', (12 * n - 5)));
                Console.WriteLine(new string('.', (12 * n - 5 - (6 * n + 1)) / 2));
            }
        }
    }
}
