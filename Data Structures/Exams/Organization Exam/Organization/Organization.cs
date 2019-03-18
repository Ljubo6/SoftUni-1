using System.Collections;
using System.Collections.Generic;
using System;
using Wintellect.PowerCollections;
using System.Linq;

public class Organization : IOrganization
{
    private Dictionary<string, List<Person>> byName;
    private OrderedDictionary<int, List<Person>> byLength;
    private List<Person> byInsertion;

    public Organization()
    {
        this.byInsertion = new List<Person>();
        this.byLength = new OrderedDictionary<int, List<Person>>();
        this.byName = new Dictionary<string, List<Person>>();
    }

    public IEnumerator<Person> GetEnumerator()
    {
        foreach (var person in this.byInsertion)
        {
            yield return person;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        
        return this.GetEnumerator();
    }

    public int Count => this.byInsertion.Count;

    public bool Contains(Person person)
    {
        if (!this.ContainsByName(person.Name))
        {
            return false;
        }

        return this.byName[person.Name].Contains(person);
    }

    public bool ContainsByName(string name)
    {
        return this.byName.ContainsKey(name);
    }

    public void Add(Person person)
    {
        this.byInsertion.Add(person);

        if (!this.byName.ContainsKey(person.Name))
        {
            this.byName.Add(person.Name, new List<Person>());
        }

        if (!this.byLength.ContainsKey(person.Name.Length)){
            this.byLength.Add(person.Name.Length, new List<Person>());
        }

        this.byName[person.Name].Add(person);
        this.byLength[person.Name.Length].Add(person);
    }

    public Person GetAtIndex(int index)
    {
        if(index >= this.Count)
        {
            throw new IndexOutOfRangeException();
        }

        return this.byInsertion[index];
    }

    public IEnumerable<Person> GetByName(string name)
    {
        if (!this.byName.ContainsKey(name))
        {
            return Enumerable.Empty<Person>();
        }
        return this.byName[name];
    }

    public IEnumerable<Person> FirstByInsertOrder(int count = 1)
    {
        if(this.Count == 0)
        {
            return Enumerable.Empty<Person>();
        }

        return this.byInsertion.Take(count);
    }

    public IEnumerable<Person> SearchWithNameSize(int minLength, int maxLength)
    {
        return this.byLength
            .Range(minLength, true, maxLength, true)
            .Values
            .SelectMany(x => x)
            .ToList();
    }

    public IEnumerable<Person> GetWithNameSize(int length)
    {
        if (!this.byLength.ContainsKey(length))
        {
            throw new ArgumentException();
        }

        return this.byLength[length];
    }

    public IEnumerable<Person> PeopleByInsertOrder()
    {
        return this.byInsertion;
    }
}