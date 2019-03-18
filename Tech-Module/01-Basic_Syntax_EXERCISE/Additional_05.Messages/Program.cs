using System;
using System.Collections.Generic;

namespace Additional_05.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = new char[25];
            for (int i = 0; i <= 24; i++)
            {
                alphabet[i] = (char)(i + 97);
            }
            List<char> message = new List<char>();

            int input = int.Parse(Console.ReadLine());

                string input = Console.ReadLine();
                int numberEntered = 0;
                bool isNumber = int.TryParse(input, out numberEntered);

                if (isNumber)
                {
                    char[] digits = input.ToCharArray();
                    int inputLength = digits.Length;
                    int mainNumber = numberEntered % 10;

                    message.Add(alphabet[]);
                }
                
                
            

        }
    }
}
