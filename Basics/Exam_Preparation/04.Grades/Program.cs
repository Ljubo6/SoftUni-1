using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double studentsExamed = double.Parse(Console.ReadLine());
            int students200to299 = 0;
            int students300to399 = 0;
            int students400to499 = 0;
            int students500to600 = 0;
            double sumOfGrades = 0.0;

            for (int i = 1; i <= studentsExamed; i++)
            {
                double examGrade = double.Parse(Console.ReadLine());
                sumOfGrades = sumOfGrades + examGrade;
                if (examGrade >= 2 && examGrade <3)
                {
                    students200to299++;
                }
                if (examGrade >= 3 && examGrade < 4)
                {
                    students300to399++;
                }
                if (examGrade >= 4 && examGrade < 5)
                {
                    students400to499++;
                }
                if (examGrade >= 5 && examGrade <= 6)
                {
                    students500to600++;
                }
            }
            double percent200to299 = (students200to299 / studentsExamed) * 100.00;
            double percent300to399 = (students300to399 / studentsExamed) * 100.00;
            double percent400to499 = (students400to499 / studentsExamed) * 100.00;
            double percent500to600 = (students500to600 / studentsExamed) * 100.00;
            double averageGrade = sumOfGrades / studentsExamed;
            Console.WriteLine($"Top students: {percent500to600:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {percent400to499:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {percent300to399:f2}%");
            Console.WriteLine($"Fail: {percent200to299:f2}%");
            Console.WriteLine($"Average: {averageGrade:f2}");
        }
    }
}
