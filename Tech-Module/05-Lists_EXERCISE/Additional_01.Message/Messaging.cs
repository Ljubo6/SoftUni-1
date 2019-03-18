using System;
using System.Collections.Generic;
using System.Linq;

namespace Additional_01.Message
{
    class Messaging
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<char> text = Console.ReadLine().ToList();
            List<char> output = new List<char>();
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                int sumOfDigits = 0;
                while (currentNumber != 0)
                {
                    sumOfDigits += currentNumber % 10;
                    currentNumber /= 10;
                }
                output.Add(text[sumOfDigits % text.Count]);
                text.RemoveAt(sumOfDigits % text.Count);
            }
            Console.WriteLine(new string(output.ToArray()));
        }
    }
}
