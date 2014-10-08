using System;

namespace Algorithms.Problems
{
    public class PalindromeLinkedList
    {
        private class Node
        {
            public int data;
            public Node next;
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
                tmp.next = root;
                root = tmp;
            }
            return root;
        }

        private void Display(Node root)
        {
            Node tmp = root;
            while (tmp != null)
            {
                Console.WriteLine(tmp.data);
                tmp = tmp.next;
            }
        }

        private int Length(Node root)
        {
            int count = 0;
            Node tmp = root;
            while (tmp != null)
            {
                tmp = tmp.next;
                count++;
            }
            return count;
        }

        private Node ReverseList(Node root)
        {
            if (root == null)
            {
                Console.WriteLine("List is empty");
                return null;
            }

            if (root.next == null)
                return root;

            Node t1 = null;
            Node t2 = root;
            Node t3 = root.next;

            while (t3 != null)
            {
                t2.next = t1;
                t1 = t2;
                t2 = t3;
                t3 = t3.next;
            }
            t2.next = t1;

            return t2;
        }

        private void IsPalindromeUsingRecursion(ref Node root, Node tmp)
        {
            if (tmp == null)
                return;

            IsPalindromeUsingRecursion(ref root, tmp.next);

            if (root.data != tmp.data)
            {
                Console.WriteLine(" NOT PALINDROME");
                Environment.Exit(1);
            }
            root = root.next;
        }

        private bool IsPalindromeUsingReverseMethod(Node root)
        {
            Node tmp = root;
            Node end = null;
            int len = Length(root);
            int mid = len/2;
            int count = 0;
            
            while (count != mid)
            {
                tmp = tmp.next;
                count++;
            }
            end = ReverseList(tmp);
            Node endtmp = end;
            Node starttmp = root;

            while (endtmp != null)
            {
                if (starttmp.data != endtmp.data)
                {
                    ReverseList(end);
                    return false;
                }

                starttmp = starttmp.next;
                endtmp = endtmp.next;
            }
            ReverseList(end);
            return true;
        }

        public void Test()
        {
            Node head = null;

            head = AddNodeAtStart(head, 4);
            head = AddNodeAtStart(head, 3);
            head = AddNodeAtStart(head, 2);
            head = AddNodeAtStart(head, 2);
            head = AddNodeAtStart(head, 3);
            head = AddNodeAtStart(head, 4);
            
            Console.WriteLine(" List1 nodes");
            Display(head);

            //var result = IsPalindromeUsingReverseMethod(head);

            Node start = head;
            IsPalindromeUsingRecursion(ref start, head);
            Console.WriteLine("\n\n Palindrome ");

            //if (result)
            //    Console.WriteLine("\n\n Palindrome ");
            //else
            //    Console.WriteLine("\n\n Not Palindrome");

            Console.WriteLine("\n\n Verifying original list is at is.");
            Display(head);

            Console.WriteLine("\n\n Hit enter key to exit.");
            Console.ReadLine();
        }
    }
}
