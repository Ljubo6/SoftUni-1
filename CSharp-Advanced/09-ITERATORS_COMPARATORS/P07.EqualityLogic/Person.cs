using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P07.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Person second = (Person)obj;

            return this.GetHashCode() == second.GetHashCode();
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() << 1 * this.Age.GetHashCode();
        }

        public int CompareTo(Person second)
        {
            int difference = this.Name.CompareTo(second.Name);
            if (difference == 0)
            {
                return this.Age.CompareTo(second.Age);
            }

            return difference;
        }
    }
}
