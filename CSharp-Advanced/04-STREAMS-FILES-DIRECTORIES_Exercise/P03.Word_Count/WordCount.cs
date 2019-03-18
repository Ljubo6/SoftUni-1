using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P03.Word_Count
{
    class WordCount
    {
        static void Main(string[] args)
        {
            var wordsCount = new Dictionary<string, int>();

            using (var reader = new StreamReader(@"..\..\..\..\Resources\words.txt"))
            {
                while (true)
                {
                    string word = reader.ReadLine();
                    if (word == null)
                    {
                        break;
                    }
                    wordsCount.Add(word, 0);
                }
            }

            using (var reader = new StreamReader(@"..\..\..\..\Resources\text.txt"))
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    var lineArray = line
                        .ToLower()
                        .Split(new char[] { ' ', '.', ',', '!', '?', '-' } , StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < lineArray.Length; i++)
                    {
                        if (wordsCount.ContainsKey(lineArray[i]))
                        {
                            wordsCount[lineArray[i]]++;
                        }
                    }
                }
            }

            using (var writer = new StreamWriter("actualResult.txt", true))
            {
                foreach (var word in wordsCount.OrderByDescending(x=>x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
