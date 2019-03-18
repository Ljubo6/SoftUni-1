using System;
using System.Collections.Generic;
using System.Text;

namespace P06.StrategyPattern
{
    public class AgeComparer : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            return first.Age.CompareTo(second.Age);
        }
    }
}
