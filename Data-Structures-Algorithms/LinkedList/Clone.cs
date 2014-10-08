using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems
{
    public class Clone
    {
        private class Node
        {
            public int data;
            public Node next;
            public Node arbit;
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

        private void Display(Node root)
        {
            Node tmp = root;
            while (tmp != null)
            {
                Console.WriteLine(tmp.data);
                tmp = tmp.next;
            }
        }

        private Node CloneList(Node root)
        {
            Node original = root;

            if (original.next == null)
            {
                Node clone = new Node();
                clone.data = original.data;
                clone.next = null;
                clone.arbit = null;
                return clone;
            }

            // 1. create a new node between every 2 nodes
            while (original != null)
            {
                Node temp = original.next;
                original.next = new Node() { data = original.data };
                original.next.next = temp;
                original = temp;
            }

            Node newHead = root.next;
            original = root;

            while (original.next.next != null)
            {
                original.next.arbit = original.next.next.next;
                original = original.next.next;
            }

            original = root;
            Node copy = newHead;
            while (copy.arbit != null && original != null)
            {
                original.next = original.next.next;
                original = original.next;
                copy.next = copy.arbit;
                copy = copy.next;
            }
            return newHead;
        }

        public void Test()
        {
            Node head = null;

            head = AddNodeAtStart(head, 1);
            head = AddNodeAtStart(head, 2);
            head = AddNodeAtStart(head, 3);
            head = AddNodeAtStart(head, 4);

            Console.WriteLine(" original nodes");
            Display(head);
            
            Console.WriteLine("\n\n Clone nodes");
            var result = CloneList(head);
            Display(result);

            Console.WriteLine("\n\n original nodes");
            Display(head);

            Console.WriteLine("\n\n Hit enter key to exit.");
            Console.ReadLine();

        }
 
    }
}
