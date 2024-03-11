using System;
using System.Collections.Generic;

public class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
{ 
    private struct Node             // 구조체로 노드 생성
    {
        public TElement element;
        public TPriority priority;

        public Node(TElement element, TPriority priority)
        {
            this.element = element;
            this.priority = priority;
        }
    }

    private List<Node> nodes;       // 배열로 구현

    public PriorityQueue()
    {
        nodes = new List<Node>();
    }

    public int Count { get { return nodes.Count; } }

    public void Enqueue(TElement element, TPriority priority)
    {
        Node newNode = new Node(element, priority);
        nodes.Add(newNode);
        int index = nodes.Count - 1;
        while (index >= 0)
        {
            int parentIndex = (index - 1) / 2;
            Node paremrNode = nodes[parentIndex];

            if (newNode.priority.CompareTo(paremrNode.priority) < 0)
            {
                nodes[index] = paremrNode;
                index = parentIndex;
            }
            else
            {
                break;
            }
        }
        nodes[index] = newNode;
    }

    public TElement Peek()
    {
        if (nodes.Count == 0)
            throw new InvalidOperationException();

        return nodes[0].element;
    }

    public TElement Dequeue()
    {
        // 제거작업
        if (nodes.Count == 0)
            throw new InvalidOperationException();

        Node rootNode = nodes[0];
        PopHeap();
        return rootNode.element;
    }

    private void PushHeap(Node node)
    {
        nodes.Add(node);
        int index = nodes.Count - 1;
        while (index > 0)
        {
            int parentIndex = GetParentIndex(index);
            Node parentNode = nodes[parentIndex];

            if (node.priority.CompareTo(parentNode.priority) < 0)
            {
                nodes[index] = parentNode;
                index = parentIndex;
            }
            else
            {
                break;
            }
        }
        nodes[index] = node;
    }

    private void PopHeap()
    {
        Node node = nodes[nodes.Count - 1];
        nodes[0] = node;
        nodes.RemoveAt(nodes.Count - 1);

        int index = 0;
        while (index < nodes.Count)
        {
            int leftIndex = GetLeftChildIndex(index);
            int rightIndex = GetRightChildIndex(index);

            if (rightIndex < nodes.Count)
            {
                int compareIndex = nodes[leftIndex].priority.CompareTo(nodes[rightIndex].priority) < 0 ?
                    leftIndex : rightIndex;

                if (nodes[index].priority.CompareTo(nodes[compareIndex].priority) > 0)
                {
                    nodes[index] = nodes[compareIndex];
                    index = compareIndex;
                }
                else
                {
                    nodes[index] = node;
                    break;
                }
            }
            else if (leftIndex < nodes.Count)  // 자식이 둘 다 있는 경우
            {
                if (nodes[index].priority.CompareTo(nodes[leftIndex].priority) > 0)
                {
                    nodes[index] = nodes[leftIndex];
                    index = leftIndex;
                }
                else
                {
                    nodes[index] = node;
                    break;
                }
            }
            else
            {
                nodes[index] = node;
                break;
            }
        }
    }

    private int GetParentIndex(int index)
    {
        return (index - 1) / 2;
    }

    private int GetLeftChildIndex(int index)
    {
        return index * 2 + 1;
    }

    private int GetRightChildIndex(int index)
    {
        return index * 2 + 2;
    }
}

