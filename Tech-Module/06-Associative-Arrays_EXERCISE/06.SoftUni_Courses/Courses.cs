using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SoftUni_Courses
{
    class Courses
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var studentsPerCourse = new Dictionary<string, List<string>>();

            while (input[0] != "end")
            {
                string courseName = input[0];
                string studentName = input[1];

                if(!studentsPerCourse.ContainsKey(courseName))
                {
                    studentsPerCourse.Add(courseName, new List<string> { studentName });
                }
                else
                {
                    if (!studentsPerCourse[courseName].Contains(studentName))
                    {
                        studentsPerCourse[courseName].Add(studentName);
                    }
                }
                input = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            foreach (var kvp in studentsPerCourse.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
                kvp.Value.Sort();
                for (int i = 0; i < kvp.Value.Count; i++)
                {
                    Console.WriteLine($"-- {kvp.Value[i]}");
                }
            }
        }
    }
}
