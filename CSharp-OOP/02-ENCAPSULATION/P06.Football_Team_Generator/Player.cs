using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Player
{
    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;
    private float skillsLevel;

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

    private int Endurance
    {
        set
        {
            if (value >= 0 && value <= 100)
            {
                this.endurance = value;
            }
            else
            {
                this.endurance = 0;
                throw new InvalidOperationException("Endurance should be between 0 and 100.");
            }
        }
    }

    private int Sprint
    {
        set
        {
            if (value >= 0 && value <= 100)
            {
                this.sprint = value;
            }
            else
            {
                this.sprint = 0;
                throw new InvalidOperationException("Sprint should be between 0 and 100.");
            }
        }
    }

    private int Dribble
    {
        set
        {
            if (value >= 0 && value <= 100)
            {
                this.dribble = value;
            }
            else
            {
                this.dribble = 0;
                throw new InvalidOperationException("Dribble should be between 0 and 100.");
            }
        }
    }

    private int Passing
    {
        set
        {
            if (value >= 0 && value <= 100)
            {
                this.passing = value;
            }
            else
            {
                this.passing = 0;
                throw new InvalidOperationException("Passing should be between 0 and 100.");
            }
        }
    }

    private int Shooting
    {
        set
        {
            if (value >= 0 && value <= 100)
            {
                this.shooting = value;
            }
            else
            {
                this.shooting = 0;
                throw new InvalidOperationException("Shooting should be between 0 and 100.");
            }
        }
    }

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
        this.skillsLevel = CalculateSkillsLevel();
    }

    private float CalculateSkillsLevel()
    {
        return (this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5.0f;
    }

    public float SkillsLevel
    {
        get { return this.skillsLevel; }
    }
}

