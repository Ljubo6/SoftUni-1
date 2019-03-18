using System;
using System.Collections.Generic;

public class Tree<T>
{
    public T Value { get; set; }
    public IList<Tree<T>> Children { get; private set; }


    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>();
        foreach (var child in children)
        {
            this.Children.Add(child);
        }
    }

    public void Print(int indent = 0)
    {
        Console.Write(new string(' ', 2 * indent));
        Console.WriteLine(this.Value);
        foreach (var child in Children)
        {
            child.Print(indent+1);
        }
    }
    

    public void Each(Action<T> action)
    {
        action(this.Value);
        foreach (var child in this.Children)
        {
            child.Each(action);
        }
    }

    public IEnumerable<T> OrderDFS()
    {
        var result = new List<T>();
        this.DFS(result, this);
        return result;
    }

    private void DFS(List<T> result, Tree<T> tree)
    {
        foreach (var child in tree.Children)
        {
            this.DFS(result, child);
        }
        result.Add(tree.Value);
    }

    public IEnumerable<T> OrderBFS()
    {
        List<T> result = new List<T>();
        Queue<Tree<T>> queue = new Queue<Tree<T>>();

        queue.Enqueue(this);
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            foreach (var child in current.Children)
            {
                queue.Enqueue(child);
            }
            result.Add(current.Value);
        }
        return result;
    }
}
