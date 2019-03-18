using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Company_Roster
{
    class CompanyRoster
    {
        static void Main(string[] args)
        {
            int employeesCount = int.Parse(Console.ReadLine());
            List<Employee> allEmployees = new List<Employee>();

            for (int i = 0; i < employeesCount; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string position = input[2];
                string department = input[3];

                Employee currentEmployee = new Employee(name, salary, position, department);

                if (input.Length == 5)
                {
                    if (short.TryParse(input[4], out short age))
                    {
                        currentEmployee.Age = age;
                    }
                    else
                    {
                        currentEmployee.Email = input[4];
                    }
                }

                if (input.Length == 6)
                {
                    currentEmployee.Email = input[4];
                    currentEmployee.Age = short.Parse(input[5]);
                }

                allEmployees.Add(currentEmployee);
            }

            var topDept = allEmployees
                .GroupBy(x => x.Department)
                .ToDictionary(x => x.Key, y => y.Select(s => s))
                .OrderByDescending(x => x.Value.Average(s => s.Salary))
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {topDept.Key}");
            foreach (var employee in topDept.Value.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }

        }
    }
}
