﻿using System;
using System.Linq;
using System.Text;

public class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        :base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get
        {
            return this.facultyNumber;
        }
        private set
        {
            if (value.Length < 5 || value.Length > 10 || value.Any(x => !char.IsLetterOrDigit(x)))
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        var student = new StringBuilder();
        student.AppendLine(base.ToString());
        student.AppendLine($"Faculty number: {this.FacultyNumber}");

        return student.ToString().TrimEnd();
    }
}
