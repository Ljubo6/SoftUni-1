using System;

public class CircularQueue<T>
{
    private const int DefaultCapacity = 4;
    private const int InitialCapacity = 16;
    private T[] elements;
    private int startIndex = 0;
    private int endIndex = 0;

    public int Count { get; private set; }

    public CircularQueue(int capacity = InitialCapacity)
    {
       this.elements = new T[capacity];
    }

    public void Enqueue(T element)
    {
        if (this.Count >= this.elements.Length)
        {
            this.Resize();
        }

        this.elements[this.endIndex] = element;
        this.endIndex = (this.endIndex + 1) % this.elements.Length;
        this.Count++;
    }

    private void Resize()
    {
        T[] newArray = new T[this.elements.Length * 2];
        this.CopyAllElements(newArray);
        this.elements = newArray;
        this.startIndex = 0;
        this.endIndex = this.Count;
    }

    private void CopyAllElements(T[] newArray)
    {
        int sourceIndex = this.startIndex;

        for (int i = 0; i < this.Count; i++)
        {
            newArray[i] = this.elements[sourceIndex];
            sourceIndex = (sourceIndex+1) % this.elements.Length;
        }
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T dequeuedElement = this.elements[startIndex];
        this.startIndex = (startIndex + 1) % this.elements.Length;
        this.Count--;

        return dequeuedElement;
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];

        CopyAllElements(array);
        return array;
    }
}


public class Example
{
    public static void Main()
    {

        CircularQueue<int> queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        int first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
