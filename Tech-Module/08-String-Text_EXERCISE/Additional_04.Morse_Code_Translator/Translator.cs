using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Additional_04.Morse_Code_Translator
{
    class Translator
    {
        static void Main(string[] args)
        {
            Dictionary<string, char> morseToAlphabet = new Dictionary<string, char>()
            {
                { ".-", 'A' },
                { "-...", 'B' }, 
                {"-.-.", 'C'},
                {"-..", 'D'},
                {".", 'E'},
                {"..-.", 'F'},
                {"--.", 'G'},
                {"....", 'H'},
                {"..", 'I'},
                {".---", 'J'},
                {"-.-", 'K'},
                {".-..", 'L'},
                {"--", 'M'},
                {"-.", 'N'},
                {"---", 'O'},
                {".--.", 'P'},
                {"--.-", 'Q'},
                {".-.", 'R'},
                {"...", 'S'},
                {"-", 'T'},
                {"..-", 'U'},
                {"...-", 'V'},
                {".--", 'W'},
                {"-..-", 'X'},
                {"-.--", 'Y'},
                {"--..", 'Z'},
                {"|", ' ' }
            };

            string[] morseText = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string decpryptedText = string.Empty;

            for (int i = 0; i < morseText.Length; i++)
            {
                decpryptedText += morseToAlphabet[morseText[i]];
            }

            Console.WriteLine(decpryptedText);

        }
    }
}
