using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_DelenieBezOstatak
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;


            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number % 4 == 0)
                {
                    p3++;
                }
                if (number % 2 == 0)
                {
                    p1++;
                    //if (number % 3 == 0) { p2++; }
                }
                if (number % 3 == 0)
                {
                    p2++;
                    //if (number % 2 == 0) { p1++; }
                }

            }
            double percent1 = (p1 / n) * 100.00;
            double percent2 = (p2 / n) * 100.00;
            double percent3 = (p3 / n) * 100.00;

            Console.WriteLine($"{percent1:f2}%");
            Console.WriteLine($"{percent2:f2}%");
            Console.WriteLine($"{percent3:f2}%");
        }
    }
}
