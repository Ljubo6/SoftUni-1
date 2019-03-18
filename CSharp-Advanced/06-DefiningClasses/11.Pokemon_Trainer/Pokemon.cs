using System;
using System.Collections.Generic;
using System.Text;


public class Pokemon
{
    private string name;
    private string element;
    private int health;

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

    public string Element
    {
        get => this.element;
        set
        {
            if (value != null)
            {
                this.element = value;
            }
        }
    }

    public int Health
    {
        get => this.health;
        set
        {
            this.health = value;
        }
    }

    /// <summary>
    /// Creates a new object of class Pokemon.   
    /// </summary>
    /// <param name="name"></param>
    /// <param name="element"></param>
    /// <param name="health"></param>
    public Pokemon(string name, string element, int health)
    {
        this.Name = name;
        this.Element = element;
        this.Health = health;
    }
}
