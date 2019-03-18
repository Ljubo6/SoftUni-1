using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int start = 1;
            int step = 0;
            for (int i = 0; i <= n / 3; i++)
            {
                Console.WriteLine(start + step);
                step += 3;
            }
        }
    }
}
