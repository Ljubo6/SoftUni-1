using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    public string Name { get; set; }
    public CompanyInfo CompanyInfo { get; set; }
    public List<Pokemon> Pokemons { get; set; }
    public List<Relative> Parents { get; set; }
    public List<Relative> Children { get; set; }
    public Car Car { get; set; }

    public Person(string name)
    {
        this.Name = name;
        this.Car = new Car();
        this.Children = new List<Relative>();
        this.CompanyInfo = new CompanyInfo();
        this.Parents = new List<Relative>();
        this.Pokemons = new List<Pokemon>();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(this.Name);
        sb.Append(Environment.NewLine);
        sb.Append("Company:");
        
        if (this.CompanyInfo.Name != null)
        {
            sb.Append(Environment.NewLine);
            sb.Append(this.CompanyInfo.ToString());
        }
        else
        {
            sb.Append(string.Empty);
        }
        sb.Append(Environment.NewLine);
        sb.Append("Car:");
        
        if (this.Car.Model != null)
        {
            sb.Append(Environment.NewLine);
            sb.Append(this.Car.ToString());
        }
        else
        {
            sb.Append(string.Empty);
        }
        sb.Append(Environment.NewLine);
        sb.Append("Pokemon:");
        
        if (this.Pokemons.Count > 0)
        {
            sb.Append(Environment.NewLine);
            sb.Append(string.Join(Environment.NewLine, Pokemons));
        }
        else
        {
            sb.Append(string.Empty);
        }
        sb.Append(Environment.NewLine);
        sb.Append("Parents:");
        
        if (this.Parents.Count > 0)
        {
            sb.Append(Environment.NewLine);
            sb.Append(string.Join(Environment.NewLine, Parents));
        }
        else
        {
            sb.Append(string.Empty);
        }
        sb.Append(Environment.NewLine);
        sb.Append("Children:");
        if (this.Children.Count > 0)
        {
            sb.Append(Environment.NewLine);
            sb.Append(string.Join(Environment.NewLine, Children));
        }
        else
        {
            sb.Append(string.Empty);
        }

        return sb.ToString();
    }
}
