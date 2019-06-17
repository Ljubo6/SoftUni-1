namespace SULS.Services
{
    using SULS.Data;
    using SULS.Models;
    using System;
    using System.Linq;

    public class SubmissionService : ISubmissionService
    {
        private readonly IProblemService problemService;
        private readonly SULSContext db;

        public SubmissionService(IProblemService problemService, SULSContext db)
        {
            this.problemService = problemService;
            this.db = db;
        }

        public string CreateNewSubmission(string problemId, string userId, string code)
        {
            var problemTotalPoints = this.problemService.GetProblemById(problemId).Points;

            var submission = new Submission
            {
                Code = code,
                ProblemId = problemId,
                UserId = userId,
                CreatedOn = DateTime.UtcNow,
                AchievedResult = this.GenerateRandomResultInRange(0, problemTotalPoints)
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
            return submission.Id;
        }

        public bool DeleteSubmissionById(string id)
        {
            var submissionToDelete = this.db.Submissions.SingleOrDefault(s => s.Id == id);
            this.db.Submissions.Remove(submissionToDelete);
            this.db.SaveChanges();
            return true;
        }

        private int GenerateRandomResultInRange(int minValue, int maxValue)
        {
            var random = new Random();
            return random.Next(minValue, maxValue + 1);
        }
    }
}
