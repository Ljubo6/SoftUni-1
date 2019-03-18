using System;
using System.Linq;

namespace _08.Letters_Change_Numbers
{
    class ChangeNumbers
    {
        static void Main(string[] args)
        {
            char[] smallLetters = new char[27];
            char[] capitalLetters = new char[27];

            for (int i = 1; i <= 26; i++)
            {
                capitalLetters[i] = (char)(64 + i);
                smallLetters[i] = (char)(96 + i);
            }

            string[] input = Console
                .ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            decimal result = 0M;

            for (int i = 0; i < input.Length; i++)
            {
                string currentString = input[i];
                decimal currentNumber = decimal.Parse(currentString.Substring(1, currentString.Length-2));

                char firstLetter = currentString[0];
                if (Char.IsUpper(firstLetter))
                {
                    currentNumber /= Array.IndexOf(capitalLetters, firstLetter);
                }
                else
                {
                    currentNumber *= Array.IndexOf(smallLetters, firstLetter);
                }

                char secondLetter = currentString[currentString.Length - 1];
                if (Char.IsUpper(secondLetter))
                {
                    currentNumber -= Array.IndexOf(capitalLetters, secondLetter);
                }
                else
                {
                    currentNumber += Array.IndexOf(smallLetters, secondLetter);
                }

                result += currentNumber;
            }
            Console.WriteLine($"{result:f2}");
        }
    }
}
