using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Order_By_Age
{
    class Person
    {
        public Person(string name, int id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }

        public string Name { get; set; }
        public int ID { get; set; }
        public int Age { get; set; }
    }

    class OrderByAge
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] input = command.Split();
                string name = input[0];
                int id = int.Parse(input[1]);
                int age = int.Parse(input[2]);
                var currentPerson = new Person(name, id, age);
                people.Add(currentPerson);
                command = Console.ReadLine();
            }

            people = people.OrderBy(x => x.Age).ToList();

            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }
}
