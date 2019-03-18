using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            double startingSalary = double.Parse(Console.ReadLine());
            int yearsOfWorking = int.Parse(Console.ReadLine());
            string isMember = Console.ReadLine().ToLower();

            for (double i = 1; i <= yearsOfWorking; i++)
            {
                if (i > 1)
                {
                    startingSalary = startingSalary * 1.06;
                }

                if (i > 9 && i % 10 == 0)
                {
                    startingSalary = startingSalary + 200;
                }

                if (i > 4 && i % 5 == 0)
                {
                    startingSalary = startingSalary + 100;
                }

                if (isMember == "yes" && startingSalary <= 5000)
                {
                    if (((i != 5) || (i != 10)))
                    {
                        continue;

                    }
                    else
                    {
                        startingSalary = startingSalary * 0.99;
                    }
                }
                if (startingSalary > 5000)
                {
                    startingSalary = 5000;
                }

            }
            Console.WriteLine($"Current Salary:{startingSalary:f2}");
        }
    }
}
