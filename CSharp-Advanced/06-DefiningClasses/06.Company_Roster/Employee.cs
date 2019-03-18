using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Company_Roster
{
    class Employee
    {
        private string name;
        private decimal salary;
        private string position;
        private string department;
        private string email;
        private short age;
        
        public Employee(string name, decimal salary, string position, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Age = -1;
            this.Email = "n/a";
        }
        
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value != null)
                {
                    this.name = value;
                }
            }
        }

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value > 0)
                {
                    this.salary = value;
                }
            }
        }

        public string Position
        {
            get { return this.position; }
            set
            {
                if (value != null)
                {
                    this.position = value;
                }
            }
        }

        public string Department
        {
            get { return this.department; }
            set
            {
                if (value != null)
                {
                    this.department = value;
                }
            }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public short Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
    }
}
