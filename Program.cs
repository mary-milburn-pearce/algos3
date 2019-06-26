using System;

namespace algos3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    // #1 LINKED LIST
    public class SLNode
    {
        public int Value {get; set;}
        public SLNode Next {get; set;}

        public SLNode(int val) 
        {
            Value = val;
            Next = null;
        }
    }
    public class SLList
    {
        public SLNode Head {get; set;}

        public SLList () 
        {
            Head = null;
        }
    
        public void ReverseLinkedList()
        {
            if (Head == null) 
                return;
            SLNode curr = Head;
            if (curr.Next == null)
                return;
            SLNode next = curr.Next;
            SLNode prev = null;
            while (curr.Next != null)
            {
                curr.Next = prev;
                prev = curr;
                next = curr.Next;
            }
            curr.Next = prev;
            Head = curr;
        }
    }

    // #2, 3 BINARY SEARCH TREES
    public class BSTNode
    {
        public int Value {get; set;}
        public BSTNode Left {get; set;}
        public BSTNode Right {get; set;}
        public BSTNode(int val)
        {
            Value = val;
            Left = null;
            Right = null;
        }
    }
    public class BST
    {
        public BSTNode Root {get; set;}

        public BST()
        {
            Root = null;
        }

        public void Add (int val)
        {
            BSTNode newNode = new BSTNode(val);
            myAdd(Root, newNode);
        }
        private void myAdd(BSTNode currNode, BSTNode newNode)
        {
            if (newNode.Value < currNode.Value) 
            {
                if (currNode.Left == null) 
                {
                    currNode.Left = newNode;
                    return;
                }
                else
                {
                    myAdd(currNode.Left, newNode);
                }
            }
            else
            {
                if (currNode.Right == null)
                {
                    currNode.Right = newNode;
                    return;
                }
                else
                {
                    myAdd(currNode.Right, newNode);
                }
            }
        }

        public int Size()
        {
            return mySize(Root);
        }
        private int mySize(BSTNode currNode)
        {
            if (currNode == null)
                return 0;
            return 1 + mySize(currNode.Left) + mySize(currNode.Right);
        }
    }

    // #4 GRAPHS
    public class Graph
    {
        public SLNode[] Adjs {get; set;}

        public Graph (int[] vertexValues)
        {
            Adjs = new SLNode[vertexValues.Length];
            for (int i=0; i<vertexValues.Length; i++)
            {
                SLNode vert = new SLNode(vertexValues[i]);
                Adjs[i] = vert;
            }
        }

        public void AddEdgeUndir(int oneVert, int twoVert)
        {
            int added = 0;
            int idx = 0;
            while (added < 2 && idx < Adjs.Length)
            {
                if (Adjs[idx].Value == oneVert)
                {
                    myAddEdge(Adjs[idx], twoVert);
                    added++;
                }
                if (Adjs[idx].Value == twoVert)
                {
                    myAddEdge(Adjs[idx], oneVert);
                    added++;
                }
                idx++;
            }
        }
        public void AddEdgeDirected(int fromVert, int toVert)
        {
            int added = 0;
            int idx = 0;
            while (added < 1 && idx < Adjs.Length)
            {
                if (Adjs[idx].Value == fromVert)
                {
                    myAddEdge(Adjs[idx], toVert);
                    added++;
                }
                idx++;
            }
        }
        private void myAddEdge(SLNode from, int toVal)
        {
            if (from.Next == null) 
            {
                SLNode newNode = new SLNode(toVal);
                from.Next = newNode;
                return;
            }
            else
            {
                myAddEdge(from.Next, toVal);
            }
        }
    }
// #5 CONCEPTUAL
//Most BST operations are O(logN) because half of the tree can be
//eliminated at each step.
//Edges in a directed graph can only be traversed in one direction.
//In an undirected graph, edges can be traversed in 
//either direction.
//Weighted edges allow certain paths through the graph to be prioritized
//based on some criteria. An example is a map with routes between 
//locations as edges - these edges could be weighted based on
//current traffic.
//Breadth-first searching proceeds by degrees of separation: all 
//first-level adjacencies are checked first, followed by second, etc.
//For depth-first, it's necessary to traverse a path all the way
//to the end before backing up and completing the next branch, etc.


