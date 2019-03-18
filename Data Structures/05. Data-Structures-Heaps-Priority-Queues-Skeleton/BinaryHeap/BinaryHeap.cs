using System;
using System.Collections.Generic;
using System.Linq;

public class BinaryHeap<T> where T : IComparable<T>
{
    private List<T> heap;

    public BinaryHeap()
    {
        this.heap = new List<T>();
    }

    public int Count
    {
        get { return this.heap.Count; }
    }

    public void Insert(T item)
    {
        this.heap.Add(item);
        this.HeapifyUp(this.heap.Count -1);
    }

    private void HeapifyUp(int index)
    {
        while (index > 0 && isSmaller(Parent(index), index))
        {
            this.Swap(index, Parent(index));
            index = Parent(index);
        }
    }

    private bool isSmaller(int parent, int child)
    {
        return this.heap[parent].CompareTo(this.heap[child]) < 0;
    }

    private void Swap(int child, int parent)
    {
        T temporal = this.heap[child];
        this.heap[child] = this.heap[parent];
        this.heap[parent] = temporal;
    }

    private int Parent(int index)
    {
        return (index - 1) / 2;
    }

    public T Peek()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        return this.heap[0];
    }

    public T Pull()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T pulledElement = this.heap[0];

        this.Swap(0, this.heap.Count - 1);
        this.heap.RemoveAt(this.heap.Count - 1);
        this.HeapifyDown(0);

        return pulledElement;
    }

    private void HeapifyDown(int parent)
    {
        while (parent < this.heap.Count / 2)
        {
            int child = parent * 2 + 1;
            if (HasChild(child + 1) && isSmaller(child, child + 1))
            {
                child++;
            }

            if (isSmaller(child, parent))
            {
                break;
            }

            this.Swap(parent, child);
            parent = child;
        }
    }

    private bool HasChild(int child)
    {
        return child * 2 + 1 <= this.heap.Count; 
    }

    public void DecreaseKey (T element)
    {
        int elementIndex = this.heap.IndexOf(element);
        this.HeapifyUp(elementIndex);
    }
}
