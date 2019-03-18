using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Deciphering_RegEx
{
    class Deciphering_RegEx
    {
        static void Main(string[] args)
        {
            string encryptedText = Console.ReadLine();

            StringBuilder decryptedText = new StringBuilder();

            string pattern = @"[#d-}]";
            MatchCollection matches = Regex.Matches(encryptedText, pattern);
            if (encryptedText.Length > matches.Count)
            {
                Console.WriteLine("This is not the book you are looking for.");
                return;
            }
            else
            {
                for (int i = 0; i < encryptedText.Length; i++)
                {
                    decryptedText.Append((char)(encryptedText[i] - 3));
                }

                string[] cipherElements = Console.ReadLine().Split();
                decryptedText = decryptedText.Replace(cipherElements[0], cipherElements[1]);

                Console.WriteLine(decryptedText);
            }
        }
    }
}
