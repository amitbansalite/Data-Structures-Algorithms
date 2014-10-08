using System;

// need to create balanced BST

// In place conversion
// think binary search as if you were given a sorted array ad told to convert to balanced BST


namespace Algorithms.Problems.BST
{
    public class SortedDoublyLinkedListToBST
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

        private void Display(Node root)
        {
            Node tmp = root;
            while (tmp != null)
            {
                Console.WriteLine(tmp.data);
                tmp = tmp.right;
            }
        }

        private Node AddNodeAtStart(Node root, int input)
        {
            Node tmp = new Node();
            tmp.data = input;

            if (root == null)
            {
                root = tmp;
            }
            else
            {
                tmp.right = root;
                root.left = tmp;
                root = tmp;
            }
            return root;
        }

        private Node CreateBst(ref Node dll, int low, int high)
        {
            if (high < low) return null;

            int mid = low + (high - low) / 2;

            var leftChild = CreateBst(ref dll, low, mid - 1);
            dll.left = leftChild;

            Node tmp = dll;
            dll = dll.right;

            var rightChild = CreateBst(ref dll, mid + 1, high);
            tmp.right = rightChild;

            return tmp;
        }

        public void Test()
        {
            Node head = null;
            head = AddNodeAtStart(head, 10);
            head = AddNodeAtStart(head, 9);
            head = AddNodeAtStart(head, 8);
            head = AddNodeAtStart(head, 7);
            head = AddNodeAtStart(head, 6);
            head = AddNodeAtStart(head, 5);
            head = AddNodeAtStart(head, 4);
            head = AddNodeAtStart(head, 3);
            head = AddNodeAtStart(head, 2);
            head = AddNodeAtStart(head, 1);

            Console.WriteLine(" Sorted Linked List nodes");
            Display(head);

            // in terms of binary search
            var low = 0;    // start node position
            var high = 9;   //  length of linked list
            var tmp = head;
            var root = CreateBst(ref tmp, low, high);


            Console.WriteLine(" Inorder traversal of BST");
            InOrderRecursive(root);
            
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
