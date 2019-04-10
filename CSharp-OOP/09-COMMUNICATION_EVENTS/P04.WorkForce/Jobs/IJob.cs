namespace P04.WorkForce.Jobs
{
    public interface IJob
    {
        bool IsComplete { get; }
        void Update();
    }
}
