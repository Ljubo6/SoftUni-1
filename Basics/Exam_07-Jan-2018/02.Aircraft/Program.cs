using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Aircraft
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int t = int.Parse(Console.ReadLine());

            int mins = (m + t) % 60;
            int hours = h + (m + t) / 60;
            if (hours >= 24)
            {
                hours = hours - 24;
            }
            Console.WriteLine($"{hours}h {mins}m");

        }

    }
}
