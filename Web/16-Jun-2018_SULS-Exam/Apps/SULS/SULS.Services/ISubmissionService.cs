namespace SULS.Services
{
    public interface ISubmissionService
    {
        string CreateNewSubmission(string problemId, string userId, string code);
        bool DeleteSubmissionById(string id);
    }
}
