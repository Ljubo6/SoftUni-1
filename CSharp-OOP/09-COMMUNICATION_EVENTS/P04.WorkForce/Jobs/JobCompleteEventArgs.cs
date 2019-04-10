namespace P04.WorkForce.Jobs
{
    using System;

    public class JobCompleteEventArgs : EventArgs
    {
        public JobCompleteEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
