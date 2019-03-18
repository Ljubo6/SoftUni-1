using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_StopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int lowestNumber = int.Parse(Console.ReadLine());
            int highestNumber = int.Parse(Console.ReadLine());
            int stopNumber = int.Parse(Console.ReadLine());

            for (int i = highestNumber; i >= lowestNumber; i--)
            {
                if (i % 6 == 0 && i != stopNumber)
                {
                    Console.Write($"{i} ");
                }
                if (i % 6 == 0 && i == stopNumber) { break; }
            }               
        }
    }
}
