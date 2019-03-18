using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int num = 1; num <= n;)
            {
                Console.WriteLine(num);
                num = num * 2 + 1;
            }
        }
    }
}
