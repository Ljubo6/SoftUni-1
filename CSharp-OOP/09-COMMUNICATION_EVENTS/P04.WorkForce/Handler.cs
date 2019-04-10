namespace P04.WorkForce
{
    using P04.WorkForce.Jobs;
    using System;

    public class Handler
    {
        public void OnJobcomplete(object sender, JobCompleteEventArgs args)
        {
            Console.WriteLine($"Job {args.Name} done!");
        }
    }
}
