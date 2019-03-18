using System;

namespace _02.Vowels_Count
{
    class Counting_Vowels
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            Console.WriteLine(CountingVowels(input));
        }

        private static int CountingVowels(string inputText)
        {
            int counter = 0;
            for (int i = 0; i < inputText.Length; i++)
            {
                if (inputText[i] == 'a' || inputText[i] == 'e' || inputText[i] == 'i' ||
                    inputText[i] == 'o' || inputText[i] == 'u')
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
