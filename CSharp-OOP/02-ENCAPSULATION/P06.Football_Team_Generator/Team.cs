using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Team
{
    private string name;
    private List<Player> players;
    private int rating;

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidOperationException("A name should not be empty.");
            }
            else
            {
                this.name = value;
            }
        }
    }

    public Team(string name)
    {
        this.Name = name;
        this.players = new List<Player>();
    }

    public void AddPlayer(Player player)
    {
        this.players.Add(player);
    }

    public bool RemovePlayer(string name)
    {
        int count = this.players.RemoveAll(p => p.Name == name);
        return count > 0;
    }

    public int Rating
    {
        get
        {
            this.rating = CalculateRating();
            return this.rating;
        }
    }

    private int CalculateRating()
    {
        if (this.players.Count == 0)
        {
            return 0;
        }

        return (int)Math.Round(this.players.Average(p => p.SkillsLevel));
    }
}
