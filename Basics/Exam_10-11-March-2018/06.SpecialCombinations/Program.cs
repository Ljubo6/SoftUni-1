using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SpecialCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            for (int i = 1; i <= a; i++)
            {
                for (int j = 1; j <= b; j++)
                {
                    for (int k = 1; k <= c; k++)
                    {
                        if ((i % 2 == 0 && k % 2 == 0) && (j == 2 || j == 3 || j == 5 || j == 7))
                        {
                            Console.WriteLine(i+" "+j+" "+k);
                        }
                        
                           
                    }
                }
            }
        }
    }
}
