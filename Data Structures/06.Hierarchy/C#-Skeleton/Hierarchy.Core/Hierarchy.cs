    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private Node root;
        private Dictionary<T, Node> nodesByValue;

        private class Node
        {
            public Node(T element, Node parent = null)
            {
                this.Value = element;
                this.Children = new List<Node>();
                this.Parent = parent;
            }

            public Node Parent { get; set; }
            public T Value { get; }
            public List<Node> Children { get; set; }
        }

        public Hierarchy(T root)
        {
            this.root = new Node(root);
            this.nodesByValue = new Dictionary<T, Node>();
            this.nodesByValue.Add(root, this.root);
        }

        public int Count
        {
            get
            {
                return this.nodesByValue.Count;
            }
        }

        public void Add(T parent, T child)
        {
            if (!this.nodesByValue.ContainsKey(parent) ||
                this.nodesByValue.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            Node parentNode = this.nodesByValue[parent];
            Node childNode = new Node(child, parentNode);
            parentNode.Children.Add(childNode);
            this.nodesByValue.Add(child, childNode);
        }

        public void Remove(T element)
        {
            if (!this.nodesByValue.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            Node nodeToRemove = this.nodesByValue[element];
            if (nodeToRemove.Parent == null)
            {
                throw new InvalidOperationException();
            }

            foreach (var child in nodeToRemove.Children)
            {
                child.Parent = nodeToRemove.Parent;
                nodeToRemove.Parent.Children.Add(child);
            }

            nodeToRemove.Parent.Children.Remove(nodeToRemove);
            this.nodesByValue.Remove(element);
            this.nodesByValue[nodeToRemove.Parent.Value].Children.Remove(nodeToRemove);
        }

        public IEnumerable<T> GetChildren(T parent)
        {
            if (!this.nodesByValue.ContainsKey(parent))
            {
                throw new ArgumentException();
            }

            Node parentNode = this.nodesByValue[parent];

            return parentNode.Children.Select(x => x.Value);
        }

        public T GetParent(T child)
        {
            if (!this.nodesByValue.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            Node childNode = this.nodesByValue[child];

            if (childNode.Parent == null)
            {
                return default(T);
            }

            return childNode.Parent.Value;
        }

        public bool Contains(T value)
        {
            return this.nodesByValue.ContainsKey(value);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            List<T> commonElements = new List<T>();

            foreach (var item in nodesByValue)
            {
                if (other.Contains(item.Key))
                {
                    commonElements.Add(item.Key);
                }
            }

            return commonElements;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currentNode = root;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(currentNode);

            while (queue.Count > 0)
            {
                currentNode = queue.Dequeue();
                yield return currentNode.Value;
                foreach (var child in currentNode.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }