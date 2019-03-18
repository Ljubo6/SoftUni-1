using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Chainblock : IChainblock
{
    private Dictionary<int, Transaction> byID;
    private Dictionary<TransactionStatus, HashSet<Transaction>> byStatus;
    private Dictionary<string, OrderedBag<Transaction>> bySender;
    private Dictionary<string, HashSet<Transaction>> byReceiver;
    private HashSet<Transaction> byAmount;

    public Chainblock()
    {
        this.byID = new Dictionary<int, Transaction>();
        this.byStatus = new Dictionary<TransactionStatus, HashSet<Transaction>>();
        this.byAmount = new HashSet<Transaction>();
        this.bySender = new Dictionary<string, OrderedBag<Transaction>>();
        this.byReceiver = new Dictionary<string, HashSet<Transaction>>();
    }

    public int Count => this.byID.Count();

    public void Add(Transaction tx)
    {
        if (!this.Contains(tx.Id))
        {
            this.byID.Add(tx.Id, tx);
        }

        if (!this.byStatus.ContainsKey(tx.Status))
        {
            this.byStatus.Add(tx.Status, new HashSet<Transaction>());
        }
        this.byStatus[tx.Status].Add(tx);

        this.byAmount.Add(tx);

        if (!this.bySender.ContainsKey(tx.From))
        {
            this.bySender.Add(tx.From, new OrderedBag<Transaction>());
        }
        this.bySender[tx.From].Add(tx);

        if (!this.byReceiver.ContainsKey(tx.To))
        {
            this.byReceiver.Add(tx.To, new HashSet<Transaction>());
        }
        this.byReceiver[tx.To].Add(tx);
    }

    public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
    {
        if (!this.byID.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        this.byID[id].Status = newStatus;
    }

    public bool Contains(Transaction tx)
    {
        return this.Contains(tx.Id);
    }

    public bool Contains(int id)
    {
        return this.byID.ContainsKey(id);
    }

    public IEnumerable<Transaction> GetAllInAmountRange(double lo, double hi)
    {
        var result = this.byAmount.Where(x => x.Amount >= lo && x.Amount <= hi);
        if(result.Count() == 0)
        {
            return Enumerable.Empty<Transaction>();
        }

        return result;
    }

    public IEnumerable<Transaction> GetAllOrderedByAmountDescendingThenById()
    {
        return this.byAmount.OrderByDescending(x => x.Amount).ThenBy(x => x.Id);
    }

    public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
    {
        if (!this.byStatus.ContainsKey(status))
        {
            throw new InvalidOperationException();
        }

        var result = this.byStatus[status].OrderByDescending(x => x.Amount).Select(x => x.To);
        if (result.Count() == 0)
        {
            throw new InvalidOperationException();
        }
        return result;
    }

    public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
    {
        if (!this.byStatus.ContainsKey(status))
        {
            throw new InvalidOperationException();
        }

        var result = this.byStatus[status].OrderByDescending(x => x.Amount).Select(x => x.From);

        if(result.Count() == 0)
        {
            throw new InvalidOperationException();
        }
        return result;
    }

    public Transaction GetById(int id)
    {
        if (!this.Contains(id))
        {
            throw new InvalidOperationException();
        }

        return this.byID[id];
    }

    public IEnumerable<Transaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
    {
        var result = this.GetByReceiverOrderedByAmountThenById(receiver)
            .Where(x => x.Amount >= lo && x.Amount < hi);

        if (result.Count() == 0)
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    public IEnumerable<Transaction> GetByReceiverOrderedByAmountThenById(string receiver)
    {
        if (!this.byReceiver.ContainsKey(receiver))
        {
            throw new InvalidOperationException();
        }

        var result = this.byReceiver[receiver].OrderByDescending(x => x.Amount).ThenBy(x => x.Id);

        //var result = this.byAmount.Where(x => x.To == receiver).OrderByDescending(x => x.Amount).ThenBy(x => x.Id);
        if (result.Count() == 0)
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    public IEnumerable<Transaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
    {
        var result = this.GetBySenderOrderedByAmountDescending(sender)
            .Where(x => x.Amount > amount);

        if (result.Count() == 0)
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    public IEnumerable<Transaction> GetBySenderOrderedByAmountDescending(string sender)
    {
        if(!this.bySender.ContainsKey(sender))
        {
            throw new InvalidOperationException();
        }

        var result = this.bySender[sender].OrderByDescending(x => x.Amount);
        //var result = this.byAmount.Where(x => x.From == sender).OrderByDescending(x => x.Amount);
        if (result.Count() == 0)
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    public IEnumerable<Transaction> GetByTransactionStatus(TransactionStatus status)
    {
        if (!this.byStatus.ContainsKey(status))
        {
            return Enumerable.Empty<Transaction>();
        }

        var result = this.byStatus[status].OrderByDescending(x => x.Amount);

        if(result.Count() == 0)
        {
            return Enumerable.Empty<Transaction>();
        }

        return result;
    }

    public IEnumerable<Transaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
    {
        var result = this.GetByTransactionStatus(status).Where(x => x.Amount <= amount);
        if(result.Count() == 0)
        {
            return Enumerable.Empty<Transaction>();
        }

        return result;
    }

    public IEnumerator<Transaction> GetEnumerator()
    {
        foreach (var tx in byID.Values)
        {
            yield return tx;
        }
    }

    public void RemoveTransactionById(int id)
    {
        if (!this.byID.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }

        var txRemove = this.byID[id];

        this.byID.Remove(id);
        this.byAmount.Remove(txRemove);
        this.byStatus[txRemove.Status].Remove(txRemove);
        this.byReceiver[txRemove.To].Remove(txRemove);
        this.bySender[txRemove.From].Remove(txRemove);

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

