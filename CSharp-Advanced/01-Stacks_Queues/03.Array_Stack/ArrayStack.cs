using System;

public class ArrayStack<T>
{
    private T[] elements;

    public int Count { get; private set; }
    private const int InitialCapacity = 16;

    public ArrayStack(int capacity = InitialCapacity)
    {
        this.elements = new T[InitialCapacity];
    }

    public void Push(T element)
    {
        if (this.Count == this.elements.Length-1)
        {
            this.Grow();
        }

        this.elements[this.Count] = element;
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T poppedElement = this.elements[this.Count-1];
        this.Count--;

        return poppedElement;
    }

    public T[] ToArray()
    {
        T[] toArray = new T[this.Count];
        int reversedIndex = this.Count - 1;

        for (int i = 0; i < this.Count; i++)
        {
            toArray[i] = this.elements[reversedIndex];
            reversedIndex--;
        }

        return toArray;
    }
    
    private void Grow()
    {
        T[] newArray = new T[this.elements.Length * 2];
        Array.Copy(this.elements, newArray, this.Count);
        this.elements = newArray;
    }
}