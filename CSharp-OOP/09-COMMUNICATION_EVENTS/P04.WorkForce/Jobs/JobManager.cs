namespace P04.WorkForce.Jobs
{
    using P04.WorkForce.Employees;
    using System;
    using System.Collections.Generic;

    public class JobManager
    {
        private List<Job> allJobs;
        private Handler handler;

        public JobManager()
        {
            this.allJobs = new List<Job>();
            this.handler = new Handler();
        }

        public void CreateJob(string name, int requiredHours, IEmployee employee)
        {
            var job = new Job(name, requiredHours, employee);
            this.allJobs.Add(job);
            job.JobComplete += handler.OnJobcomplete;
        }
        
        public void PassWeek()
        {
            foreach (var job in this.allJobs)
            {
                job.Update();
            }

            this.DeleteCompleteJobs();
        }

        public void GetStats()
        {
            foreach (var job in this.allJobs)
            {
                Console.WriteLine(job.ToString());
            }
        }

        private void DeleteCompleteJobs()
        {
            this.allJobs.RemoveAll(j => j.IsComplete);
        }
    }
}
