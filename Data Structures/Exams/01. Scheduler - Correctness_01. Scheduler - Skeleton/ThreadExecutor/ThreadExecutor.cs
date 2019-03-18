using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

/// <summary>
/// The ThreadExecutor is the concrete implementation of the IScheduler.
/// You can send any class to the judge system as long as it implements
/// the IScheduler interface. The Tests do not contain any <e>Reflection</e>!
/// </summary>
public class ThreadExecutor : IScheduler
{
    private Dictionary<int, Task> byID;
    private Dictionary<Priority, HashSet<Task>> byPriority;
    private OrderedDictionary<int, SortedSet<Task>> byConsumption;
    private BigList<Task> byInsertion;
    //private Dictionary<Priority, OrderedDictionary<int, SortedSet<Task>>> byPriorityAndByConsumption;

    public ThreadExecutor()
    {
        this.byID = new Dictionary<int, Task>();
        this.byConsumption = new OrderedDictionary<int, SortedSet<Task>>();
        this.byPriority = new Dictionary<Priority, HashSet<Task>>();
        this.byInsertion = new BigList<Task>();
        //this.byPriorityAndByConsumption = new Dictionary<Priority, OrderedDictionary<int, SortedSet<Task>>>();
    }

    public int Count
    {
        get => this.byID.Count;
    }

    public void ChangePriority(int id, Priority newPriority)
    {
        if (!this.byID.ContainsKey(id))
        {
            throw new ArgumentException();
        }
        var task = this.byID[id];
        this.byPriority[task.TaskPriority].Remove(task);
        task.TaskPriority = newPriority;
        this.AddByPriority(task);
    }

    public bool Contains(Task task)
    {
        return this.byID.ContainsKey(task.Id);
    }

    public int Cycle(int cycles)
    {
        if(this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        int completedTasks = 0;

        for (int i = 0; i < byInsertion.Count; i++)
        {
            var task = byInsertion[i];

            if (!task.IsComplete())
            {
                var oldConsumption = task.Consumption;
                this.byConsumption[oldConsumption].Remove(task);
                task.ReduceConsumption(cycles);

                if (task.Consumption <= 0)
                {
                    completedTasks++;
                    this.byID.Remove(task.Id);
                    this.byPriority[task.TaskPriority].Remove(task);
                    //this.byInsertion.Remove(task);
                    //i--;
                }
                else
                {
                    this.AddByConsumption(task);
                }
            }
        }
        this.byInsertion.RemoveAll(x => x.Consumption <= 0);
        return completedTasks;
    }

    public void Execute(Task task)
    {
        if (this.byID.ContainsKey(task.Id))
        {
            throw new ArgumentException();
        }
        this.byID.Add(task.Id, task);
        this.AddByConsumption(task);
        this.AddByPriority(task);
        this.byInsertion.Add(task);
    }

    public IEnumerable<Task> GetByConsumptionRange(int lo, int hi, bool inclusive)
    {
        return this.byConsumption.Range(lo, inclusive, hi, inclusive).SelectMany(x => x.Value);
    }

    public Task GetById(int id)
    {
        if (!this.byID.ContainsKey(id))
        {
            throw new ArgumentException();
        }
        return this.byID[id];
    }

    public Task GetByIndex(int index)
    {
        if(0 > index || index >= this.byInsertion.Count)
        {
            throw new ArgumentOutOfRangeException();
        }
        return this.byInsertion[index];
    }

    public IEnumerable<Task> GetByPriority(Priority type)
    {
        if (!this.byPriority.ContainsKey(type))
        {
            return Enumerable.Empty<Task>();
        }

        var result = this.byPriority[type].OrderByDescending(x => x.Id);

        if(result.Count() <= 0)
        {
            return Enumerable.Empty<Task>();
        }

        return result;
    }

    public IEnumerable<Task> GetByPriorityAndMinimumConsumption(Priority priority, int lo)
    {
        //var result = this.byConsumption
        //    .RangeTo(lo, true)
        //    .SelectMany(x => x.Value)
        //    .Where(x => x.TaskPriority == priority)
        //    .OrderByDescending(x => x.Id);

        var result = this.GetByPriority(priority).Where(x => x.Consumption <= lo).OrderByDescending(x => x.Id);

        if (result.Count() == 0)
        {
            return Enumerable.Empty<Task>();
        }

        return result;
    }

    public IEnumerator<Task> GetEnumerator()
    {
        foreach (var task in byInsertion)
        {
            yield return task;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private void AddByConsumption(Task task)
    {
        if (!this.byConsumption.ContainsKey(task.Consumption))
        {
            this.byConsumption.Add(task.Consumption, new SortedSet<Task>());
        }
        this.byConsumption[task.Consumption].Add(task);
    }

    private void AddByPriority(Task task)
    {
        if (!this.byPriority.ContainsKey(task.TaskPriority))
        {
            this.byPriority.Add(task.TaskPriority, new HashSet<Task>());
        }
        this.byPriority[task.TaskPriority].Add(task);
    }
}
