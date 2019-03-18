using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PairsOfDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfNums = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int difference = int.Parse(Console.ReadLine());

            int currentNumber = 0;
            int diffCounter = 0;

            for (int index = 0; index < arrayOfNums.Length; index++)
            {
                currentNumber = arrayOfNums[index];

                for (int j = index + 1; j < arrayOfNums.Length; j++)
                {
                    if (Math.Abs(currentNumber - arrayOfNums[j]) == difference)
                    {
                        diffCounter++;
                    }
                }
            }
            Console.WriteLine(diffCounter);
        }
    }
}
