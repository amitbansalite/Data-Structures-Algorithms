using System;

namespace Algorithms.Problems
{
    public class AddNumbersUsingLinkedLists
    {
        public class Node
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

        private Node AddLists(Node node1, Node node2, Node newRoot, ref int rem)
        {
            if (node1 == null)
                return newRoot;

            newRoot = AddLists(node1.next, node2.next, newRoot, ref rem);

            int sum = node1.data + node2.data + rem;
            rem = sum / 10;
            newRoot = AddNodeAtStart(newRoot, sum % 10);
            return newRoot;
        }

        private Node AddNumbers(Node root1, Node root2)
        {
            Node newRoot = null;
            int rem = 0;

            // 1.check for length of both and fwd the larger one till both become equal
            int list1Length = Length(root1);
            int list2Length = Length(root2);
            int diff = list1Length - list2Length;

            Node list1StartNode = root1;
            Node list2StartNode = root2;

            if (diff > 0)
            {
                int tmp = diff;
                while (tmp > 0)
                {
                    list1StartNode = list1StartNode.next;
                    tmp--;
                }
            }
            else if (diff < 0)
            {
                int tmp = diff;
                while (tmp < 0)
                {
                    list2StartNode = list2StartNode.next;
                    tmp++;
                }
            }

            newRoot = AddLists(list1StartNode, list2StartNode, newRoot, ref rem);

            // 3. add remaining nodes at start from larger list
            if (diff != 0)
            {
                if (diff > 0)
                    newRoot = AddRemainderNodesToResultList(newRoot, root1, diff, ref rem);
                else
                    newRoot = AddRemainderNodesToResultList(newRoot, root2, -diff, ref rem);
            }
            if (rem > 0)
            {
                newRoot = AddNodeAtStart(newRoot, rem);
            }

            return newRoot;
        }

        private Node AddRemainderNodesToResultList(Node newRoot, Node inNode, int diff, ref int rem)
        {
            if (diff == 0)
                return newRoot;

            newRoot = AddRemainderNodesToResultList(newRoot, inNode.next, --diff, ref rem);
            int sum = inNode.data + rem;
            rem = sum / 10;
            newRoot = AddNodeAtStart(newRoot, sum % 10);
            return newRoot;
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

        public void Test()
        {
            Node list1 = null;
            Node list2 = null;

            list2 = AddNodeAtStart(list2, 9);
            list2 = AddNodeAtStart(list2, 9);
            list2 = AddNodeAtStart(list2, 9);
            list1 = AddNodeAtStart(list1, 8);

            Console.WriteLine(" List1 nodes");
            Display(list1);
            Console.WriteLine(" List2 nodes");
            Display(list2);

            var result = AddNumbers(list1, list2);
            Console.WriteLine(" Result nodes after adding 2 lists");
            Display(result);

            Console.WriteLine("Hit enter key to exit.");
            
            Console.ReadLine();
        }
    }
}
