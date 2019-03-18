using System;
using System.Collections.Generic;
using System.Text;

public class GoldenEditionBook : Book
{
    public GoldenEditionBook(string title, string author, decimal price)
        : base(title, author, price)
    {
       
    }

    public override decimal Price
    {
        get => base.Price * 1.3m;
    }
}
