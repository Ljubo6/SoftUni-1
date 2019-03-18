using System;
using System.Collections.Generic;
using System.Text;

namespace P06.StrategyPattern
{
    public class NameComparer : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            int nameLengthDifference = first.Name.Length - second.Name.Length;

            if (nameLengthDifference == 0)
            {
                return first.Name.ToLower()[0].CompareTo(second.Name.ToLower()[0]);
            }

            return nameLengthDifference;
        }
    }
}
