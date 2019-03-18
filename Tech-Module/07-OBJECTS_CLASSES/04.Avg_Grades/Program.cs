using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Avg_Grades
{
    class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }
        public double AvgGrade { get { return Grades.Average(); } }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Dictionary<string, double> studentsAboveFive = new Dictionary<string, double>();

            for (int i = 0; i < lines; i++)
            {
                List<string> input = Console.ReadLine().Split(' ').ToList();
                Student student = new Student();

                student.Name = input[0];
                input.RemoveAt(0);

                student.Grades = input.Select(double.Parse).ToList();
                
                if (student.AvgGrade >= 5)
                {
                    studentsAboveFive[student.Name] = student.AvgGrade;
                }
            }

            studentsAboveFive.OrderBy(k => k);

            foreach (var student in studentsAboveFive)
            {
                Console.WriteLine($"{student.Key} -> {student.Value:f2}");
            }
        }
    }
}
