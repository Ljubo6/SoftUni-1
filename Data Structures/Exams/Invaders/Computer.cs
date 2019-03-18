using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Computer : IComputer
{
    private int energy;
    private HashSet<Invader> invaders;

    public Computer(int energy)
    {
        if (energy < 0)
        {
            throw new ArgumentException();
        }

        this.Energy = energy;
        this.invaders = new HashSet<Invader>();
    }

    public int Energy
    {
        get
        {
            return this.energy;
        }

        private set
        {
            this.energy = value < 0 ? 0 : value;
        }
    }

    public void Skip(int turns)
    {
        List<Invader> toRemove = new List<Invader>();

        foreach (var invader in this.invaders)
        {
            invader.Distance -= turns;

            if (invader.Distance <= 0)
            {
                this.Energy -= invader.Damage;
                toRemove.Add(invader);
            }
        }

        toRemove.ForEach(i => this.invaders.Remove(i));
    }

    public void AddInvader(Invader invader)
    {
        this.invaders.Add(invader);
    }

    public void DestroyHighestPriorityTargets(int count)
    {
        IEnumerable<Invader> toDestroy = this.invaders.OrderBy(i => i).Take(count);

        foreach (var item in toDestroy)
        {
            this.invaders.Remove(item);
        }
    }

    public void DestroyTargetsInRadius(int radius)
    {
        this.invaders.RemoveWhere(i => i.Distance <= radius);
    }

    public IEnumerable<Invader> Invaders()
    {
        return this.invaders;
    }
}
