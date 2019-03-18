using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    public class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }

    public Node Head { get; set; }
    public Node Tail { get; set; }

    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        Node oldHead = Head;
        this.Head = new Node(item);
        this.Head.Next = oldHead;

        if (this.Count == 0)
        {
            Tail = Head;
        }

        Count++;
    }

    public void AddLast(T item)
    {
        Node oldTail = Tail;
        this.Tail = new Node(item);

        if (this.Count == 0)
        {
            Head = Tail;
        }
        else
        {
            oldTail.Next = this.Tail;
        }
        Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        Node oldHead = this.Head;
        this.Head = oldHead.Next;
        Count--;
        return oldHead.Value;
    }

    public T RemoveLast()
    {
        Node oldTail = this.Tail;

        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        if (this.Count == 1)
        {
            this.Head = this.Tail = null;
        }
        else
        {
            Node currentNode = this.Head;

            while (currentNode.Next != this.Tail)
            {
                currentNode = currentNode.Next;
            }

            this.Tail = currentNode;
        }

        this.Count--;
        return oldTail.Value;

    }

    public IEnumerator<T> GetEnumerator()
    {
        Node currentNode = Head;

        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
