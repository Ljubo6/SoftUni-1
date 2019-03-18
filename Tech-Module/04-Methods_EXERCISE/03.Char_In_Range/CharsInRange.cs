using System;

namespace _03.Chars_In_Range
{
    class CharsInRange
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            
            PrintCharsInRange((char)Math.Min(firstChar,secondChar),
                (char)Math.Max(firstChar, secondChar));
        }

        private static void PrintCharsInRange(char start, char end)
        {
            for (char i = (char)(start+1); i < end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
