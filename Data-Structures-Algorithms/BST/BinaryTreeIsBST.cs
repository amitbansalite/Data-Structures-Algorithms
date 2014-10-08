using System;

namespace Algorithms.Problems.BST
{
    public class BinaryTreeIsBST
    {
        private class Node
        {
            public int data;
            public Node left;
            public Node right;
            public Node successor;
            public Node predecessor;
        }

        private void InOrderRecursive(Node node)
        {
            if (node == null)
                return;

            InOrderRecursive(node.left);
            Console.WriteLine(node.data);
            InOrderRecursive(node.right);
        }

        private Node AddNode(Node root, int input)
        {
            if (root == null)
            {
                root = new Node() { data = input };
                return root;
            }

            var val = input.CompareTo(root.data);

            if (val < 0)
                root.left = AddNode(root.left, input);
            else if (val > 0)
                root.right = AddNode(root.right, input);

            return root;
        }

        // think Inorder traversal of BST would result in sorted elements
            // Hence checking that each node should be less than the previous and more than the next
        private bool IsBST(Node node, int min, int max)
        {
            if (node == null)
                return true;

            if ( min < node.data && node.data < max)
                return (IsBST(node.left, min, node.data) && IsBST(node.right, node.data, max));
            
            return false;
        }


        // again InOrder approach
            // but maintaining a previous ptr to check for sorted condition
        private bool IsBST(Node node, ref Node prev)
        {
            if (node == null)
                return true;

            IsBST(node.left, ref prev);
            if (prev != null && prev.data > node.data)
                return false;
            return IsBST(node.right, ref node);
        }

        private bool GetLargestBST(Node node, int min, int max, ref int count, ref int best, ref Node bstRoot)
        {
            if (node == null)
            {
                count++;
                return true;
            }

            if (min < node.data && node.data < max)
            {
                var result = ( GetLargestBST(node.left, min, node.data, ref count, ref best, ref bstRoot) && 
                               GetLargestBST(node.right, node.data, max, ref count, ref best, ref bstRoot));
                if (result)
                {
                    count++;
                    if (best < count)
                    {
                        best = count;
                        bstRoot = node;
                    }
                }
                return result;
            }

            return false;
        }



        public void Test()
        {
            var root = AddNode(null, 30);
            AddNode(root, 20);
            AddNode(root, 25);
            AddNode(root, 22);
            AddNode(root, 40);
            AddNode(root, 50);
            AddNode(root, 45);

            InOrderRecursive(root);

            //var result = IsBST(root, 0, int.MaxValue);
            //Node prev = null;
            //var result = IsBST(root, ref prev);

            int count = 0;
            int bestCount = 0;
            Node bstRoot = null;

            var result = GetLargestBST(root, 0, int.MaxValue, ref count, ref bestCount, ref bstRoot);

            if (result)
            {
                Console.WriteLine("\n The given tree has a subtree which is a BST of largest length {0} rooted at node with value {1}",
                                        bestCount, bstRoot.data);
            }
            else
                Console.WriteLine("\n The given tree does not have any subtree which is a BST");

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
