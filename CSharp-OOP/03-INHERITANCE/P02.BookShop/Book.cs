using System;
using System.Collections.Generic;
using System.Text;

public class Book
{
    private string title;
    private string author;
    private decimal price;

    public Book(string title, string author, decimal price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }

    public string Title
    {
        get
        {
            return this.title;
        }

        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }

            this.title = value;
        }
    }

    public string Author
    {
        get
        {
            return this.author;
        }

        set
        {
            string[] name = value.Split();

            if (name.Length > 1)
            {
                if (Char.IsDigit(name[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }

            this.author = value;
        }
    }

    public virtual decimal Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }

            this.price = value;
        }
    }

    public override string ToString()
    {
        StringBuilder bookInfo = new StringBuilder();
        bookInfo.AppendLine($"Type: {this.GetType().Name}");
        bookInfo.AppendLine($"Title: {this.Title}");
        bookInfo.AppendLine($"Author: {this.Author}");
        bookInfo.AppendLine($"Price: {this.Price:f2}");

        return bookInfo.ToString().TrimEnd();
    }
}
