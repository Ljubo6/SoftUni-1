using System;
using System.Collections.Generic;

namespace P05.ComparingObjects
{
    public class Program
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string[] person = Console.ReadLine().Split();

                if (person[0] == "END")
                {
                    break;
                }

                people.Add(new Person(person[0], int.Parse(person[1]), person[2]));
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            var personToCompare = people[index];

            int count = 0;
            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].CompareTo(personToCompare) == 0)
                {
                    count++;
                }
            }

            if (count == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{count} {people.Count - count} {people.Count}");
            }
        }
    }
}
