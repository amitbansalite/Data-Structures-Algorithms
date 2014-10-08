using System;

// input =>  1->2->3->4->5->6->7
// output => 2->1->4->3->6->5->7

namespace Algorithms.Problems
{
    public class PairWiseSwap
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

        private Node SwapPairWise(Node root)
        {
            if (root == null)
            {
                Console.WriteLine("List is empty");
                return null;
            }

            if (root.next == null && root.next.next == null)
                return root;

            Node newStart = root.next;

            Node t1 = null;
            Node t2 = root;
            Node t3 = root.next;
            Node t4 = root.next.next;

            while (t4 != null)
            {
                if (t1 == null)
                {
                    t3.next = t2;
                    t2.next = t4;
                }
                else
                {
                    t1.next = t3;
                    t3.next = t2;
                    t2.next = t4;
                }
                t1 = t2;
                t2 = t4;
                if (t4.next == null || t4.next.next == null)
                    break;
                t3 = t4.next;
                t4 = t4.next.next;
            }
            return newStart;
        }

        public void Test()
        {
            Node head = null;

            head = AddNodeAtStart(head, 7);
            head = AddNodeAtStart(head, 6);
            head = AddNodeAtStart(head, 5);
            head = AddNodeAtStart(head, 4);
            head = AddNodeAtStart(head, 3);
            head = AddNodeAtStart(head, 2);
            head = AddNodeAtStart(head, 1);

            Console.WriteLine(" List1 nodes");
            Display(head);

            var result = SwapPairWise(head);
            Console.WriteLine("\n\n After swapping pairwise elements.");
            Display(result);

            Console.WriteLine("\n\n Hit enter key to exit.");
            Console.ReadLine();
        }
 
    }
}
