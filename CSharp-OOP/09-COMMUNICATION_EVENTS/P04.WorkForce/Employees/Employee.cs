namespace P04.WorkForce.Employees
{
    public abstract class Employee : IEmployee
    {
        protected Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public abstract int HoursPerWeek { get; }
    }
}
