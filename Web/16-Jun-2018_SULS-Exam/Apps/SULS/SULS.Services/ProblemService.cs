namespace SULS.Services
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using SULS.Data;
    using SULS.Models;

    public class ProblemService : IProblemService
    {
        private readonly SULSContext db;

        public ProblemService(SULSContext db)
        {
            this.db = db;
        }

        public string AddNewProblemToDb(string name, int totalPoints)
        {
            var problem = new Problem
            {
                Name = name,
                Points = totalPoints
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();
            return problem.Id;
        }

        public IQueryable<Problem> GetAllProblems()
        {
            return this.db.Problems.Include(p => p.Submissions);
        }

        public IQueryable<Submission> GetAllSubmissionsForProblem(string problemId)
        {
            return this.db.Submissions
                .Include(s => s.User)
                .Include(s => s.Problem)
                .Where(s => s.ProblemId == problemId);
        }

        public Problem GetProblemById(string id)
        {
            return this.GetAllProblems()
                .SingleOrDefault(p => p.Id == id);
        }
    }
}
