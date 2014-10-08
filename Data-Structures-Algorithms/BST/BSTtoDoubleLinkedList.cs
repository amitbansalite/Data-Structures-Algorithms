using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.BST
{
    public class BSTtoDoubleLinkedList
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

        private void DisplayLinkedList(Node root)
        {
            Node tmp = root;
            while (tmp != null)
            {
                Console.WriteLine(tmp.data);
                tmp = tmp.right;
            }
        }

        private void Convert(Node curr, ref Node prev, ref Node header)
        {
            if (curr == null)
                return;

            Convert(curr.left, ref prev, ref header);

            curr.left = prev;

            if (header == null)
                header = curr;
            else
                prev.right = curr;

            prev = curr;
            Convert(curr.right, ref prev, ref header);
        }

        public void Test()
        {
            var root = AddNode(null, 30);
            AddNode(root, 20);
            AddNode(root, 25);
            AddNode(root, 22);
            AddNode(root, 40);

            InOrderRecursive(root);

            Node header = null;
            Node prev = null;
            Convert(root, ref prev, ref header);

            Console.WriteLine("\n Linked list is as follows : ");
            DisplayLinkedList(header);

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

    }
}
