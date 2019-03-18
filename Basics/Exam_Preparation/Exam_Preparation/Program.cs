using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int workingDaysPerMonth = int.Parse(Console.ReadLine());
            double dailyWage = double.Parse(Console.ReadLine());
            double rateUSDtoLVN = double.Parse(Console.ReadLine());

            double fixedSalary = workingDaysPerMonth * 12 * dailyWage;
            double totalGrossSalary = fixedSalary + 2.5 * workingDaysPerMonth * dailyWage;
            double netSalary = totalGrossSalary * 0.75;
            double dailyWageLVN = (netSalary / 365.0) * rateUSDtoLVN;

            Console.WriteLine($"{dailyWageLVN:f2}");
        }
    }
}
