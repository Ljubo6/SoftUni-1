using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Largest_Three_Nums
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            var result = input.OrderByDescending(x => x).Take(3);
            Console.WriteLine(String.Join(" ", result));

        }
    }
}
