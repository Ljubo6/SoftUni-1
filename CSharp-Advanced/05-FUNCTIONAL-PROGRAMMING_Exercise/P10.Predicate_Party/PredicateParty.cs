using System;
using System.Collections.Generic;
using System.Linq;
namespace P10.Predicate_Party
{
    class PredicateParty
    {
        static void Main()
        {
            Predicate<string> predicate;
            Action<List<string>> print = names => Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            List<string> guests = Console.ReadLine().Split().ToList();
            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] currentCommand = command.Split();
                string action = currentCommand[0];
                string filter = currentCommand[1];
                string criteria = currentCommand[2];

                predicate = GetPredicate(filter, criteria);

                if (action == "Double")
                {
                    var dublicates = guests.FindAll(predicate);
                    foreach (var guest in dublicates)
                    {
                        int index = guests.IndexOf(guest);
                        guests.Insert(index, guest);
                    }
                }

                if (action == "Remove")
                {
                    guests.RemoveAll(predicate);
                }
                command = Console.ReadLine();
            }
            if (guests.Count > 0)
            {
                print(guests);
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            
        }


        private static Predicate<string> GetPredicate(string filter, string criteria)
        {
            if (filter == "StartsWith")
            {
                return name => name.StartsWith(criteria);
            }

            else if (filter == "EndsWith")
            {
                return name => name.EndsWith(criteria);
            }

            else if (filter == "Length")
            {
                return name => name.Length == int.Parse(criteria);
            }

            return null;
        }
    }
}
