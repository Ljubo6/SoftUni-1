using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var output = RemoveTown(context);
                Console.WriteLine(output);
            }
        }

        //P15. Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            var townToRemove = context.Towns.FirstOrDefault(t => t.Name == "Seattle");
            int seattleId = townToRemove.TownId;

            context.Employees
                .Where(e => e.Address.Town == townToRemove)
                .ToList()
                .ForEach(e => e.AddressId = null);

            var addressesToRemove = context.Addresses
                .Where(t => t.TownId == seattleId)
                .ToList();

            context.Addresses.RemoveRange(addressesToRemove);
            context.Towns.Remove(townToRemove);
            context.SaveChanges();

            return $"{addressesToRemove.Count} addresses in Seattle were deleted";
        }

        //P14. Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectToDelete = context.Projects.FirstOrDefault(p => p.ProjectId == 2);
            var employeesWithProjectToDelete = context.EmployeesProjects.Where(ep => ep.ProjectId == 2).ToList();

            context.EmployeesProjects.RemoveRange(employeesWithProjectToDelete);
            context.Projects.Remove(projectToDelete);
            context.SaveChanges();

            var projectNames = context.Projects.Take(10).Select(p => p.Name);

            var info = new StringBuilder();
            foreach (var name in projectNames)
            {
                info.AppendLine(name);
            }

            return info.ToString().TrimEnd();
        }

        //P13. Find Employees by First Name Starting With Sa
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    FullName = e.FirstName + " " + e.LastName,
                    e.JobTitle,
                    e.Salary
                }).ToList()
                .OrderBy(e => e.FullName)
                .ToList();

            var info = new StringBuilder();

            foreach (var employee in employees)
            {
                info.AppendLine($"{employee.FullName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return info.ToString().TrimEnd();
        }

        //P12. Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            string[] promotedDepartments = new[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            context.Employees
                .Where(e => promotedDepartments.Contains(e.Department.Name))
                .ToList()
                .ForEach(e => e.Salary *= 1.12m);

            context.SaveChanges();

            var promotedEmployees = context.Employees
                 .Where(e => promotedDepartments.Contains(e.Department.Name))
                 .Select(e => new
                 {
                     FullName = e.FirstName + " " + e.LastName,
                     e.Salary
                 }).ToList()
                 .OrderBy(e => e.FullName)
                 .ToList();

            var info = new StringBuilder();

            foreach (var employee in promotedEmployees)
            {
                info.AppendLine($"{employee.FullName} (${employee.Salary:f2})");
            }

            return info.ToString().TrimEnd();
        }

        //P11.	Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            var latestProjects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderBy(d => d.Name)
                .ToList();

            var info = new StringBuilder();
            foreach (var project in latestProjects)
            {
                info.AppendLine(project.Name);
                info.AppendLine(project.Description);
                info.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }

            return info.ToString().TrimEnd();
        }

        //P10.	Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFullName = d.Manager.FirstName + " " + d.Manager.LastName,
                    Employees = d.Employees.Select(e => new
                    {
                        FullName = e.FirstName + " " + e.LastName,
                        e.JobTitle
                    })
                    .OrderBy(e => e.FullName)
                    .ToList()
                }).ToList();

            var info = new StringBuilder();

            foreach (var dept in departments)
            {
                info.AppendLine($"{dept.DepartmentName} - {dept.ManagerFullName}");
                foreach (var employee in dept.Employees)
                {
                    info.AppendLine($"{employee.FullName} - {employee.JobTitle}");
                }
            }

            return info.ToString().TrimEnd();
        }

        //P09. Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context.Employees.Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    FullName = e.FirstName + " " + e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects.Select(p => new
                    {
                        p.Project.Name
                    })
                    .OrderBy(p => p.Name)
                    .ToList()
                })
                .FirstOrDefault();

            var employee147Info = new StringBuilder();
            employee147Info.AppendLine($"{employee147.FullName} - {employee147.JobTitle}");
            foreach (var project in employee147.Projects)
            {
                employee147Info.AppendLine(project.Name);
            }

            return employee147Info.ToString().TrimEnd();
        }

        //P08. Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .GroupBy(a => new
                {
                    a.AddressId,
                    a.AddressText,
                    a.Town.Name
                },
                        (key, group) => new
                        {
                            key.AddressText,
                            Town = key.Name,
                            Count = group.Sum(a => a.Employees.Count)
                        }).ToList()
                .OrderByDescending(t => t.Count)
                .ThenBy(t => t.Town)
                .ThenBy(t => t.AddressText)
                .Take(10)
                .ToList();

            var info = new StringBuilder();

            foreach (var address in addresses)
            {
                info.AppendLine($"{address.AddressText}, {address.Town} - {address.Count} employees");
            }

            return info.ToString().TrimEnd();
        }

        //P07. Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.EmployeesProjects
                             .Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    EmployeeFullName = e.FirstName + " " + e.LastName,
                    ManagerFullName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        ProjectStartDate = p.Project.StartDate,
                        ProjectEndDate = p.Project.EndDate
                    }).ToList()
                })
                .ToList();

            var info = new StringBuilder();

            foreach (var employee in employees)
            {
                info.AppendLine($"{employee.EmployeeFullName} - Manager: {employee.ManagerFullName}");

                foreach (var project in employee.Projects)
                {
                    string startDate = project.ProjectStartDate.ToString("M/d/yyyy h:mm:ss tt");
                    string endDate = project.ProjectEndDate == null ? "not finished" : project.ProjectEndDate.Value.ToString("M/d/yyyy h:mm:ss tt");

                    info.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }

            return info.ToString().TrimEnd();
        }

        //P06. Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var employer = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            employer.Address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.SaveChanges();

            var empAddressInfo = new StringBuilder();
            var employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => new
                {
                    e.Address.AddressText
                })
                .ToList();

            foreach (var employee in employees)
            {
                empAddressInfo.AppendLine(employee.AddressText);
            }

            return empAddressInfo.ToString().TrimEnd();
        }


        //P05. Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var empInfo = new StringBuilder();

            var allEmployees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            foreach (var employee in allEmployees)
            {
                empInfo.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
            }

            return empInfo.ToString().TrimEnd();
        }

        //P04. Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var empInfo = new StringBuilder();

            var allEmployees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName);
            foreach (var employee in allEmployees)
            {
                empInfo.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return empInfo.ToString().TrimEnd();
        }

        //P03. Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var empInfo = new StringBuilder();

        var allEmployees = context.Employees
            .Select(e => new
            {
                e.EmployeeId,
                e.FirstName,
                e.MiddleName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
            .OrderBy(e => e.EmployeeId);
            foreach (var employee in allEmployees)
            {
                empInfo.AppendLine($"{employee.FirstName} {employee.MiddleName} {employee.LastName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return empInfo.ToString().TrimEnd();
}
    }
}
