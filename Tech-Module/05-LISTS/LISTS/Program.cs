
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Max_Sequence_of_Equal_Elements
{
    class MaxSequenceEqualElements
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int length = 1;
            int startIndex = 0;
            int bestLength = 1;
            int bestStart = 0;

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i - 1] == numbers[i])
                {
                    length++;
                    if (length > bestLength)
                    {

                        bestLength = length;

                        bestStart = startIndex;

                    }

                }

                else

                {

                    startIndex = i;

                    length = 1;

                }

            }



            for (int i = 0; i < bestLength; i++)

            {

                Console.Write(numbers[bestStart] + " ");

            }

        }

    }

}