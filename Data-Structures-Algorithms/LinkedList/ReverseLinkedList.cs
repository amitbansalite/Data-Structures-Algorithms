using System;

namespace Algorithms.Problems
{
    public class ReverseLinkedList
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

        public void Test()
        {
            Node head = null;

            head = AddNodeAtStart(head, 1);
            //head = AddNodeAtStart(head, 2);
            //head = AddNodeAtStart(head, 3);
            //head = AddNodeAtStart(head, 4);

            Console.WriteLine(" List1 nodes");
            Display(head);
            Console.WriteLine("\n\n");

            var result = ReverseList(head);
            Display(result);

            Console.WriteLine("\n\n Hit enter key to exit.");
            Console.ReadLine();
        }
    }
}
