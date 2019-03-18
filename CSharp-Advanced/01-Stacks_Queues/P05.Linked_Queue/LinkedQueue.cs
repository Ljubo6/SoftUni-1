using System;

public class LinkedQueue<T>
{
    public int Count { get; private set; }

    public class QueueNode
    {
        public T Value { get; set; }
        public QueueNode Next { get; set; }
        public QueueNode Prev { get; set; }

        public QueueNode(T value, QueueNode next = null, QueueNode prev = null)
        {
            this.Value = value;
        }
    }

    private QueueNode begin;
    private QueueNode end;

    public void Enqueue(T element)
    {
        QueueNode newElement = new QueueNode(element);

        if (this.Count == 0)
        {
            this.begin = newElement;
            this.end = this.begin;
        }

        QueueNode oldEnd = this.end;
        this.end = newElement;
        newElement.Prev = oldEnd;
        oldEnd.Next = this.end;
        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T elementToReturn = this.begin.Value;
        if (this.Count == 1)
        {
            this.begin = this.end = null;
        }

        this.begin = this.begin.Next;
        this.Count--;
        return elementToReturn;
    }

    public T[] ToArray()
    {
        T[] result = new T[this.Count];
        QueueNode firstNode = this.begin;
        int index = 0;

        while (firstNode != null)
        {
            result[index] = firstNode.Value;
            firstNode = firstNode.Next;
            index++;
        }
        return result;
    }
}


