using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SumAndProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double number = 0;
            bool isFound = true;



            for (int a = 1; a <= 9; a++)
            {
                for (int b = 9; b >= a; b--)
                {
                    for (int c = 0; c <= 9; c++)
                    {
                        for (int d = 9; d >= c; d--)
                        {
                            if (a + b + c + d == a * b * c * d && n % 10 == 5)
                            {
                                //number = a * 1000 + b * 100 + c * 10 + d;
                                Console.WriteLine(a * 1000 + b * 100 + c * 10 + d);
                                return;
                            }
                            else if ((a * b * c * d) / (a + b + c + d) == 3 && n % 3 == 0)
                            {
                                //number = d * 1000 + c * 100 + b * 10 + a;
                                Console.WriteLine(d * 1000 + c * 100 + b * 10 + a);
                                return;
                            }
                            else
                            {
                                isFound = false;
                                //Console.WriteLine("Nothing found");
                            }
                        }
                    }
                }
            }
            if (isFound == false)
            {
                Console.WriteLine("Nothing found");
            }
           

        }
    }
}
