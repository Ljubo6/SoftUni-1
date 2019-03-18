using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_1_CreditSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int Grade = 0;
            int totalGrade = 0;
            double Credits = 0;
            int number = 0;
            for (int i = 0; i < n; i++)
            {
                number = int.Parse(Console.ReadLine());

                Grade = number % 10;
                Credits = (number - Grade) / 10;


                if (Grade == 2) { Credits = 0; totalGrade += Grade; }
                else if (Grade == 3) { Credits = Credits + Credits * 0.5; totalGrade = totalGrade + Grade; }
                else if (Grade == 4) { Credits = Credits + Credits * 0.7; totalGrade = totalGrade + Grade; }
                else if (Grade == 5) { Credits = Credits + Credits * 0.85; totalGrade = totalGrade + Grade; }
                else if (Grade == 6) { Credits = Credits + Credits * 1.0; totalGrade = totalGrade + Grade; }
            }
            Console.WriteLine(Credits);
            double AveageGrade = totalGrade / n;
            Console.WriteLine(Math.Round(AveageGrade, 2));
        }
    }
}
