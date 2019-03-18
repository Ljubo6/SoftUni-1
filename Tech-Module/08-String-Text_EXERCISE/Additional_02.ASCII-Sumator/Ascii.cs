using System;

namespace Additional_02.ASCII_Sumator
{
    class Ascii
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int bottomBoundary = Math.Min(firstChar, secondChar);
            int topBoundary = Math.Max(firstChar, secondChar);

            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (currentChar > bottomBoundary && currentChar < topBoundary)
                {
                    sum += currentChar;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
