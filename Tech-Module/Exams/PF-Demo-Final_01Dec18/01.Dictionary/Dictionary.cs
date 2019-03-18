using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Dictionary
{
    class Dictionary
    {
        static void Main(string[] args)
        {
            string[] wordsWithDefinition = Console.ReadLine().Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] requestedWords = Console.ReadLine().Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var dictionary = new Dictionary<string, List<string>>();
            List<string> allWords = new List<string>();

            for (int i = 0; i < wordsWithDefinition.Length; i++)
            {
                string[] currentDefinition = wordsWithDefinition[i].Split(": ").ToArray();
                string word = currentDefinition[0];
                string definition = currentDefinition[1];

                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, new List<string>());
                    allWords.Add(word);
                    if (definition != null)
                    {
                        dictionary[word].Add(definition);
                    }
                }
                else
                {
                    if (definition != null)
                    {
                        dictionary[word].Add(definition);
                    }
                }
            }

            dictionary = dictionary.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            for (int i = 0; i < requestedWords.Length; i++)
            {
                string currentWordToFind = requestedWords[i];
                if (dictionary.ContainsKey(currentWordToFind))
                {
                    List<string> definitions = dictionary[currentWordToFind].OrderByDescending(x => x.Length).ToList();
                    Console.WriteLine(currentWordToFind);
                    foreach (var definition in definitions)
                    {
                        Console.WriteLine($"-{definition}");
                    }
                }
            }

            string finalCommand = Console.ReadLine();

            if (finalCommand == "List")
            {
                allWords = allWords.OrderBy(x => x).ToList();
                Console.WriteLine(string.Join(' ', allWords));
            }
            else if (finalCommand == "End")
            {
                return;
            }
        }
    }
}
