using System;
using System.Linq;

namespace P07.Predicate_Names
{
    class PredicateNames
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string[], string[]> filterShorterNames = array => array.Where(x => x.Length <= length).ToArray();

            names = filterShorterNames(names);

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
