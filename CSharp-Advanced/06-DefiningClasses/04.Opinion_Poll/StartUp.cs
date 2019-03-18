using DefiningClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Opinion_Poll
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split();
                var currentPerson = new Person(input[0], int.Parse(input[1]));
                persons.Add(currentPerson);
            }

            persons
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList()
                .ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));
        }
    }
}
