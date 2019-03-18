using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Arrow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.Write(new string('_', n + 2));
            Console.Write("^");
            Console.WriteLine(new string('_', n + 2));

            for (int i = 0; i < n / 2 + 1; i++)
            {

            }
        }
    }
}
