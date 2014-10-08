using System;

// need to create balanced BST

// think binary search
    // now we cannot perform Binary search for linked list
        // so think how could traverse list in order and keep creating BST at the same time 
        // (bottom up construction)

namespace Algorithms.Problems.BST
{
    public class SortedLinkedListToBST
    {
        #region BST
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
#endregion

        #region LinkedList
        private class ListNode
        {
            public int data;
            public ListNode next;
        }

        private void Display(ListNode root)
        {
            ListNode tmp = root;
            while (tmp != null)
            {
                Console.WriteLine(tmp.data);
                tmp = tmp.next;
            }
        }

        private ListNode AddNodeAtStart(ListNode root, int input)
        {
            ListNode tmp = new ListNode();
            tmp.data = input;

            if (root == null)
            {
                root = tmp;
            }
            else
            {
                tmp.next = root;
                root = tmp;
            }
            return root;
        }
        #endregion 
        
        private Node CreateBst(ref ListNode list, int low, int high)
        {
            if (low > high) return null;

            int mid = low + (high - low) / 2;

            var leftChild = CreateBst(ref list, low, mid-1);
            
            var parent = NewNode(list.data);
            parent.left = leftChild;

            list = list.next;

            var rightChild = CreateBst(ref list, mid + 1, high);
            parent.right = rightChild;

            return parent;
        }

        public void Test()
        {
            ListNode head = null;
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

            Console.WriteLine(" Sorted Linked List nodes after tree creation");
            Display(head);

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
