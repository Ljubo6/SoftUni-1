using System;

public class LinkedStack<T>
{
    private Node firstNode;

    private class Node
    {
        public T Value { get; private set; }
        public Node NextNode { get; set; }

        public Node(T value, Node nextNode = null)
        {
            this.Value = value;
        }
    }

    public int Count { get; private set; }

    public void Push(T element)
    {
        Node pushedElement = new Node(element);

        if (this.Count == 0)
        {
            this.firstNode = pushedElement;
        }

        else
        {
            Node nextNode = this.firstNode;
            this.firstNode = pushedElement;
            this.firstNode.NextNode = nextNode;
        }
       
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        
        T poppedElement = this.firstNode.Value;
        this.firstNode = this.firstNode.NextNode;
        this.Count--;
        return poppedElement;
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];
        Node nodeToAdd = this.firstNode;
        int index = 0;

        while (nodeToAdd != null)
        {
            array[index] = nodeToAdd.Value;
            nodeToAdd = nodeToAdd.NextNode;
            index++;
        }

        return array;
    }
}
