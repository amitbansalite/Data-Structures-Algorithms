using System;
using System.Collections.Generic;

namespace Algorithms.Problems.BST
{
    public class InOrderTraversalIterative
    {
        private class Node
        {
            public Node left;
            public Node right;
            public int data;
        }

        private Node AddNode(Node root, int input)
        {
            if (root == null)
            {
                root = new Node() { data = input };
                return root;
            }

            var val = input.CompareTo(root.data);

            if (val < 0)
                root.left = AddNode(root.left, input);
            else if (val > 0)
                root.right = AddNode(root.right, input);

            return root;
        }

        private void LevelOrderTraversal(Node root)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while ( queue.Count > 0 )
            {
                var node = queue.Dequeue();
                Console.WriteLine(node.data);
                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }
        }

        private void InOrderRecursive(Node node)
        {
            if (node == null)
                return;

            InOrderRecursive(node.left);
            Console.WriteLine(node.data);
            InOrderRecursive(node.right);
        }

        /* Function to traverse binary tree without recursion and
           without stack */
        void InOrderIterative(Node root)
        {
            if (root == null)
                return;
         
            Node pre = null;
            Node current = root;
            
            while (current != null)
            {
                if (current.left == null)
                {
                    Console.WriteLine(current.data);
                    current = current.right;
                }
                else
                {
                    /* Find the inorder predecessor of current */
                    pre = current.left;
                    while (pre.right != null && pre.right != current)
                        pre = pre.right;

                    /* Make current as right child of its inorder predecessor */
                    if (pre.right == null)
                    {
                        pre.right = current;
                        current = current.left;
                    }

                   // MAGIC OF RESTORING the Tree happens here: 
                    /* Revert the changes made in if part to restore the original
                      tree i.e., fix the right child of predecssor */
                    else
                    {
                        pre.right = null;
                        Console.WriteLine(current.data);
                        current = current.right;
                    } /* End of if condition pre.right == NULL */
                } /* End of if condition current.left == NULL*/
            } /* End of while */
        }

        private int Depth(Node node)
        {
            if (node == null)
                return 0;

            return 1 + Math.Max(Depth(node.left), Depth(node.right));
        }

        private int DepthUsingBfs(Node root)
        {
            int depth = 0;
	        int currentLevel = 0, nextLevel = 0;
	        Queue<Node> queue = new Queue<Node>();
	        queue.Enqueue(root);
	        currentLevel++;
	
	        while( queue.Count > 0)
	        {
		        var node = queue.Dequeue();
		        currentLevel--;
		        Console.WriteLine(node.data);
		
		        if (node.left != null)
		        {
                    queue.Enqueue(node.left);
			        nextLevel++;
		        }
		
		        if (node.right != null)
		        {
                    queue.Enqueue(node.right);
			        nextLevel++;
		        }
		        if (currentLevel == 0)
		        {
			        currentLevel = nextLevel;
			        nextLevel = 0;
		            depth++;
		        }
	        }
            return depth;
        }

        private int DepthIterative(Node node)
        {
            if (node == null)
                return 0;

            int globalCount = 0;
            int count = 1;
            Node curr = node, pre = null;

            while (curr != null)
            {

                if (curr.left == null)
                {
                    count++;
                    curr = curr.right;
                }
                else
                {
                    int countToDecrement = 1;
                    pre = curr.left;
                    while (pre.right != null && pre.right != curr)
                    {
                        countToDecrement++;
                        pre = pre.right;
                    }
                    if (pre.right == null)
                    {
                        count++;
                        pre.right = curr;
                        curr = curr.left;
                    }
                    else
                    {
                        pre.right = null;
                        count--;

                        if (globalCount < count)
                            globalCount = count;

                        count = count - countToDecrement;
                        curr = curr.right;
                        count++;
                    }
                }
            }
            return globalCount;
        }

        public void Test()
        {
            var root = AddNode(null, 20);
            AddNode(root, 10);
            AddNode(root, 5);
            AddNode(root, 15);
            AddNode(root, 12);
            AddNode(root, 14);
            AddNode(root, 17);
            AddNode(root, 18);
            AddNode(root, 19);
            AddNode(root, 30);
            AddNode(root, 25);
            AddNode(root, 40);

            //InOrderRecursive(root);
            //InOrderIterative(root);
            
            LevelOrderTraversal(root);

            var result1 = Depth(root);
            var result2 = DepthUsingBfs(root);
            Console.WriteLine(" The max depth of the tree is {0} : {1}", result1, result2);
            
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
