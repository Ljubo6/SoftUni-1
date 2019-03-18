using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Tagram
{
    class Program
    {
        static void Main()
        {
            var data = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                var currentLine = input.Split(new string[] { "->", " " }, StringSplitOptions.RemoveEmptyEntries);
                string username = currentLine[0];
                string tag = currentLine[1];

                if (username == "ban")
                {
                    data.Remove(currentLine[1]);
                    input = Console.ReadLine();
                    continue;
                }

                int likes = int.Parse(currentLine[2]);

                if (!data.ContainsKey(username))
                {
                    data.Add(username, new Dictionary<string, int>());
                    data[username].Add(tag, likes);
                }
                else
                {
                    if (!data[username].ContainsKey(tag))
                    {
                        data[username].Add(tag, likes);
                    }
                    else
                    {
                        data[username][tag] += likes;
                    }
                }
                input = Console.ReadLine();
            }

            data = data
                .OrderByDescending(x => x.Value.Sum(y => y.Value))
                .ThenBy(x => x.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var username in data)
            {
                Console.WriteLine(username.Key);
                foreach (var tag in username.Value)
                {
                    Console.WriteLine($"- {tag.Key}: {tag.Value}");
                }
            }
        }
    }
}
