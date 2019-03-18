using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Judge : IJudge
{
    private HashSet<int> users = new HashSet<int>();
    private HashSet<int> contests = new HashSet<int>();
    private Dictionary<int, Submission> byID = new Dictionary<int, Submission>();
    private Dictionary<SubmissionType, HashSet<Submission>> byType = new Dictionary<SubmissionType, HashSet<Submission>>();

    public void AddContest(int contestId)
    {
        contests.Add(contestId);
    }

    public void AddSubmission(Submission submission)
    {
        if (!(users.Contains(submission.UserId) && contests.Contains(submission.ContestId)))
        {
            throw new InvalidOperationException();
        }

        if (!this.byID.ContainsKey(submission.Id))
        {
            this.byID.Add(submission.Id, submission);
        }

        if (!this.byType.ContainsKey(submission.Type))
        {
            this.byType.Add(submission.Type, new HashSet<Submission>());
        }
        this.byType[submission.Type].Add(submission);
    }

    public void AddUser(int userId)
    {
        users.Add(userId);
    }

    public void DeleteSubmission(int submissionId)
    {
        if (!this.byID.ContainsKey(submissionId))
        {
            throw new InvalidOperationException();
        }
        var submission = this.byID[submissionId];
        this.byID.Remove(submissionId);
        this.byType[submission.Type].Remove(submission);
    }

    public IEnumerable<Submission> GetSubmissions()
    {
        return this.byID.Values.OrderBy(x => x.Id);
    }

    public IEnumerable<int> GetUsers()
    {
        return this.users.OrderBy(x => x);
    }

    public IEnumerable<int> GetContests()
    {
        return this.contests.OrderBy(x => x);
    }

    public IEnumerable<Submission> SubmissionsWithPointsInRangeBySubmissionType(int minPoints, int maxPoints, SubmissionType submissionType)
    {
        var result = this.byID.Values.Where(x => x.Type == submissionType && x.Points >= minPoints && x.Points <= maxPoints);

        if(result.Count() == 0)
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    public IEnumerable<int> ContestsByUserIdOrderedByPointsDescThenBySubmissionId(int userId)
    {
        return this.byID.Values
            .Where(x => x.UserId == userId)
            .GroupBy(x => x.ContestId)
            .Select(x => x
                            .OrderByDescending(s => s.Points)
                            .ThenBy(s => s.Id)
                            .First())
            .OrderByDescending(x => x.Points)
            .ThenBy(x => x.Id)
            .Select(x => x.ContestId);
    }

    public IEnumerable<Submission> SubmissionsInContestIdByUserIdWithPoints(int points, int contestId, int userId)
    {
        var result = this.byID.Values.Where(x => x.ContestId == contestId && x.UserId == userId && x.Points == points);

        if (result.Count() == 0)
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    public IEnumerable<int> ContestsBySubmissionType(SubmissionType submissionType)
    {
        if (!this.byType.ContainsKey(submissionType))
        {
            return Enumerable.Empty<int>();
        }

        var result = this.byType[submissionType].Select(x => x.ContestId).Distinct();

        if (result.Count() == 0)
        {
            return Enumerable.Empty<int>();
        }

        return result;
    }
}
