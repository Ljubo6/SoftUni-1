using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int membersCount = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < membersCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                Person currentMember = new Person(input[0], int.Parse(input[1]));
                family.AddMember(currentMember);
            }

            Person oldestPerson = family.GetOldestMember();

            Console.WriteLine(oldestPerson.Name + " " + oldestPerson.Age);
        }
    }
}
