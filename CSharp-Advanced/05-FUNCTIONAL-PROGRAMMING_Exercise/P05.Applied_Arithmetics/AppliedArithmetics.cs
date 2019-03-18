using System;
using System.Linq;

namespace P05.Applied_Arithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            Func<int[], int[]> adding = array => array.Select(x => x + 1).ToArray();
            Func<int[], int[]> subtracting = array => array.Select(x => x - 1).ToArray();
            Func<int[], int[]> multiplyng = array => array.Select(x => 2 * x).ToArray();
            Action<int[]> print = array => Console.WriteLine(string.Join(' ', array));


            while (command != "end")
            {
                if (command == "add")
                {
                    numbers = adding(numbers);
                }
                else if (command == "subtract")
                {
                    numbers = subtracting(numbers);
                }
                else if (command == "multiply")
                {
                    numbers = multiplyng(numbers);
                }
                else if (command == "print")
                {
                    print(numbers);
                }
                command = Console.ReadLine();
            }
        }
    }
}
