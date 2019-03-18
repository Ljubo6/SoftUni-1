using System;

/// <summary>
/// <para>Product is the entity which your stock data structure
/// will consist of. Please, do not make any modifications as
/// it might lead to unexpected results</para>
/// </summary>
public class Product : IComparable<Product>
{
    public Product(string label, double price, int quantity)
    {
        this.Label = label;
        this.Price = price;
        this.Quantity = quantity;
        this.IndexOfChange = 0;
    }

    public string Label { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public int IndexOfChange { get; set; }

    public int CompareTo(Product other)
    {
        return other.IndexOfChange.CompareTo(this.IndexOfChange);
    }

    public override int GetHashCode()
    {
        return this.Label.GetHashCode() << 5;  
    }

    public override bool Equals(object obj)
    {
        return this.Label.Equals(((Product)obj).Label);
    }
}