using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RandomiseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            string[] words = new string[input.Length];

            Random rnd = new Random();

            for (int i = 0; i < input.Length; i++)
            {
                string currentWord = input[i];
                int randomIndex = rnd.Next(0, input.Length);
                string randomWord = input[randomIndex];

                input[i] = randomWord;
                input[randomIndex] = currentWord;
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine(input[i]);
            }
        }
    }
}
