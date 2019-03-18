using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.CarNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                for (int a = start; a <= end; a++)
                {
                    for (int b = start; b <= end; b++)
                    {
                        for (int c = start; c <= end; c++) 
                        {
                            if ((a + b) % 2 == 0 && i > c && (i + c) % 2 == 1)
                            {
                                Console.Write(i+""+a+""+b+""+c+" ");
                            }
                        }
                    }
                }
            }
        }
    }
}
