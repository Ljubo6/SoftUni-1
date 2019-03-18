using System;
using System.Collections.Generic;
using System.Linq;

namespace Additional_01.Company_Roster
{
    class Employee
    {
        public Employee(string name, decimal salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }

        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }
    }

    class CompanyRoster
    {
        static void Main(string[] args)
        {
            var companyRoster = new List<Employee>();
            int employeesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < employeesCount; i++)
            {
                string[] employeeInfo = Console.ReadLine().Split();
                Employee currentEmployee = new Employee(employeeInfo[0], decimal.Parse(employeeInfo[1]), employeeInfo[2]);
                companyRoster.Add(currentEmployee);
            }

            companyRoster.GroupBy(x => x.Department);
            companyRoster.Average(x => x.Salary);
            companyRoster = companyRoster.OrderByDescending(x => x.Salary).ToList();
            Console.WriteLine(companyRoster[0].Department);

        }
    }
}
