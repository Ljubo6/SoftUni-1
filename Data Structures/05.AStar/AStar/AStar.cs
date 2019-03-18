using System;
using System.Collections.Generic;

public class AStar
{
    private char[,] map;
    private Dictionary<Node, int> cost;
    private Dictionary<Node, Node> parent;
    private PriorityQueue<Node> queue;

    public AStar(char[,] map)
    {
        this.map = map;
        this.cost = new Dictionary<Node, int>();
        this.parent = new Dictionary<Node, Node>();
        this.queue = new PriorityQueue<Node>();
    }

    public static int GetH(Node current, Node goal)
    {
        int X = Math.Abs(current.Col - goal.Col);
        int Y = Math.Abs(current.Row - goal.Row);

        return X + Y;
    }

    public IEnumerable<Node> GetPath(Node start, Node goal)
    {
        queue.Enqueue(start);
        parent[start] = null;
        cost[start] = 0;

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();

            if (currentNode.Equals(goal))
            {
                break;
            }

            var neighbours = GetNeighbours(currentNode);
            foreach (var neighbour in neighbours)
            {
                var newCost = cost[currentNode] + 1;
                if (!cost.ContainsKey(neighbour) || newCost < cost[neighbour])
                {
                    cost[neighbour] = newCost;
                    neighbour.F = newCost + GetH(neighbour, goal);
                    queue.Enqueue(neighbour);
                    parent[neighbour] = currentNode;
                }
            }
        }

        return GetPath(parent, start, goal);
    }

    private IEnumerable<Node> GetPath(Dictionary<Node, Node> parent, Node start, Node goal)
    {
        var path = new Stack<Node>();

        if (!parent.ContainsKey(goal))
        {
            path.Push(start);
            return path;
        }

        var currentNode = goal;

        while (currentNode != null)
        {
            path.Push(currentNode);
            currentNode = parent[currentNode];
        }

        return path;
    }

    private IEnumerable<Node> GetNeighbours(Node current)
    {
        List<Node> neighbours = new List<Node>();

        //top
        if (current.Row - 1 >= 0)
        {
            if (map[current.Row - 1, current.Col] != 'W')
            {
                neighbours.Add(new Node(current.Row - 1, current.Col));
            }
        }

        //right
        if (current.Col + 1 < map.GetLength(1))
        {
            if (map[current.Row, current.Col + 1] != 'W')
            {
                neighbours.Add(new Node(current.Row, current.Col + 1));
            }
        }

        //bottom
        if (current.Row + 1 < map.GetLength(0))
        {
            if (map[current.Row + 1, current.Col] != 'W')
            {
                neighbours.Add(new Node(current.Row + 1, current.Col));
            }
        }

        //left
        if (current.Col - 1 >= 0)
        {
            if (map[current.Row, current.Col - 1] != 'W')
            {
                neighbours.Add(new Node(current.Row, current.Col - 1));

            }
        }

        return neighbours;
    }
}

