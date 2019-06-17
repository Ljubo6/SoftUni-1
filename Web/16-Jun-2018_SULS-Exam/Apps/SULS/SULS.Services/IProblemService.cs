using SULS.Models;
using System.Linq;

namespace SULS.Services
{
    public interface IProblemService
    {
        string AddNewProblemToDb(string name, int totalPoints);
        IQueryable<Problem> GetAllProblems();
        Problem GetProblemById(string id);
        IQueryable<Submission> GetAllSubmissionsForProblem(string problemId);
    }
}
