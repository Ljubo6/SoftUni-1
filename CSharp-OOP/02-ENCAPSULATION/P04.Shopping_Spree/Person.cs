using System;
using System.Collections.Generic;
using System.Text;

class Person
{
    private string name;
    private decimal money;
    private List<Product> shoppingBag;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        shoppingBag = new List<Product>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (value == null || value == string.Empty || value == " ")
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.name = value;
        }
    }

    public decimal Money
    {
        get
        {
            return this.money;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.money = value;
        }

    }

    public List<Product> ShoppingBag => this.shoppingBag;
}
