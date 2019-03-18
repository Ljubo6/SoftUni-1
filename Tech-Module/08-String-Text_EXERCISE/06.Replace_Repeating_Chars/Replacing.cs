using System;
using System.Linq;

namespace _06.Replace_Repeating_Chars
{
    class Replacing
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = string.Empty;

            for (int i = 0; i < input.Length-1; i++)
            {
                char currentCharacter = input[i];
                if (currentCharacter == input[i+1])
                {
                    continue;
                }
                else
                {
                    result += currentCharacter;
                }
            }

            result += input.Last();
            Console.WriteLine(result);
        }
    }
}
