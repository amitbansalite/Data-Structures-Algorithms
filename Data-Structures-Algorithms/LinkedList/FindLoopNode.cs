using System;

namespace Algorithms.Problems
{
    public class FindLoopNode
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

        private void CreateLoop(Node head, int loopNodeData)
        {
            Node tmp = head;

            while (tmp.data != loopNodeData)
            {
                tmp = tmp.next;
            }
            Node loopNode = tmp;

            while (tmp.next != null)
            {
                tmp = tmp.next;
            }
            tmp.next = loopNode;
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
        
        private Node FindStartNode(Node root, int count)
        {
            Node ahead = root;
            while (count > 0)
            {
                ahead = ahead.next;
                count--;
            }

            Node behind = root;

            while (behind != ahead)
            {
                behind = behind.next;
                ahead = ahead.next;
            }
            return behind;
        }

        private Node FindLoopStartNode(Node root)
        {
            if (root == null)
            {
                Console.WriteLine("Node has 0 and 1 node only");
                return null;
            }
         
            Node slow = root;
            Node fast = root.next;
 
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (slow == fast)
                {
                    int count = 1; 
                    fast = fast.next;
                    while (slow != fast)
                    {
                        fast = fast.next;
                        count++;
                    }

                    Console.WriteLine("\n Loop exists and Number of nodes in the loop : {0}", count);

                    return FindStartNode(root, count );
                }
            }
            Console.WriteLine("Loop does NOT exist in the given Linked List.");
            return null;
        }

        public void Test()
        {
            Node head = null;
            head = AddNodeAtStart(head, 1);
            head = AddNodeAtStart(head, 2);
            head = AddNodeAtStart(head, 3);
            head = AddNodeAtStart(head, 4);

            Console.WriteLine(" List1 nodes");
            Display(head);

            int loopNodeValue = 4;
            Console.WriteLine("last node is pointing at node with data : {0}", loopNodeValue);
            CreateLoop(head, loopNodeValue);

            var result = FindLoopStartNode(head);
            if (result != null)
            {
                Console.WriteLine(" Loop starts at node : {0}", result.data);
            }

            Console.WriteLine("\n\n Hit enter key to exit.");
            Console.ReadLine();
        }
    }
}
