using System;
using System.Collections;
using System.Collections.Generic;
using Wintellect.PowerCollections;
using System.Linq;

public class Instock : IProductStock
{
    private int indexOfChange = -1;
    private int indexOfInsertion = 0;
    private Dictionary<string, Product> byLabel;
    private OrderedDictionary<double, HashSet<Product>> byPrice;
    private Dictionary<int, HashSet<Product>> byQnty;
    private Dictionary<int, Product> byInsertion;

    public Instock()
    {
        this.byLabel = new Dictionary<string, Product>();
        this.byPrice = new OrderedDictionary<double, HashSet<Product>>();
        this.byInsertion = new Dictionary<int, Product>();
        this.byQnty = new Dictionary<int, HashSet<Product>>();
    }

    public int Count => this.byLabel.Count;

    public void Add(Product product)
    {
        product.IndexOfChange = ++indexOfChange;
        this.AddByLabel(product);
        this.AddByPrice(product);
        this.byInsertion.Add(indexOfInsertion++, product);
        this.AddByQnty(product);
    }

    private void AddByQnty(Product product)
    {
        if (!this.byQnty.ContainsKey(product.Quantity))
        {
            this.byQnty.Add(product.Quantity, new HashSet<Product>());
        }
        this.byQnty[product.Quantity].Add(product);
    }

    private void AddByLabel(Product product)
    {
        if (this.byLabel.ContainsKey(product.Label))
        {
            throw new ArgumentException();
        }
        this.byLabel.Add(product.Label, product);
    }

    private void AddByPrice(Product product)
    {
        if (!this.byPrice.ContainsKey(product.Price))
        {
            this.byPrice.Add(product.Price, new HashSet<Product>());
        }
        this.byPrice[product.Price].Add(product);
    }

    public void ChangeQuantity(string product, int quantity)
    {
        if (!this.byLabel.ContainsKey(product))
        {
            throw new ArgumentException();
        }
        var currentProduct = this.FindByLabel(product);
        var oldQnty = currentProduct.Quantity;

        this.byQnty[oldQnty].Remove(currentProduct);
        currentProduct.Quantity = quantity;
        currentProduct.IndexOfChange = ++indexOfChange;
        this.AddByQnty(currentProduct);
    }

    public bool Contains(Product product)
    {
        return this.byLabel.ContainsKey(product.Label);
    }

    public Product Find(int index)
    {
        if(0 > index || index >= this.Count)
        {
            throw new IndexOutOfRangeException();
        }
        return this.byInsertion[index];

    }

    public IEnumerable<Product> FindAllByPrice(double price)
    {
        if (!this.byPrice.ContainsKey(price))
        {
            return Enumerable.Empty<Product>();
        }

        return this.byPrice[price];
    }

    public IEnumerable<Product> FindAllByQuantity(int quantity)
    {
        if (!this.byQnty.ContainsKey(quantity))
        {
            return Enumerable.Empty<Product>();
        }

        var result = this.byQnty[quantity].OrderBy(x => x.IndexOfChange);

        if (result.Count() == 0)
        {
            return Enumerable.Empty<Product>();
        }
        return result;
    }

    public IEnumerable<Product> FindAllInRange(double lo, double hi)
    {
        var result = this.byPrice.Range(lo, false, hi, true).SelectMany(x => x.Value).OrderByDescending(x => x.Price);
        if(result.Count() == 0)
        {
            return Enumerable.Empty<Product>();
        }
        return result;

    }

    public Product FindByLabel(string label)
    {
        if (!this.byLabel.ContainsKey(label))
        {
            throw new ArgumentException();
        }
        return this.byLabel[label];
    }

    public IEnumerable<Product> FindFirstByAlphabeticalOrder(int count)
    {
        if (count > this.Count)
        {
            throw new ArgumentException();
        }

       return this.byLabel.OrderBy(x => x.Key).Take(count).Select(x => x.Value);
    }

    public IEnumerable<Product> FindFirstMostExpensiveProducts(int count)
    {
        if (count > this.Count)
        {
            throw new ArgumentException();
        }

        return this.byPrice.SelectMany(x => x.Value).Skip(this.Count-count).Reverse();
    }

    public IEnumerator<Product> GetEnumerator()
    {
        foreach (var product in this.byLabel.Values)
        {
            yield return product;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
