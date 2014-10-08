using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.BST
{
    public class LCA
    {
        private class Node
        {
            public Node left;
            public Node right;
            public int data;
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
                root = new Node() { data = input};
                return root;
            }

            var val = input.CompareTo(root.data);

            if (val < 0)
                root.left = AddNode(root.left, input);
            else if (val > 0)
                root.right = AddNode(root.right, input);

            return root;
        }

        // assuming that both values are present in the tree somewhere
        // 1. if both are left than current node then go left
        // 2. if both are greater than current node then go right
        // 3. else return current node
        private Node GetLCA(Node node, int num1, int num2)
        {
            if (node == null)
                return null;

            if (num1 < node.data && num2 < node.data)
                return GetLCA(node.left, num1, num2);
            else if (num1 > node.data && num2 > node.data)
                return GetLCA(node.right, num1, num2);
            else
                return node;
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

            InOrderRecursive(root);

            var result = GetLCA(root, 25, 40);

            if (result != null)
                Console.WriteLine("\n LCA is : {0}", result.data);
            else
            {
                Console.WriteLine("\n LCA is : {0}", result.data);
            }

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
