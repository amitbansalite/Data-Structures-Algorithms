using System;
using System.Collections.Generic;

namespace Algorithms.Problems.BST
{
    public class InOrderUsingStack
    {
        private class Node
        {
            public Node left;
            public Node right;
            public bool visited;
            public int data;

            // to be used to calculate depth
            public int level;
        }

        private Node AddNode(Node root, int input, int level = 1)
        {
            if (root == null)
            {
                root = new Node() { data = input, level = level };
                return root;
            }

            var val = input.CompareTo(root.data);

            if (val < 0)
                root.left = AddNode(root.left, input, root.level + 1);
            else if (val > 0)
                root.right = AddNode(root.right, input, root.level + 1);

            return root;
        }

        private void LevelOrderTraversal(Node root)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                Console.WriteLine(node.data + " : " + node.level);
                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }
        }

        // NEED to use an extra pointer in the node definition to keep track of visited node
        private void InorderTraversalUsingStack(Node root)
        {
            if (root == null)
                Console.WriteLine(" The tree is empty");
            
            var stack = new Stack<Node>();
            stack.Push(root);
            
            while (stack.Count > 0)
            {
                var node = stack.Peek();
                if (node.left != null && node.visited == false)
                {
                    node.visited = true;
                    stack.Push(node.left);
                }
                else
                {
                    stack.Pop();
                    Console.WriteLine(node.data);
                 
                    if (node.right != null)
                    {
                        node.visited = true;
                        stack.Push(node.right);
                    }
                }
            }
        }

        // NEED to use an extra pointer to maintian the next successor
        private void InorderTraversalUsingStack_ExtraPtr(Node root)
        {
            if (root == null)
                Console.WriteLine(" The tree is empty");

            Node currentPtr = root;
            var stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Peek();
                if (currentPtr != null)
                {
                    currentPtr = node.left;
                    if (node.left != null)
                        stack.Push(node.left);
                }
                else
                {
                    stack.Pop();
                    Console.WriteLine(node.data);

                    if (node.right != null)
                    {
                        currentPtr = node.right;
                        stack.Push(node.right);
                    }
                }
            }
        }

        // NEED to use an extra pointer to maintian the next successor
        private int GetDepthUsingStack(Node root)
        {
            if (root == null)
                Console.WriteLine(" The tree is empty");

            int depth = 0;

            Node currentPtr = root;
            var stack = new Stack<Node>();
            depth = root.level;
            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Peek();
                if (currentPtr != null)
                {
                    currentPtr = node.left;
                    if (node.left != null)
                    {
                        if (node.left.level > depth)
                            depth = node.left.level;
                        stack.Push(node.left);
                    }
                }
                else
                {
                    stack.Pop();
                    
                    if (node.right != null)
                    {
                        if (node.right.level > depth)
                            depth = node.right.level;
                        currentPtr = node.right;
                        stack.Push(node.right);
                    }
                }
            }
            return depth;
        }
        
        public void Test()
        {
            var root = AddNode(null, 20);
            AddNode(root, 10);
            AddNode(root, 5);
            AddNode(root, 15);
            AddNode(root, 12);
            AddNode(root, 14);
            AddNode(root, 17);
            AddNode(root, 18);
            AddNode(root, 19);
            AddNode(root, 30);
            AddNode(root, 25);
            AddNode(root, 40);

            LevelOrderTraversal(root);

            var result = GetDepthUsingStack(root);

            Console.WriteLine("\n Max depth of tree is : {0}", result);

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
