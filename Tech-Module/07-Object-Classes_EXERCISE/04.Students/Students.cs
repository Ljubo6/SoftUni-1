using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;  
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
    }

    class P04
    {
        static void Main(string[] args)
        {
            List<Student> gradeBook = new List<Student>();
            int studentsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < studentsCount; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                Student currentStudent = new Student(input[0], input[1], double.Parse(input[2]));
                gradeBook.Add(currentStudent);
            }

            gradeBook = gradeBook.OrderByDescending(x => x.Grade).ToList();
            foreach (var student in gradeBook)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
}
