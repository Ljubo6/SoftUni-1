using System;
using System.Collections.Generic;

namespace P07.CustomTuple
{
   public class Program
    {
        public static void Main()
        {
            string[] inputOne = Console.ReadLine().Split();
            var tupleOne = new CustomTuple<string, string>($"{inputOne[0]} {inputOne[1]}", inputOne[2]);

            string[] inputTwo = Console.ReadLine().Split();
            var tupleTwo = new CustomTuple<string, int>(inputTwo[0], int.Parse(inputTwo[1]));

            string[] inputThree = Console.ReadLine().Split();
            var tupleThree = new CustomTuple<int, double>(int.Parse(inputThree[0]), double.Parse(inputThree[1]));

            Console.WriteLine(tupleOne);
            Console.WriteLine(tupleTwo);
            Console.WriteLine(tupleThree);
        }
    }
}
