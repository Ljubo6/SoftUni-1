using System;
using System.Collections.Generic;
using System.Linq;

namespace P01
{
    class Concert
    {
        static void Main(string[] args)
        {
            var bandMembers = new Dictionary<string, List<string>>();
            var bandTime = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "start of concert")
            {
                string[] currentBand = input.Split("; ").ToArray();
                string command = currentBand[0];
                string bandName = currentBand[1];

                if (command == "Add")
                {
                    List<string> membersInBand = currentBand[2].Split(", ").ToList();

                    if (!bandMembers.ContainsKey(bandName))
                    {
                        bandMembers.Add(bandName, membersInBand);
                    }
                    else
                    {
                        for (int i = 0; i < membersInBand.Count; i++)
                        {
                            if (!bandMembers[bandName].Contains(membersInBand[i]))
                            {
                                bandMembers[bandName].Add(membersInBand[i]);
                            }
                        }
                    }
                }
                else if (command == "Play")
                {
                    if (!bandTime.ContainsKey(bandName))
                    {
                        bandTime.Add(bandName, int.Parse(currentBand[2]));
                    }
                    else
                    {
                        bandTime[bandName] += int.Parse(currentBand[2]);
                    }
                }
                input = Console.ReadLine();
            }

            long totalTime = bandTime.Values.Sum();

            bandTime = bandTime
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            string finalLine = Console.ReadLine();

            Console.WriteLine($"Total time: {totalTime}");
            foreach (var band in bandTime)
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }


            Console.WriteLine(finalLine);
            foreach (var member in bandMembers[finalLine])
            {
                Console.WriteLine($"=> {member}");
            }
        }
    }
}
