using System;
using System.Linq;

namespace P03.Custom_Min_Function
{
    class MinFunc
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> smallestNumber = nums => nums.Min();

            Console.WriteLine(smallestNumber(numbers));
        }
    }
}
