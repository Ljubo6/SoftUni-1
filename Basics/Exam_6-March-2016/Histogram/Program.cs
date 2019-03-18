using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1 = 0.0;
            double p2 = 0.0;
            double p3 = 0.0;
            double p4 = 0.0;
            double p5 = 0.0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 1 && number > 1000) { Console.WriteLine("Invalid number"); }
                else if (number >= 1 && number < 200) { p1++; }
                else if (number >= 200 && number < 400) { p2++; }
                else if (number >= 400 && number < 600) { p3++; }
                else if (number >= 600 && number < 800) { p4++; }
                else if (number >= 800 && number <= 1000) { p5++; }
            }

                double p1share = p1 / n * 100.00;
                double p2share = p2 / n * 100.00;
                double p3share = p3 / n * 100.00;
                double p4share = p4 / n * 100.00;
                double p5share = p5 / n * 100.00;

                Console.WriteLine(Math.Round(p1share, 2) + "%");
                Console.WriteLine(Math.Round(p2share, 2) + "%");
                Console.WriteLine(Math.Round(p3share, 2) + "%");
                Console.WriteLine(Math.Round(p4share, 2) + "%");
                Console.WriteLine(Math.Round(p5share, 2) + "%");
            
        }
    }
}
