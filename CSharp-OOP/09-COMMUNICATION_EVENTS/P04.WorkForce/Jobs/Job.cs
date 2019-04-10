namespace P04.WorkForce.Jobs
{
    using P04.WorkForce.Employees;

    public delegate void JobCompleteRemoval(object sender, JobCompleteEventArgs args);

    public class Job : IJob
    {
        private readonly IEmployee employee;
        private readonly string name;
        private int requiredHoursOfWork;

        public event JobCompleteRemoval JobComplete;

        public Job(string name, int requiredHoursOfWork, IEmployee employee)
        {
            this.name = name;
            this.requiredHoursOfWork = requiredHoursOfWork;
            this.employee = employee;
        }

        public bool IsComplete => this.requiredHoursOfWork <= 0;
        
        public void Update()
        {
            this.requiredHoursOfWork -= this.employee.HoursPerWeek;
            if(this.IsComplete)
            {
                this.OnJobComplete(new JobCompleteEventArgs(this.name));
            }
        }

        public void OnJobComplete(JobCompleteEventArgs args)
        {
            JobComplete.Invoke(this, args);
        }

        public override string ToString()
        {
            return $"Job: {this.name} Hours Remaining: {this.requiredHoursOfWork}";
        }
    }
}
