using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class RoyaleArena : IArena
{
    private Dictionary<int, Battlecard> byID;
    
    public RoyaleArena()
    {
        this.byID = new Dictionary<int, Battlecard>();

    }
    public int Count => this.byID.Count;

    public void Add(Battlecard card)
    {
        if (!this.byID.ContainsKey(card.Id))
        {
            this.byID.Add(card.Id, card);
        }
    }
    
    public void ChangeCardType(int id, CardType type)
    {
        this.GetById(id).Type = type;
    }

    public bool Contains(Battlecard card)
    {
        return this.byID.ContainsKey(card.Id);
    }

    public IEnumerable<Battlecard> FindFirstLeastSwag(int n)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Battlecard> GetAllByNameAndSwag()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Battlecard> GetAllInSwagRange(double lo, double hi)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Battlecard> GetByCardType(CardType type)
    {
        return this.byID.Values.Where(x => x.Type == type).OrderByDescending(x => x.Damage).ThenBy(x => x.Id);
    }

    public IEnumerable<Battlecard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
    {
        return this.GetByCardType(type).Where(x => x.Damage <= damage);
    }

    public Battlecard GetById(int id)
    {
        if (!this.byID.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }
        return this.byID[id];
    }

    public IEnumerable<Battlecard> GetByNameAndSwagRange(string name, double lo, double hi)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Battlecard> GetByNameOrderedBySwagDescending(string name)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Battlecard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<Battlecard> GetEnumerator()
    {
        foreach (var card in this.byID)
        {
            yield return card.Value;
        }
    }

    public void RemoveById(int id)
    {
        if (!this.byID.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }
        this.byID.Remove(id);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private void AddByName(Battlecard card)
    {
        throw new NotImplementedException();
    }
}
