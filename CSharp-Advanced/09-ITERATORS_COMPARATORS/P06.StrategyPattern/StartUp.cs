using System;
using System.Collections.Generic;

namespace P06.StrategyPattern
{
    public class StartUp
    {
        static void Main()
        {
            IComparer<Person> nameComparer = new NameComparer();
            var sortedByName = new SortedSet<Person>(nameComparer);

            IComparer<Person> ageComparer = new AgeComparer();
            var sortedByAge = new SortedSet<Person>(ageComparer);

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                var currentPerson = new Person(name, age);

                sortedByName.Add(currentPerson);
                sortedByAge.Add(currentPerson);
            }

            foreach (var person in sortedByName)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }

            foreach (var person in sortedByAge)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }
        }
    }
}
