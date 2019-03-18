using System;
using System.Collections.Generic;
using System.Linq;

namespace _11Feb2018_P04.HitList
{
    public class StartUp
    {
        public static void Main()
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());

            var data = new Dictionary<string, Dictionary<string, string>>();

            string input = Console.ReadLine();

            while (input != "end transmissions")
            {
                var currentPersonInfo = new Queue<string>(input.Split(new[] { '=', ';', ':' }, StringSplitOptions.RemoveEmptyEntries));

                FillInData(data, currentPersonInfo);

                input = Console.ReadLine();
            }

            string[] killCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            ExecuteKillCommand(killCommand, data, targetInfoIndex);
        }

        private static void ExecuteKillCommand(string[] killCommand, Dictionary<string, Dictionary<string, string>> data, int targetInfoIndex)
        {
            if (killCommand[0] == "Kill")
            {
                string personToKill = killCommand[1];

                if (data.ContainsKey(personToKill))
                {
                    var dataRequired = data[personToKill].OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                    int infoIndex = 0;

                    Console.WriteLine($"Info on {personToKill}:");
                    foreach (var info in dataRequired)
                    {
                        infoIndex += info.Key.Length;
                        infoIndex += info.Value.Length;
                        Console.WriteLine($"---{info.Key}: {info.Value}");
                    }

                    Console.WriteLine($"Info index: {infoIndex}");
                    if (infoIndex >= targetInfoIndex)
                    {
                        Console.WriteLine("Proceed");
                    }
                    else
                    {
                        Console.WriteLine($"Need {targetInfoIndex - infoIndex} more info.");
                    }
                }
            }
        }

        private static void FillInData(Dictionary<string, Dictionary<string, string>> data, Queue<string> currentPersonInfo)
        {
            string name = currentPersonInfo.Dequeue();
            if (!data.ContainsKey(name))
            {
                data.Add(name, new Dictionary<string, string>());
            }

            while (currentPersonInfo.Count > 1)
            {
                string infoKey = currentPersonInfo.Dequeue();
                string infoValue = currentPersonInfo.Dequeue();

                if (!data[name].ContainsKey(infoKey))
                {
                    data[name].Add(infoKey, infoValue);
                }
                else
                {
                    data[name][infoKey] = infoValue;
                }
            }
        }
    }
}
