using System;

namespace P08.Threeuple
{
    public class Program
    {
       public static void Main()
        {
            string[] inputOne = Console.ReadLine().Split();
            var tupleOne = new Threeuple<string, string, string>($"{inputOne[0]} {inputOne[1]}", inputOne[2], inputOne[3]);

            string[] inputTwo = Console.ReadLine().Split();
            var tupleTwo = new Threeuple<string, int, bool>(inputTwo[0], int.Parse(inputTwo[1]), inputTwo[2] == "drunk");

            string[] inputThree = Console.ReadLine().Split();
            var tupleThree = new Threeuple<string, double, string>(inputThree[0], double.Parse(inputThree[1]), inputThree[2]);

            Console.WriteLine(tupleOne);
            Console.WriteLine(tupleTwo);
            Console.WriteLine(tupleThree);
        }
    }
}
