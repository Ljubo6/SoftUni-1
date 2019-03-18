using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.Star_Enigma
{
    class StarEnigma
    {
        static void Main(string[] args)
        {
            int msgCount = int.Parse(Console.ReadLine());
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < msgCount; i++)
            {
                string input = Console.ReadLine();
                List<char> validLetters = new List<char> { 's', 't', 'a', 'r', 'S', 'T', 'A', 'R' };
                int validLettersCount = 0;
                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < input.Length; j++)
                {
                    char currentLetter = input[j];
                    if (validLetters.Contains(currentLetter))
                    {
                        validLettersCount++;
                    }
                }

                for (int k = 0; k < input.Length; k++)
                {
                    sb.Append((char)(input[k] - validLettersCount));
                }

                string decryptedText = sb.ToString();

                Regex regexPattern = new Regex(@"(?<name>(?<=@)[A-Z]*[a-z]*).*(?<population>(?<=:)\d*).*(?<type>(?<=!)[AD](?=!)).*(?<soldiers>(?<=\-\>)\d*)");
               

                Match match = regexPattern.Match(decryptedText);

                if (match.Success)
                {
                    string planetType = match.Groups["type"].ToString();
                    string name = match.Groups["name"].ToString();

                    if (planetType == "A")
                    {
                        attackedPlanets.Add(name.ToString());
                    }
                    else if (planetType == "D")
                    {
                        destroyedPlanets.Add(name.ToString());
                    }
                }
            }

            attackedPlanets.Sort();
            destroyedPlanets.Sort();

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var planet in attackedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var planet in destroyedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
