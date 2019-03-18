using System;
using System.Linq;

namespace _03.Zig_Zag_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            int[] firstString = new int[lines];
            int[] secondString = new int[lines];

            for (int i = 0; i < lines; i++)
            {
                int[] currentLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (i % 2 == 1)
                {
                    Array.Reverse(currentLine);
                }

                firstString[i] = currentLine[0];
                secondString[i] = currentLine[1];
            }
            Console.WriteLine(String.Join(' ', firstString));
            Console.WriteLine(String.Join(' ', secondString));

        }
    }
}
