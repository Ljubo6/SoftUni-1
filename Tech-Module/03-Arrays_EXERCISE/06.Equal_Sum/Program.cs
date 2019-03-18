using System;
using System.Linq;

namespace _06.Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool isFound = false;

            for (int i = 0; i < sequence.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                for (int leftPart = 0; leftPart < i; leftPart++)
                {
                    leftSum += sequence[leftPart]; 
                }

                for (int rightPart = i+1; rightPart < sequence.Length; rightPart++)
                {
                    rightSum += sequence[rightPart];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    isFound = true;
                }
            }

            if (isFound == false)
            {
                Console.WriteLine("no");
            }
        }
    }
}
