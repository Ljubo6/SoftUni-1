using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Trainer
{
    private string name;
    private int badgesCount;
    private List<Pokemon> ownPokemons;

    public string Name
    {
        get => this.name;
        set
        {
            if (value != null)
            {
                this.name = value;
            }
        }
    }

    public int BadgesCount { get => this.badgesCount; }
    public List<Pokemon> OwnPokemons { get => this.ownPokemons; }

    /// <summary>
    /// Creates a new object of class Trainer. Each object initially has zero badges and an empty collection of own Pokemons.
    /// </summary>
    /// <param name="name"></param>
    public Trainer (string name)
    {
        this.Name = name;
        this.badgesCount = 0;
        this.ownPokemons = new List<Pokemon>();
    }

    /// <summary>
    /// Increments the count of badges that current trainer holds.
    /// </summary>
    public void AddBadge()
    {
        this.badgesCount++;
    }

    public void AddPokemon(Pokemon newPokemon)
    {
        this.ownPokemons.Add(newPokemon);
    }

    /// <summary>
    /// Reduces the health of all pokemons that belong to current trainer by value of 10.
    /// </summary>
    public void ReduceAllPokemonsHealth()
    {
        this.ownPokemons.ForEach(p => p.Health -= 10);
    }

    /// <summary>
    /// Removes all pokemons with health equals to zero or negative from the personal collection of current trainer.
    /// </summary>
    public void RemoveDeadPokemons()
    {
        this.ownPokemons.RemoveAll(p => p.Health <= 0);
    }

    public override string ToString()
    {
        return $"{this.name} {this.badgesCount} {this.ownPokemons.Count}";
    }
}
