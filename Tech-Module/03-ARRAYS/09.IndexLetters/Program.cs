using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.IndexLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = new char[26];

            for (int index = 0; index < alphabet.Length; index++)
            {
                alphabet[index] = (char)(97 + index);
            }

            char[] word = Console.ReadLine().ToCharArray();

            for (int index = 0; index < word.Length; index++)
            {
                Console.WriteLine(word[index] + " -> " + ((word[index])-97));
            }
        }
    }
}
