using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.N_to_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int start = n;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(start);
                start--;
            }
        }
    }
}
