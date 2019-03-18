﻿public class CompanyInfo
{
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }

    public CompanyInfo()
    {

    }

    public CompanyInfo(string name, string department, decimal salary)
    {
        this.Name = name;
        this.Department = department;
        this.Salary = salary;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Department} {this.Salary:f2}";
    }
}
