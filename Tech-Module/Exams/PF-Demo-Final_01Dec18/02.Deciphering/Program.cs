using System;
using System.Text;

namespace _02.Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedText = Console.ReadLine();
            StringBuilder decryptedText = new StringBuilder();

            for (int i = 0; i < encryptedText.Length; i++)
            {
                if ((encryptedText[i] >= 100 && encryptedText[i] <=125) || encryptedText[i] == 35)
                {
                    decryptedText.Append((char)(encryptedText[i] - 3));
                }
                else
                {
                    Console.WriteLine("This is not the book you are looking for.");
                    return;
                }
            }

            string[] cipherElements = Console.ReadLine().Split();
            decryptedText = decryptedText.Replace(cipherElements[0], cipherElements[1]);

            Console.WriteLine(decryptedText);
        }
    }
}
