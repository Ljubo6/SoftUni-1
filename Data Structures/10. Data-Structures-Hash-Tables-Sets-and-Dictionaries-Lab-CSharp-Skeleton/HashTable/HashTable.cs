using System;
using System.Collections;
using System.Collections.Generic;

public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
{
    private const int DefaultCapacity = 16;
    private const float LoadFactor = 0.75f;
    private int maxElements;
    private LinkedList<KeyValue<TKey, TValue>>[] hashTable;

    public HashTable(int capacity = DefaultCapacity)
    {
        this.hashTable = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        this.maxElements = (int)(capacity * LoadFactor);
    }

    public int Count { get; private set; }

    public int Capacity
    {
        get
        {
            return hashTable.Length;
        }
    }

    
    public void Add(TKey key, TValue value)
    {
        //this.CheckGrowth();
        int hash = Math.Abs(key.GetHashCode()) % this.Capacity;

        if (this.hashTable[hash] == null)
        {
            this.hashTable[hash] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        KeyValue<TKey, TValue> kvp = new KeyValue<TKey, TValue>(key, value);

        foreach (var keyValue in this.hashTable[hash])
        {
            if (keyValue.Key.Equals(key))
            {
                throw new ArgumentException();
            }
        }

        this.hashTable[hash].AddLast(kvp);
        this.Count++;
    }

    private void CheckGrowth()
    {
        if (this.Count >= maxElements)
        {
            this.Resize();
        }
    }

    private void Resize()
    {
        LinkedList<KeyValue<TKey, TValue>>[] newHashTable = new LinkedList<KeyValue<TKey, TValue>>[2 * this.Capacity];

        foreach (var item in this.hashTable)
        {
            if (item != null)
            {
                foreach (var keyValue in item)
                {
                    keyValue.Key = keyValue.Key.GetHashCode % newHashTable.Length;
                }
            }
        }
    }

    public bool AddOrReplace(TKey key, TValue value)
    {
        throw new NotImplementedException();
    }

    public TValue Get(TKey key)
    {
        throw new NotImplementedException();
        // Note: throw an exception on missing key
    }

    public TValue this[TKey key]
    {
        get
        {
            throw new NotImplementedException();
            // Note: throw an exception on missing key
        }
        set
        {
            throw new NotImplementedException();
        }
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        throw new NotImplementedException();
    }

    public KeyValue<TKey, TValue> Find(TKey key)
    {
        throw new NotImplementedException();
    }

    public bool ContainsKey(TKey key)
    {
        throw new NotImplementedException();
    }

    public bool Remove(TKey key)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TKey> Keys
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public IEnumerable<TValue> Values
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
    {
        foreach (var linkedList in hashTable)
        {
            if (linkedList!=null)
            {
                foreach (var item in linkedList)
                {
                    yield return item;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
