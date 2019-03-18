using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FoldSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray =
            Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int k = intArray.Length / 4;

            int[] leftArr = intArray.Take(k).ToArray();
            int[] midArr = intArray.Skip(k).Take(2 * k).ToArray();
            int[] rightArr = intArray.Skip(3 * k).Take(k).ToArray();

            Array.Reverse(leftArr);
            Array.Reverse(rightArr);

            int[] resultArr = new int[intArray.Length / 2];

            for (int i = 0; i < k; i++)
            {
                resultArr[i] = leftArr[i] + midArr[i];
                resultArr[i + k] = rightArr[i] + midArr[i+k];
            }

            Console.WriteLine(string.Join(" ", resultArr));
        }
    }
}
