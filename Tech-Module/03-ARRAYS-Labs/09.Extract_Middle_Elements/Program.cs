using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Extract_Middle_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int elementCount = numbers.Length;

            if (elementCount == 1)
            {
                Console.WriteLine(numbers[0]);
            }
            else if (elementCount % 2 == 0)
            {
                Console.WriteLine(numbers[numbers.Length / 2 - 1] + " " + numbers[numbers.Length / 2]);
            }
            else if (elementCount % 2 == 1)
            {
                Console.WriteLine(numbers[numbers.Length / 2 - 1] + " " 
                    + numbers[numbers.Length / 2] + " " 
                    + numbers[numbers.Length / 2 + 1]);
            }
        }
    }
}
