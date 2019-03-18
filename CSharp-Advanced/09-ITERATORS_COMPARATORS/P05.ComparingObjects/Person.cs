using System;
using System.Collections.Generic;
using System.Text;

namespace P05.ComparingObjects
{
   public class Person : IComparable<Person>
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Town { get; private set; }

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public int CompareTo(Person other)
        {
            if (this.Name == other.Name)
            {
                if (this.Age == other.Age)
                {
                    return this.Town.CompareTo(other.Town);
                }
                else
                {
                    return this.Age.CompareTo(other.Age);
                }
            }
            else
            {
                return this.Name.CompareTo(other.Name);
            }
        }
    }
}
