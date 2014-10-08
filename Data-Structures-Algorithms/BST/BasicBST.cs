using System;
using System.Collections.Generic;

namespace Algorithms.Problems.BST
{
    public class BasicBST
    {
        private class Node
        {
            public Node left;
            public Node right;
            public int data;
            public int count;   // number of nodes in the subtree rooted at this node
        }

        private int size(Node x)
        {
            return x != null ? x.count : 0;
        }

        private Node AddNode(Node root, int input)
        {
            if (root == null)
            {
                root = new Node() { data = input , count = 1};
                return root;
            }

            var val = input.CompareTo(root.data);

            if (val < 0)
                root.left = AddNode(root.left, input);
            else if (val > 0)
                root.right = AddNode(root.right, input);

            root.count = 1 + size(root.left) + size(root.right);
            return root;
        }

        private void InOrderRecursive(Node node)
        {
            if (node == null)
                return;

            InOrderRecursive(node.left);
            Console.WriteLine(node.data);
            InOrderRecursive(node.right);
        }

        private void LevelOrderTraversal(Node root)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                Console.WriteLine(node.data);
                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }
        }

        private bool Contains(Node x, int key)
        {
            if (x == null) return false;

            if (x.data > key)
                return Contains(x.left, key);
            else if (x.data < key)
                return Contains(x.right, key);
            else
                return true;
        }

        private int Depth(Node node)
        {
            if (node == null)
                return 0;

            return 1 + Math.Max(Depth(node.left), Depth(node.right));
        }

        // nodes in BST that are less than the given key
        private int Rank(Node x, int key)
        {
            if (key == null) return 0;

            if (x.data > key)
                return Rank(x.left, key);
            else if (x.data < key)
                return 1 + size(x.left) + Rank(x.right, key);
            else
                return size(x.left);
        }

        // nodes in BST that are between the given keys (inclusive)
        private int Range(Node node, int l, int r)
        {
            if (Contains(node, r))
                return Rank(node, r) - Rank(node, l) + 1;
            else
                return Rank(node, r) - Rank(node, l);
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

            Console.WriteLine("\n Inorder traversal ");
            InOrderRecursive(root);
            Console.WriteLine("\n Level order traversal ");
            LevelOrderTraversal(root);
            Console.WriteLine("\n The max depth of the tree is {0}", Depth(root));
            
            Console.WriteLine("\n Elements less than {0} is {1}", 19, Rank(root, 19));

            Console.WriteLine("\n Elements between {0} and {1} is {2}", 17, 25, Range(root, 17, 25));

            Console.WriteLine("\n\n Press enter to exit.");
            Console.ReadLine();
        }
    }
}
