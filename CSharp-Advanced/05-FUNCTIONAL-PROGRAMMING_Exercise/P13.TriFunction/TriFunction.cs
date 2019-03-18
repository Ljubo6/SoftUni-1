using System;
using System.Linq;

namespace P13.TriFunction
{
    class TriFunction
    {
        static void Main(string[] args)
        {
            int asciiSum = int.Parse(Console.ReadLine());
           
            Func<string, int, bool> validName = (name, sum) => name.Select(x => (int)x).Sum() >= asciiSum;

            var result = Console.ReadLine()
                .Split()
                .Where(validName)
               .FirstOrDefault();
           
            Console.WriteLine(result);
        }
    }
}
