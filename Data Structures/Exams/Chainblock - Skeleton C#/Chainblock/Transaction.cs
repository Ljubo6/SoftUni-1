using System;

public class Transaction : IComparable<Transaction>
{
    public int Id { get; set; }
    public TransactionStatus Status { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public double Amount { get; set; }

    public Transaction(int id, TransactionStatus st, string from, string to, double amount)
    {
        this.Id = id;
        this.Status = st;
        this.From = from;
        this.To = to;
        this.Amount = amount;
    }

    public override int GetHashCode()
    {
        return this.Id;
    }

    public override bool Equals(object obj)
    {
        var other = (Transaction)obj;
        return this.Id.Equals(other.Id);
    }

    public int CompareTo(Transaction other)
    {
        var cmp = other.Amount.CompareTo(this.Amount);
        if(cmp == 0)
        {
            return this.Id.CompareTo(other.Id);
        }

        return cmp;
    }
}