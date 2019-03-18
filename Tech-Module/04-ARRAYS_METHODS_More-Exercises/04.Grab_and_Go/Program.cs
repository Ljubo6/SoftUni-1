using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Grab_and_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int controlNumber = int.Parse(Console.ReadLine());

            int lastPosition = 0;
            int sum = 0;
            bool isFound = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == controlNumber)
                {
                    lastPosition = i;
                    isFound = true;
                }
            }
            for (int i = 0; i < lastPosition; i++)
            {
                sum = sum + numbers[i];
            }

            if (isFound == true)
            {
                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine("No occurrences were found!");
            }

        }
    }
}
