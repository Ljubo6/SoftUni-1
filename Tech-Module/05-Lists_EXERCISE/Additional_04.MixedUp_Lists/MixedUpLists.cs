using System;
using System.Collections.Generic;
using System.Linq;

namespace Additional_04.MixedUp_Lists
{
    class MixedUpLists
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> resultList = new List<int>();

            secondList.Reverse();

            while (firstList.Count != 0 && secondList.Count != 0)
            {
                resultList.Add(firstList[0]);
                resultList.Add(secondList[0]);
                firstList.RemoveAt(0);
                secondList.RemoveAt(0);
            }

            resultList.Sort();

            int begin = 0;
            int end = 0;

            if(firstList.Any())
            {
                begin = Math.Min(firstList[0], firstList[1]);
                end = Math.Max(firstList[0], firstList[1]);
            }
            else
            {
                begin = Math.Min(secondList[0], secondList[1]);
                end = Math.Max(secondList[0], secondList[1]);
            }

            foreach (int number in resultList)
            {
                if (number > begin && number < end)
                {
                    Console.Write(number + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
