namespace P04.WorkForce
{
    using P04.WorkForce.Employees;
    using P04.WorkForce.Jobs;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private List<IEmployee> employees;
        private JobManager jobManager;

        public Engine()
        {
            this.employees = new List<IEmployee>();
            this.jobManager = new JobManager();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];

                if(command == "End")
                {
                    return;
                }

                switch (command)
                {
                    case "Job":
                        string jobName = input[1];
                        int hours = int.Parse(input[2]);
                        string employeeName = input[3];
                        IEmployee employee = this.employees.FirstOrDefault(e => e.Name == employeeName);
                        jobManager.CreateJob(jobName, hours, employee);
                        break;
                    case "StandardEmployee":
                        employeeName = input[1];
                        IEmployee newEmployee = new StandardEmployee(employeeName);
                        this.employees.Add(newEmployee);
                        break;
                    case "PartTimeEmployee":
                        employeeName = input[1];
                        newEmployee = new PartTimeEmployee(employeeName);
                        this.employees.Add(newEmployee);
                        break;
                    case "Pass":
                        jobManager.PassWeek();
                        break;
                    case "Status":
                        jobManager.GetStats();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
