using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTS_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> resultSet = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > 0)
                {
                    resultSet.Add(numbers[i]);
                }
            }

            resultSet.Reverse();

            if (resultSet.Capacity > 0)
            {
                Console.WriteLine(String.Join(" ", resultSet));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
