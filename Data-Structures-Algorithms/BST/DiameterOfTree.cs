using System;

//There are three cases to consider when trying to find the longest path between two nodes in a binary tree (diameter):
    //1. The longest path passes through the root,
    //2. The longest path is entirely contained in the left sub-tree,
    //3. The longest path is entirely contained in the right sub-tree.

namespace Algorithms.Problems.BST
{
    public class DiameterOfTree
    {
        private class Node
        {
            public Node left;
            public Node right;
            public int data;
        }

        private int getDiameter(Node root)
        {
            if (root == null)
                return 0;

            int rootDiameter = getHeight(root.left) + getHeight(root.right) + 1;
            int leftDiameter = getDiameter(root.left);
            int rightDiameter = getDiameter(root.right);

            return Math.Max(rootDiameter, Math.Max(leftDiameter, rightDiameter));
        }

        private int getHeight(Node root)
        {
            if (root == null)
                return 0;

            return Math.Max(getHeight(root.left), getHeight(root.right)) + 1;
        }

        // Above recursive solution is not good at all. Height gets called for each node and recursion is touching lower nodes many times
        private int GetDiameterNonRecursive(Node root)
        {
            if ( root == null)
            return 0;



            return 0;
        }
    }
}
