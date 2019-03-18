using System;
using System.Collections.Generic;
using System.Linq;

namespace _17Dec2018_P04.Kitchen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var knives = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var forks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var sets = new List<int>();

            while(knives.Any() && forks.Any())
            {
                int currentKnife = knives.Pop();
                if (currentKnife > forks.Peek())
                {
                    sets.Add(currentKnife + forks.Dequeue());
                }
                else if (currentKnife == forks.Peek())
                {
                    forks.Dequeue();
                    knives.Push(currentKnife + 1);
                }
            }

            Console.WriteLine($"The biggest set is: {sets.Max()}");
            Console.WriteLine(string.Join(' ', sets));
        }
    }
}
