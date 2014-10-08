using System;

namespace Algorithms.Problems.BST
{
    public class SuccessorPredecessor
    {
        private class Node
        {
            public int data;
            public Node left;
            public Node right;
            public Node successor;
            public Node predecessor;
        }

        private void InOrderRecursive(Node node)
        {
            if (node == null)
                return;

            InOrderRecursive(node.left);
            Console.WriteLine(node.data);
            InOrderRecursive(node.right);
        }

        private Node AddNode(Node root, int input)
        {
            if (root == null)
            {
                root = new Node() {data = input};
                return root;
            }

            var val = input.CompareTo(root.data);

            if (val < 0)
                root.left = AddNode(root.left, input);
            else if (val > 0)
                root.right = AddNode(root.right, input);

            return root;
        }

        private void InOrderRecursiveMoreInfo(Node node)
        {
            if (node == null)
                return;

            InOrderRecursiveMoreInfo(node.left);
            if (node.successor != null)
                Console.WriteLine("{0} : {1} ", node.data, node.successor.data);
            InOrderRecursiveMoreInfo(node.right);
        }

        private void Predecessor(Node curr, ref Node prev)
        {
            if ( curr == null)
                return;

            Predecessor(curr.left, ref prev);
            curr.predecessor = prev;
            prev = curr;
            Predecessor(curr.right, ref prev);
        }

        // use post order traversal to set succesor
        private void SetSuccessorPostOrder(Node curr, ref Node prev)
        {
            if (curr == null)
                return;

            SetSuccessorPostOrder(curr.right, ref prev);
            curr.successor = prev;
            prev = curr;
            SetSuccessorPostOrder(curr.left, ref prev);
        }

        private void SetSuccessorInOrder(Node curr, Node prev)
        {
            if ( curr == null)
                return;

            SetSuccessorInOrder(curr.left, curr);

            if (curr.right != null)
            {
                Node tmp = curr.right;
                while (tmp.left != null)
                {
                    tmp = tmp.left;
                }
                curr.successor = tmp;
            }
            else
            {
                curr.successor = prev;
            }

            SetSuccessorInOrder(curr.right, prev);
        }

        public void Test()
        {
            var root = AddNode(null, 30);
            AddNode(root, 20);
            AddNode(root, 25);
            AddNode(root, 22);
            AddNode(root, 40);
            AddNode(root, 50);
            AddNode(root, 45);

            InOrderRecursive(root);

            // use inorder traversal
            Node prev = null;
            //Predecessor(root, ref prev);

            prev = null;
            //SetSuccessorPostOrder(root, ref prev);

            prev = null;
            SetSuccessorInOrder(root, prev);

            Console.WriteLine("\n More information: ");
            InOrderRecursiveMoreInfo(root);

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
