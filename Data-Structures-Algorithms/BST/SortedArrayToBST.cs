using System;

// need to create balanced BST

// think binary search

namespace Algorithms.Problems.BST
{
    public class SortedArrayToBST
    {
        private class Node
        {
            public int data;
            public Node left;
            public Node right;
        }

        private void InOrderRecursive(Node node)
        {
            if (node == null)
                return;

            InOrderRecursive(node.left);
            Console.WriteLine(node.data);
            InOrderRecursive(node.right);
        }

        private Node NewNode(int input)
        {
            var root = new Node() { data = input };
            return root;
        }

        private Node CreateBst(int[] a, int low, int high)
        {
            if (high < low) return null;

            int mid = low + (high - low)/2;
            var node = NewNode(a[mid]);
            node.left = CreateBst(a, low, mid - 1);
            node.right = CreateBst(a, mid + 1, high);
            return node;
        }

        public void Test()
        {
            var a = new int[10] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var root = CreateBst(a, 0, a.Length - 1);
            InOrderRecursive(root);

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
