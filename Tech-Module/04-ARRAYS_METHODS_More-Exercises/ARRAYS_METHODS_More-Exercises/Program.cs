using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARRAYS_METHODS_More_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Arr = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            //int currentDigit = 0;
            //int maxDigit = int.MinValue;
            //int minDigit = int.MaxValue;
            //int sum = 0;

            //for (int i = 0; i < Arr.Length; i++)
            //{
            //    currentDigit = Arr[i];

            //    if (currentDigit > maxDigit)
            //    {
            //        maxDigit = currentDigit;
            //    }

            //    if (currentDigit < minDigit)
            //    {
            //        minDigit = currentDigit;
            //    }

            //    sum = sum + currentDigit;
            //}

            //double avg = sum / (double)Arr.Length;

            Console.WriteLine($"Min = {Arr.Min()}");
            Console.WriteLine($"Max = {Arr.Max()}");
            Console.WriteLine($"Sum = {Arr.Sum()}");
            Console.WriteLine($"Average = {Arr.Average()}");
        }
    }
}
