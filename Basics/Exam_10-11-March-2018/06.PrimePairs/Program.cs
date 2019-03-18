using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.PrimePairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstPair = int.Parse(Console.ReadLine());
            int secondPair = int.Parse(Console.ReadLine());
            int diff1 = int.Parse(Console.ReadLine());
            int diff2 = int.Parse(Console.ReadLine());
            bool iPrime = true;
            bool jPrime = true;

            for (int i = firstPair; i <= firstPair + diff1; i++)
            {
                for (int j = secondPair; j <= secondPair + diff2; j++)
                {
                    for (int i1 = 2; i1 <= (int)Math.Ceiling(Math.Sqrt(i)); i1++)
                    {
                        if (i % i1 == 0)
                        {
                            iPrime = false;
                            break;
                        }
                        else
                        {
                            iPrime = true;
                           
                        }
                    }

                    for (int j1 = 2; j1 <= (int)Math.Ceiling(Math.Sqrt(j)); j1++)
                    {
                        if (j % j1 == 0)
                        {
                            jPrime = false;
                            break;
                        }
                        else
                        {
                            jPrime = true;
                           
                        }
                    }

                    if (iPrime == true && jPrime == true)
                    {
                        Console.WriteLine(i + "" + j);
                    }
                    
                }
            }
        }
    }
}
