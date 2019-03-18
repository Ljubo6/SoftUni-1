using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Snowman
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> snowmen = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            while (snowmen.Count > 1)
            {
                for (int i = 0; i < snowmen.Count; i++)
                {
                    int targetIndex = snowmen[i] % snowmen.Count;

                    if (targetIndex == -1)
                    {
                        continue;
                    }
                    if (snowmen.Where(n => n != -1).ToList().Count == 1)
                    {
                        break;
                    }

                    int differenceValue = Math.Abs(i - targetIndex);

                    if (differenceValue % 2 == 0 && differenceValue != 0)
                    {
                        Console.WriteLine($"{i} x {targetIndex} -> {i} wins");
                        snowmen[targetIndex] = -1;
                    }
                    else if (differenceValue % 2 == 1)
                    {
                        Console.WriteLine($"{i} x {targetIndex} -> {targetIndex} wins");
                        snowmen[i] = -1;
                    }
                    else if (differenceValue == 0)
                    {
                        Console.WriteLine($"{i} performed harakiri");
                        snowmen[i] = -1;
                    }
                }
                snowmen.RemoveAll(n => n == -1);
            }
        }
    }
}