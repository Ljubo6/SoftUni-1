using System;
using System.Linq;

namespace P06.Reverse_Exclude
{
    class ReverseExclude
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int modulo = int.Parse(Console.ReadLine());

            var result = numbers
                .Where(x => x % modulo != 0)
                .Reverse()
                .ToList();

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
