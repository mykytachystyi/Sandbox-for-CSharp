using System;
using System.Collections.Generic;

namespace BinaryTreeExample
{
    internal class Program
    {
        static BTreeVisualizer visualizer = new BTreeVisualizer();

        static Action<Node> hello = node => Console.WriteLine($"Node - {node.Value}");

        static void Main(string[] args)
        {
            Console.WriteLine("Depth First Search for binary tree algorithm: ");
            DFSWriteLine();
            Console.WriteLine("Breadth First Search for binary tree algorithm: ");
            BFSWriteLine();
            Console.Read();
        }
        static void DFSWriteLine()
        {
            var tree = new BinaryTree(hello);

            var n1 = new Node { Value = 1 };
            var n2 = new Node { Value = 2 };
            var n3 = new Node { Value = 3 };
            var n4 = new Node { Value = 4 };
            var n5 = new Node { Value = 5 };
            var n6 = new Node { Value = 6 };
            n1.Right = n2;
            n1.Left = n3;
            n2.Right = n4;
            n2.Left = n5;
            n4.Right = n6;

            visualizer.PrintTree(n1);
            tree.DFS(n1);
        }
        static void BFSWriteLine()
        {
            var tree = new BinaryTree(hello);

            var n1 = new Node { Value = 1 };
            var n2 = new Node { Value = 23 };
            var n3 = new Node { Value = 853 };
            var n4 = new Node { Value = 1203 };
            var n5 = new Node { Value = 857 };
            var n6 = new Node { Value = 937 };
            n1.Right = n2;
            n1.Left = n3;
            n3.Left = n4;
            n3.Right = n5;
            n4.Right = n6; 

            tree.Root = n1;

            var visualizer = new BTreeVisualizer();
            visualizer.PrintTree(n1);
            tree.BFS(n1);
        }
    }
    public class BinaryTree
    {
        public delegate void BinaryTreeDelegate(Node tree);
        public Action<Node> @delegate { get; set; }
        public Node Root { get; set; }
        public Node Leaf { get; set; }

        public BinaryTree(Action<Node> treeDelegate)
        {
            @delegate = treeDelegate;
        }
        /// <summary>
        /// Main idea that we always go to right node until we reach the end of the tree, then we go to left node and repeat the process.
        /// </summary>
        /// <param name="root"></param>
        public void DFS(Node root)
        {
            if (root != null)
            {
                @delegate(root);
                DFS(root.Right); 
                DFS(root.Left);
            }
        }

        /// <summary>
        /// Main idea is to use queue to store the nodes. We start from the root node and add it to the queue. Then we remove the first node from the queue and add its children to the queue.
        /// </summary>
        /// <param name="root"></param>
        public void BFS(Node root)
        {
            if (root == null)
            {
                return;
            }

            var queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                @delegate(node);
                if (node.Left != null)
                    queue.Enqueue(node.Left);
                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }
        }
    }
    public class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
    public class BTreeVisualizer
    {
        public void PrintTree(Node node, string indent = "", bool isLeft = true)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(indent + (isLeft ? "├── " : "└── ") + node.Value);

            indent += isLeft ? "│   " : "    ";

            PrintTree(node.Left, indent, true);
            PrintTree(node.Right, indent, false);
        }
    }
}