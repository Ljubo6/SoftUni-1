using System;
using System.Collections.Generic;
using System.Text;

namespace P06.StrategyPattern
{
   public class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
