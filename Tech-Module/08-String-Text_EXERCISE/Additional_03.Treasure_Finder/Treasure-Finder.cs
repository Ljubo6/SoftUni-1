using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Additional_03.Treasure_Finder
{
    class Treasure
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string message = Console.ReadLine();

            while (message != "find")
            {
                string decryptedMessage = string.Empty;

                for (int i = 0; i < message.Length; i++)
                {
                    decryptedMessage += (char)(message[i] - key[i % key.Length]);
                }

                string pattern = @"&(.*?)&.*\<(.*?)\>";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(decryptedMessage);

                Console.WriteLine($"Found {match.Groups[1]} at {match.Groups[2]}");

                message = Console.ReadLine();
            }
        }
    }
}
