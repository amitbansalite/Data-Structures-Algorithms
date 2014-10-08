using System;

namespace Algorithms.Problems.BST
{
    public class BSTtoSingleLinkedList
    {
        private class Node
        {
            public int data;
            public Node left;
            public Node right;
        }

        private class ListNode
        {
            public int data;
            public ListNode next;
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

        private void AppendAtStart(Node node, ref ListNode header)
        {
            ListNode tmp = new ListNode(){data = node.data, next = null};

            if (header == null)
            {
                header = tmp;
            }
            else
            {
                tmp.next = header;
                header = tmp;
            }
        }

        private void AppendToEnd(Node node, ref ListNode header)
        {
            if (header == null)
            {
                header = new ListNode(){data = node.data, next = null};
            }
            else
            {
                ListNode tmp = header;
                while (tmp.next != null)
                {
                    tmp = tmp.next;
                }
                tmp.next = new ListNode() { data = node.data, next = null };    
            }
        }

        // inorder
        private void ConvertToList(Node node, ref ListNode header)
        {
            if (node == null)
                return;

            ConvertToList(node.left, ref header);
            AppendToEnd(node, ref header);
            ConvertToList(node.right, ref header);
        }

        // reverse inorder
        private void ConvertToListEffiecinet(Node node, ref ListNode header)
        {
            if (node == null)
                return;

            ConvertToListEffiecinet(node.right, ref header);
            AppendAtStart(node, ref header);
            ConvertToListEffiecinet(node.left, ref header);
        }

        private void DisplayLinkedList(ListNode root)
        {
            ListNode tmp = root;
            while (tmp != null)
            {
                Console.WriteLine(tmp.data);
                tmp = tmp.next;
            }
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

            ListNode header = null;

            ConvertToListEffiecinet(root, ref header);

            Console.WriteLine("\n Linked list is as follows : ");
            DisplayLinkedList(header);

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
