using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sumdigits = 0;

            while (number != 0)
            {
                sumdigits = sumdigits + (number % 10);
                number = number / 10;
                
            }
            Console.WriteLine(sumdigits);
        }
    }
}
