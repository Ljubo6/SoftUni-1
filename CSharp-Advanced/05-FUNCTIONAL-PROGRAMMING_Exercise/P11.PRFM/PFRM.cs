using System;
using System.Collections.Generic;
using System.Linq;

namespace P11.PRFM
{
    class PFRM
    {
        static void Main(string[] args)
        {
            Predicate<string> predicate;

            var invitedGuests = Console.ReadLine().Split().ToList();
            var filters = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split(';');

            while (input[0] != "Print")
            {
                string filter = input[1];
                string criteria = input[2];

                if (input[0] == "Add filter")
                {
                    if (!filters.ContainsKey(filter))
                    {
                        filters.Add(filter, new List<string> { criteria });
                    }
                    else
                    {
                        if (!filters[filter].Contains(criteria))
                        {
                            filters[filter].Add(criteria);
                        }
                    }
                }
                else if (input[0] == "Remove filter")
                {
                    if (filters.ContainsKey(filter))
                    {
                        filters[filter].RemoveAll(x => x == criteria);
                    }
                }
                input = Console.ReadLine().Split(';');
            }

            foreach (var filter in filters)
            {
                foreach (var criteria in filter.Value)
                {
                    predicate = GetPredicate(filter, criteria);
                    invitedGuests.RemoveAll(predicate);
                }
            }

            Console.WriteLine(string.Join(' ', invitedGuests));
        }

        private static Predicate<string> GetPredicate(KeyValuePair<string, List<string>> filter, string criteria)
        {
            if (filter.Key == "Starts with")
            {
                return name => name.StartsWith(criteria);
            }
            else if (filter.Key == "Ends with")
            {
                return name => name.EndsWith(criteria);
            }
            else if (filter.Key == "Length")
            {
                return name => name.Length == int.Parse(criteria);
            }
            else if (filter.Key == "Contains")
            {
                return name => name.Contains(criteria);
            }

            return null;
        }
    }
}
