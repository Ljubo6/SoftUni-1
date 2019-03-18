using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Sum_Reversed_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
              .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToList();

            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];
                string currentNumberString = currentNumber.ToString();
                char[] reversedNumberArray = currentNumberString.Reverse().ToArray();
                string reversedNumberString = new string(reversedNumberArray);
                currentNumber = int.Parse(reversedNumberString);
                sum = sum + currentNumber;
            }
            Console.WriteLine(sum);

        }
    }
}

