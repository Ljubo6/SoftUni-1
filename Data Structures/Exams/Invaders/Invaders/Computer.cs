using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Computer : IComputer
{
    private int energy;
    private OrderedBag<Invader> byPriority = new OrderedBag<Invader>();
    private HashSet<Invader> byInsertion = new HashSet<Invader>();

    public Computer(int energy)
    {
        if(energy < 0)
        {
            throw new ArgumentException();
        }
        this.Energy = energy;
    }

    public int Energy
    {
        get
        {
            if(this.energy < 0)
            {
                return 0;
            }
            return this.energy;
        }
        private set
        {
            this.energy = value;
        }
    }

    public void Skip(int turns)
    {
        foreach (var invader in byPriority)
        {
            invader.Distance -= turns;
            if(invader.Distance <= 0)
            {
                this.Energy -= invader.Damage;
            }
        }
        this.DestroyTargetsInRadius(0);
    }

    public void AddInvader(Invader invader)
    {
        this.byPriority.Add(invader);
        this.byInsertion.Add(invader);
    }

    public void DestroyHighestPriorityTargets(int count)
    {
        if(this.byPriority.Count == 0)
        {
            return;
        }

        for (int i = 0; i < count; i++)
        {
            var invader = this.byPriority.RemoveFirst();
            this.byInsertion.Remove(invader);
        }
    }

    public void DestroyTargetsInRadius(int radius)
    {

        if (this.byPriority.Count == 0)
        {
            return;
        }

        var distance = this.byPriority.GetFirst().Distance;

        while (distance <= radius)
        {
            var invader = this.byPriority.RemoveFirst();
            this.byInsertion.Remove(invader);
            if (this.byPriority.Count == 0)
            {
                return;
            }
            distance = this.byPriority.GetFirst().Distance;
        }
    }

    public IEnumerable<Invader> Invaders()
    {
        return this.byInsertion;
    }
}
