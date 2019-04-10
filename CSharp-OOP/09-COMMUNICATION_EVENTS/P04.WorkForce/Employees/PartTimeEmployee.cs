namespace P04.WorkForce.Employees
{
    public class PartTimeEmployee : Employee
    {
        public PartTimeEmployee(string name) : base(name)
        {
        }

        public override int HoursPerWeek => 20;
    }
}
