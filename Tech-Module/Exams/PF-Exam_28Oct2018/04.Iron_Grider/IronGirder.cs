using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Iron_Girder
{
    class IronGirder
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
               .Split(new string[] { ":", "->" }, StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

            var schedule = new Dictionary<string, List<long>>();
            //list[0] = time;
            //list[1] = total passangers;

            while (string.Join(" ", input) != "Slide rule")
            {
                string townName = input[0];
                bool noAmbush = int.TryParse(input[1], out int time);
                int passangersCount = int.Parse(input[2]);

                if (noAmbush)
                {
                    if (!schedule.ContainsKey(townName))
                    {
                        schedule.Add(townName, new List<long> { time, passangersCount });
                    }
                    else
                    {
                        if (schedule[townName][0] > time || schedule[townName][0] == 0)
                        {
                            schedule[townName][0] = time;
                        }

                        schedule[townName][1] += passangersCount;
                    }
                }
                else
                {
                    if (schedule.ContainsKey(townName))
                    {
                        schedule[townName][0] = 0;
                        schedule[townName][1] -= passangersCount;
                    }
                }

                input = Console.ReadLine()
               .Split(new string[] { ":", "->" }, StringSplitOptions.RemoveEmptyEntries)
               .ToArray();
            }

            schedule = schedule
                .OrderBy(x => x.Value[0])
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var town in schedule)
            {
                if (town.Value[0] > 0 && town.Value[1] > 0)
                {
                    Console.WriteLine($"{town.Key} -> Time: {town.Value[0]} -> Passengers: {town.Value[1]}");
                }
            }
        }
    }
}
