using System;
using System.Linq;

namespace _05.Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                bool isBigger = false;
                for (int a = i + 1; a < numbers.Length; a++)
                {
                    if (numbers[i] > numbers[a])
                    {
                        isBigger = true;
                    }
                    else
                    {
                        isBigger = false;
                        break;
                    }
                }
                if (isBigger == true)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
            Console.WriteLine(numbers.Last());
        }
    }
}
