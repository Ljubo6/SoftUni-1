using System;

namespace _09.Palindrome
{
    class Palindrome
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                PalindromChecker(input);
                input = Console.ReadLine();
            }
        }

        private static void PalindromChecker(string number)
        {
            char[] numberArray = number.ToCharArray();
            Array.Reverse(numberArray);
            string palindrom = new string(numberArray);

            if (number == palindrom)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}