using System;

namespace _06.Middle_Character
{
    class MiddleChar
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            GettingMiddleChar(text);
        }

        private static void GettingMiddleChar(string text)
        {
            if (text.Length % 2 == 1)
            {
                Console.WriteLine(text[(int)Math.Floor(text.Length / 2.0)]);
                
            }
            else
            {
                Console.Write(text[text.Length / 2 - 1]);
                Console.WriteLine(text[text.Length / 2]);
            }
        }
    }
}
