using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private class ListNode<T>
    {
        public T Value { get; private set; }
        public ListNode<T> NextNode { get; set; }
        public ListNode<T> PrevNode { get; set; }

        public ListNode(T value)
        {
            this.Value = value;
        }
    }

    private ListNode<T> head;
    private ListNode<T> tail;
    
    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new ListNode<T>(element);
        }
        else
        {
            ListNode<T> newHead = new ListNode<T>(element);
            this.head.PrevNode = newHead;
            newHead.NextNode = this.head;
            this.head = newHead;
        }
        this.Count++;
    }

    public void AddLast(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new ListNode<T>(element);
        }

        else
        {
            ListNode<T> newTail = new ListNode<T>(element);
            this.tail.NextNode = newTail;
            newTail.PrevNode = this.tail;
            this.tail = newTail;
        }
        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List Empty");
        }

        T removedElement = this.head.Value;

        this.head = this.head.NextNode;
        if (this.head != null)
        {
            this.head.PrevNode = null;
        }
        else
        {
            this.tail = null;
        }

        this.Count--;
        return removedElement;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List Empty");
        }

        T removedElement = this.tail.Value;

        this.tail = this.tail.PrevNode;

        if (this.tail != null)
        {
            this.tail.NextNode = null;
        }
        else
        {
            this.head = null;
        }

        this.Count--;
        return removedElement;
    }

    public void ForEach(Action<T> action)
    {
        ListNode<T> currentNode = this.head;
        while (currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.NextNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        ListNode<T> currentNode = this.head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        T[] arrayResult = new T[this.Count];

        int index = 0;

        while (this.head != null)
        {
            arrayResult[index] = this.head.Value;
            index++;
            this.head = this.head.NextNode;
        }

        return arrayResult;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
