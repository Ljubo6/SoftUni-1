using System;
using System.Collections.Generic;
using System.Linq;

namespace P12.InfernoIII
{
    class InfernoIII
    {
        static void Main(string[] args)
        {
            var gems = Console.ReadLine().Split().Select(int.Parse).ToList();
            var filters = new Dictionary<string, List<int>>();
            gems.Insert(0, 0);
            gems.Insert(gems.Count, 0);
            string[] input = Console.ReadLine().Split(';');
            List<int> removeAt = new List<int>();

            while (input[0] != "Forge")
            {
                string filter = input[1];
                int criteria = int.Parse(input[2]);

                if (input[0] == "Exclude")
                {
                    if (!filters.ContainsKey(filter))
                    {
                        filters.Add(filter, new List<int> { criteria });
                    }
                    else
                    {
                        if (!filters[filter].Contains(criteria))
                        {
                            filters[filter].Add(criteria);
                        }
                    }
                }
                else if (input[0] == "Reverse")
                {
                    if (filters.ContainsKey(filter))
                    {
                        int index = filters[filter].LastIndexOf(criteria);
                        filters[filter].RemoveAt(index);
                    }
                }
                input = Console.ReadLine().Split(';');
            }

            foreach (var filter in filters)
            {
                foreach (var criteria in filter.Value)
                {
                    removeAt.AddRange(GetPredicate(gems, filter, criteria));
                }
            }

            removeAt.Add(0);
            removeAt.Add(gems.Count - 1);
            removeAt = removeAt.OrderBy(x=>x).ToList();

            for (int i = removeAt.Count - 1; i >= 0; i--)
            {
                gems.RemoveAt(removeAt[i]);
            }

            Console.WriteLine(string.Join(' ', gems));

        }

        private static List<int> GetPredicate(List<int> gems, KeyValuePair<string, List<int>> filter, int criteria)
        {
            List<int> indeciesToRemoveAt = new List<int>();

            if (filter.Key == "Sum Left")
            {
                for (int i = 1; i < gems.Count - 1; i++)
                {
                    if (gems[i] + gems[i - 1] == criteria)
                    {
                        indeciesToRemoveAt.Add(i);
                    }
                }
            }

            else if (filter.Key == "Sum Right")
            {
                for (int i = 1; i < gems.Count - 1; i++)
                {
                    if (gems[i] + gems[i + 1] == criteria)
                    {
                        indeciesToRemoveAt.Add(i);
                    }
                }
            }

            else if (filter.Key == "Sum Left Right")
            {
                for (int i = 1; i < gems.Count - 1; i++)
                {
                    if (gems[i - 1] + gems[i] + gems[i + 1] == criteria)
                    {
                        indeciesToRemoveAt.Add(i);
                    }
                }
            }

            return indeciesToRemoveAt;
        }
    }
}
