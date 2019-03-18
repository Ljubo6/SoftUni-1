using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Student_Academy
{
    class Academy
    {
        static void Main(string[] args)
        {
            int pairOfRows = int.Parse(Console.ReadLine());

            var gradeBook = new Dictionary<string, List<double>>();

            for (int i = 0; i < pairOfRows; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!gradeBook.ContainsKey(studentName))
                {
                    gradeBook.Add(studentName, new List<double> { grade });
                }
                else
                {
                    gradeBook[studentName].Add(grade);
                }
            }

            gradeBook = gradeBook
                .Where(x => x.Value.Average() >= 4.5)
                .OrderByDescending(x => x.Value.Average())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in gradeBook)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.Average():f2}");
            }
        }
    }
}
