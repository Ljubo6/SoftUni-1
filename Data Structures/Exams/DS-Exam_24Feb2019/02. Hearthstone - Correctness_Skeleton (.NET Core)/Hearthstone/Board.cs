using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Board : IBoard
{
    private Dictionary<string, Card> deck;
    private List<string> deadCards;

    public Board()
    {
        this.deck = new Dictionary<string, Card>();
        this.deadCards = new List<string>();
    }

    public bool Contains(string name)
    {
        return this.deck.ContainsKey(name);
    }

    public int Count()
    {
        return this.deck.Count;
    }

    public void Draw(Card card)
    {
        if (this.Contains(card.Name))
        {
            throw new ArgumentException();
        }

        this.deck.Add(card.Name, card);
    }

    public IEnumerable<Card> GetBestInRange(int start, int end)
    {
        return this.deck
                .Values
                .Where(x => x.Score >= start && x.Score <= end)
                .OrderByDescending(x => x.Level);
    }

    public void Heal(int health)
    {
        var cardToHeal = this.deck.Values.OrderBy(x => x.Health).FirstOrDefault();
        cardToHeal.Health += health;
    }

    public IEnumerable<Card> ListCardsByPrefix(string prefix)
    {
        return this.deck.Values
            .Where(x => x.Name.StartsWith(prefix))
            .OrderBy(x => new string(x.Name.ToCharArray().Reverse().ToArray()))
            .ThenBy(x => x.Level);
    }

    public void Play(string attackerCardName, string attackedCardName)
    {
        if(!(this.deck.ContainsKey(attackedCardName) && this.deck.ContainsKey(attackerCardName)))
        {
            throw new ArgumentException();
        }

        var attackerCard = this.deck[attackerCardName];
        var attackedCard = this.deck[attackedCardName];
        
        if(attackedCard.Level != attackerCard.Level)
        {
            throw new ArgumentException();
        }

        if(attackedCard.Health > 0)
        {
            attackedCard.Health -= attackerCard.Damage;

            if (attackedCard.Health <= 0)
            {
                attackerCard.Score += attackedCard.Level;
                this.deadCards.Add(attackedCardName);
            }
        }
    }

    public void Remove(string name)
    {
        if (!this.deck.ContainsKey(name))
        {
            throw new ArgumentException();
        }

        this.deck.Remove(name);
    }

    public void RemoveDeath()
    {
        foreach (var card in deadCards)
        {
            this.deck.Remove(card);
        }
        this.deadCards.Clear();
    }

    public IEnumerable<Card> SearchByLevel(int level)
    {
        return this.deck
                .Values
                .Where(x => x.Level == level)
                .OrderByDescending(x => x.Score);
    }
}