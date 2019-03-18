using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARRAYS
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArr = Console.ReadLine().Split(' ').ToArray();
            string[] secondArr = Console.ReadLine().Split(' ').ToArray();

            int length = Math.Min(firstArr.Length, secondArr.Length);
            int streightCounter = 0;
            int reversedCounter = 0;

            for (int i = 0; i < length; i++)
            {
                if (firstArr[i] == secondArr[i])
                {
                    streightCounter++;
                }
            }

            Array.Reverse(firstArr);
            Array.Reverse(secondArr);

            for (int i = 0; i < length; i++)
            {
                if (firstArr[i] == secondArr[i])
                {
                    reversedCounter++;
                }
            }

            if (streightCounter > reversedCounter)
            {
                Console.WriteLine(streightCounter);
            }
            else
            {
                Console.WriteLine(reversedCounter);
            }
        }
    }
}
