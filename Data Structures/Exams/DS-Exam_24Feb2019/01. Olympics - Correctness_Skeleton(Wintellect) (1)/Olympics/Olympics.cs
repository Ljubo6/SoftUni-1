using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Olympics : IOlympics
{
    private Dictionary<int, Competitor> competitors;
    private Dictionary<int, Competition> competitions;
    private Dictionary<string, HashSet<Competitor>> byName;

    public Olympics()
    {
        this.competitors = new Dictionary<int, Competitor>();
        this.competitions = new Dictionary<int, Competition>();
        this.byName = new Dictionary<string, HashSet<Competitor>>();
    }

    public void AddCompetitor(int id, string name)
    {
        if (this.competitors.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        var competitor = new Competitor(id, name);
        this.competitors.Add(id, competitor);

        if (!this.byName.ContainsKey(name))
        {
            this.byName.Add(name, new HashSet<Competitor>());
        }

        this.byName[name].Add(competitor);
    }

    public void AddCompetition(int id, string name, int participantsLimit)
    {
        if (this.competitions.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        var competition = new Competition(name, id, participantsLimit);
        this.competitions.Add(id, competition);
    }

    public void Compete(int competitorId, int competitionId)
    {
        if (!(this.competitions.ContainsKey(competitionId) && this.competitors.ContainsKey(competitorId)))
        {
            throw new ArgumentException();
        }

        var competition = this.competitions[competitionId];
        var competitor = this.competitors[competitorId];

        competition.Competitors.Add(competitor);
        competitor.TotalScore += competition.Score;
    }

    public void Disqualify(int competitionId, int competitorId)
    {
        if (!(this.competitions.ContainsKey(competitionId) && this.competitors.ContainsKey(competitorId)))
        {
            throw new ArgumentException();
        }

        var competitor = this.competitors[competitorId];
        competitor.TotalScore -= this.competitions[competitionId].Score;
        this.competitions[competitionId].Competitors.Remove(competitor);
    }

    public IEnumerable<Competitor> FindCompetitorsInRange(long min, long max)
    {
        var result = this.competitors.Values.Where(x => x.TotalScore > min && x.TotalScore <= max).OrderBy(x => x.Id);
        if (result.Count() == 0)
        {
            return Enumerable.Empty<Competitor>();
        }

        return result;
    }

    public IEnumerable<Competitor> GetByName(string name)
    {
        if (!this.byName.ContainsKey(name))
        {
            throw new ArgumentException();
        }

        return this.byName[name].OrderBy(x => x.Id);
    }

    public IEnumerable<Competitor> SearchWithNameLength(int min, int max)
    {
        var result = this.byName.Where(x => x.Key.Length >= min && x.Key.Length <= max).SelectMany(x => x.Value).OrderBy(x => x.Id);
        if (result.Count() == 0)
        {
            return Enumerable.Empty<Competitor>();
        }

        return result;
    }

    public bool Contains(int competitionId, Competitor comp)
    {
        if (!this.competitions.ContainsKey(competitionId))
        {
            throw new ArgumentException();
        }

        return this.competitions[competitionId].Competitors.Contains(comp);
    }

    public int CompetitionsCount()
    {
        return this.competitions.Count;
    }

    public int CompetitorsCount()
    {
        return this.competitors.Count;
    }

    public Competition GetCompetition(int id)
    {
        if (!this.competitions.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        return this.competitions[id];
    }
}