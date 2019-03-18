using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T> where T : IComparable<T>
{
    private LinkedList<T> insertionOrder;

    public FirstLastList()
    {
        this.insertionOrder = new LinkedList<T>();
    }

    public int Count
    {
        get
        {
            return this.insertionOrder.Count;
        }
    }

    public void Add(T element)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> First(int count)
    {
        if (this.Count < count)
        {
            throw new InvalidOperationException();
        }

        while (true)
        {

        }
    }

    public IEnumerable<T> Last(int count)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> Max(int count)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> Min(int count)
    {
        throw new NotImplementedException();
    }

    public int RemoveAll(T element)
    {
        throw new NotImplementedException();
    }
}
