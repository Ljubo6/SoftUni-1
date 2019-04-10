namespace P04.WorkForce.Employees
{
    public class StandardEmployee : Employee
    {
        public StandardEmployee(string name) : base(name)
        {
        }

        public override int HoursPerWeek => 40;
    }
}
