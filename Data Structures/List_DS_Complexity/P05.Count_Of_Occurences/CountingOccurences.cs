using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.Count_Of_Occurences
{
    class CountingOccurences
    {
        //Program does not work for negative and very big numbers close to int Max Value

        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            /*Taking the biggest element for sizing an array which will hold 
             the times each element has occured (plus one to include zero)*/
            int arraySize = numbers.Max() + 1;
            int[] result = new int[arraySize];

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentDigit = numbers[i];
                
                //incrementing the value of each index that corresponds to a number occured in the given sequence
                result[currentDigit]++;
            }

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] > 0)
                {
                    //printing those occured only
                    Console.WriteLine($"{i} -> {result[i]} times");
                }
            }
        }
    }
}
