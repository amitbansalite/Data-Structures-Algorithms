using System;

namespace Algorithms.Problems.LinkedList
{
    public class Sort0And1
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

        private Node AddAtStart(Node root, Node input)
        {		
	        input.next = root;
	        root = input;
	        return root;	
        }

        private Node Sort01(Node curr)
        {
            Node header = curr;

            if (header == null)
                return null;

            Node prev = null;

            while (curr != null)
            {
                if (prev != null && curr.data == 0)
                {
                    prev.next = curr.next;
                    Node nodeToShift = curr;
                    curr = curr.next;
                    
                    header = AddAtStart(header, nodeToShift);
                }
                else
                {
                    prev = curr;
                    curr = curr.next;    
                }
            }
            return header;
        }
        
        public void Test()
        {

            Node head = null;
            head = AddNodeAtStart(head, 0, 8);
            head = AddNodeAtStart(head, 0, 7);
            head = AddNodeAtStart(head, 1, 6);
            head = AddNodeAtStart(head, 0, 5);
            head = AddNodeAtStart(head, 0, 4);
            head = AddNodeAtStart(head, 0, 3);
            head = AddNodeAtStart(head, 0, 2);
            head = AddNodeAtStart(head, 1, 1);
            head = AddNodeAtStart(head, 1, 0);

            Console.WriteLine(" List1 nodes");
            Display(head);

            var result = Sort01(head);
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
