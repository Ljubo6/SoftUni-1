using System;
using System.Text;

public class Worker : Human
{
    private decimal weekSalary;
    private int workHoursDaily;

    public Worker(string firstName, string lastName, decimal weekSalary, int workHoursDaily)
        :base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursDaily = workHoursDaily;
    }

    private decimal HourlyWage
    {
        get => this.weekSalary / (5 * this.WorkHoursDaily);
    }

    public decimal WeekSalary
    {
        get
        {
            return this.weekSalary;
        }

        private set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            this.weekSalary = value;
        }
    }

    public int WorkHoursDaily
    {
        get
        {
            return this.workHoursDaily;
        }
        private set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            this.workHoursDaily = value;
        }
    }

    public override string ToString()
    {
        var worker = new StringBuilder();
        worker.AppendLine(base.ToString());
        worker.AppendLine($"Week Salary: {this.WeekSalary:f2}");
        worker.AppendLine($"Hours per day: {this.WorkHoursDaily:f2}");
        worker.AppendLine($"Salary per hour: {this.HourlyWage:f2}");

        return worker.ToString().TrimEnd();
    }
}
