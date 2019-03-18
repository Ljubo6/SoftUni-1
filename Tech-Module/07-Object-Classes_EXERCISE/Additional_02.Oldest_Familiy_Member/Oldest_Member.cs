using System;
using System.Collections.Generic;
using System.Linq;

namespace Additional_02.Oldest_Familiy_Member
{
    class Oldest_Member
    {
        static void Main(string[] args)
        {
            Family members = new Family(new List<Person>());

            int familyMembers = int.Parse(Console.ReadLine());
            for (int i = 0; i < familyMembers; i++)
            {
                string[] input = Console.ReadLine().Split();
                Person currentMember = new Person(input[0], int.Parse(input[1]));
                members.AddMember(currentMember);
            }
            Console.WriteLine(members.GetOldestMember().Name + " " + members.GetOldestMember().Age);
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Family
    {
        public static List<Person> Members { get; set; }

        public Family(List<Person> members)
        {
            Members = members;
        }

        public void AddMember(Person member)
        {
            Members.Add(member);
        }

        public Person GetOldestMember()
        {
            Members = Members.OrderByDescending(x => x.Age).ToList();
            return Members[0];
        }
    }
}