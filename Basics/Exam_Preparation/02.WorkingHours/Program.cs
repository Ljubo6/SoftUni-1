using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.WorkingHours
{
    class Program
    {
        static void Main(string[] args)
        {
            int hoursRequested = int.Parse(Console.ReadLine());
            int workersCount = int.Parse(Console.ReadLine());
            int workingDays = int.Parse(Console.ReadLine());

            int totalHoursWorked = workersCount * 8 * workingDays;
            int hoursDifference = Math.Abs(totalHoursWorked - hoursRequested);
            double penalties = hoursDifference * workingDays;

            if (totalHoursWorked >= hoursRequested)
            {
                Console.WriteLine($"{hoursDifference} hours left");
            }
            else
            {
                Console.WriteLine($"{hoursDifference} overtime");
                Console.WriteLine($"Penalties: {penalties}");
            }

        }
    }
}
