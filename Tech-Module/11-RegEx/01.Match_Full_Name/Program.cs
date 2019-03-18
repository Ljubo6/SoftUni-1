using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace _01.Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"^[A-Z][a-z]+ [A-Z][a-z]+$";
            string[] names = Console.ReadLine().Split(", ");
            List<string> matchedNames = new List<string>();

            foreach (string name in names)
            {
                MatchCollection match = Regex.Matches(name, regex);
                matchedNames.Add(match.ToString());
            }

            foreach (string name in matchedNames)
            {
                Console.WriteLine(name + " ");
            }
            Console.WriteLine();
        }
    }
}
