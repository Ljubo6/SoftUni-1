using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Company_User
{
    class CompanyUser
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" -> ").ToArray();

            var employeesPerCompany = new Dictionary<string, List<string>>();

            while (input[0] != "End")
            {
                string company = input[0];
                string employeeID = input[1];

                if (!employeesPerCompany.ContainsKey(company))
                {
                    employeesPerCompany.Add(company, new List<string> { employeeID });
                }
                else
                {
                    if(!employeesPerCompany[company].Contains(employeeID))
                    {
                        employeesPerCompany[company].Add(employeeID);
                    }
                }
                input = Console.ReadLine().Split(" -> ").ToArray();
            }

            employeesPerCompany = employeesPerCompany
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in employeesPerCompany)
            {
                Console.WriteLine(kvp.Key);
                for (int i = 0; i < kvp.Value.Count; i++)
                {
                    Console.WriteLine($"-- {kvp.Value[i]}");
                }
            }
        }
    }
}
