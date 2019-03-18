using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DoB { get; set; }
    public List<Person> Parents { get; set; }
    public List<Person> Children { get; set; }

    public Person(string firstName, string lastName, DateTime DoB)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.DoB = DoB;
        this.Parents = new List<Person>();
        this.Children = new List<Person>();
    }
}
