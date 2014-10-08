using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.LinkedList
{
    public class Sort012
    {
        private class Node
        {
            public Node next;
            public int data;
            public int count;
        }

        private Node AddNodeAtStart(Node root, int input, int count)
        {
            Node tmp = new Node();
            tmp.data = input;
            tmp.count = count;

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
                Console.WriteLine(" Position : {0}, data : {1}", tmp.count, tmp.data);
                tmp = tmp.next;
            }
        }

        private void Join(ref Node astart, ref Node aend, Node bstart, Node bend)
        {
            if (astart == null)
            {
                astart = bstart;
                aend = bend;
            }
            else if (bstart != null)
            {
                aend.next = bstart;
                aend = bend;
            }
        }

        private void Append(ref Node start, ref Node end, Node toAdd)
        {
            if (start == null)
                start = toAdd;
            else
            {
                end.next = toAdd;
            }
            end = toAdd;
        }

        // work with 6 pointers (3 to maintain start position of 0,1,2 and other 3 to maintain end of 0,1,2)
        private Node Sort(Node header)
        {
            if (header == null)
            {
                Console.WriteLine("List is empty");
                return null;
            }

            Node[] start = new Node[3] { null, null, null };
            Node[] end = new Node[3] { null, null, null };

            for (Node n = header; n != null; n = n.next)
            {
                int data = n.data;
                if (data < 0 || data > 2)
                {
                    Console.WriteLine("list node has invalid data {0}", data);
                    return null;
                }
                Append(ref start[data], ref end[data], n);
            }
            header = start[0];
            Node tail = end[0];
            Join(ref header, ref tail, start[1], end[1]);
            Join(ref header, ref tail, start[2], end[2]);
            tail.next = null;

            return header;
        }

        public void Test()
        {

            Node head = null;
            head = AddNodeAtStart(head, 1, 8);
            head = AddNodeAtStart(head, 2, 7);
            head = AddNodeAtStart(head, 1, 6);
            head = AddNodeAtStart(head, 0, 5);
            head = AddNodeAtStart(head, 2, 4);
            head = AddNodeAtStart(head, 0, 3);
            head = AddNodeAtStart(head, 0, 2);
            head = AddNodeAtStart(head, 2, 1);
            head = AddNodeAtStart(head, 1, 0);

            Console.WriteLine(" List1 nodes");
            Display(head);

            var result = Sort(head);
            if (result != null)
            {
                Console.WriteLine("\n Sorted list ");
                Display(result);
            }

            Console.WriteLine("\n\n Hit enter key to exit.");
            Console.ReadLine();

        }
    }
}
