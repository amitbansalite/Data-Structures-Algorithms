using System;
using System.Collections.Generic;

// http://www.spoj.com/problems/BRCKTS/

namespace Algorithms.Problems.SPOJ
{
    public class Brackets
    {
        public static void Test()
        {
            for (int k = 1; k <= 10; k++)
            {
                var results = new List<bool>();
                Int16 N = Convert.ToInt16(Console.ReadLine());
                String S = Console.ReadLine();

                var root = new Node();
                root = Initialize(root, S, 0, S.Length - 1);

                Int16 M = Convert.ToInt16(Console.ReadLine());
                for (int i = 0; i < M; i++)
                {
                    Int16 operation = Convert.ToInt16(Console.ReadLine());

                    if (operation == 0)
                    {
                        if (root.close_needed == 0 && root.open_needed == 0)
                            results.Add(true);
                        else
                            results.Add(false);
                    }
                    else
                    {
                        Update(root, S, 0, S.Length - 1, operation - 1);
                    }
                }

                Console.WriteLine("Test {0}:", k);
                for (int m = 0; m < results.Count; m++)
                    Console.WriteLine(results[m] ? "YES" : "NO");
            }

            Console.ReadLine();
        }

        private static void Update(Node root, String S, int b, int e, int index)
        {
            if (index < b || index > e)
                return;

            if (b == e)
            {
                if (root.isCloseBracket)
                {
                    root.isCloseBracket = false;
                    root.close_needed = 1;
                    root.open_needed = 0;
                }
                else
                {
                    root.isCloseBracket = true;
                    root.open_needed = 1;
                    root.close_needed = 0;
                }

                return;
            }

            int mid = b + (e - b)/2;

            if (index <= mid)
                Update(root.left, S, b, mid, index);
            else
                Update(root.right, S, mid + 1, e, index);

            Logic(root);
        }

        private static Node Initialize(Node root, String S, int b, int e)
        {
            if (root == null)
                root = new Node();

            if (b == e)
            {
                root.isLeafNode = true;
                if (S[b] == ')')
                {
                    root.isCloseBracket = true;
                    root.open_needed = 1;
                }
                else
                {
                    root.isCloseBracket = false;
                    root.close_needed = 1;
                }
                return root;
            }

            int mid = b + (e - b)/2;
            root.left = Initialize(root.left, S, b, mid);
            root.right = Initialize(root.right, S, mid + 1, e);

            Logic(root);

            return root;
        }

        private static void Logic(Node root)
        {
            if (root.left.isLeafNode && root.right.isLeafNode)
            {
                if (root.left.isCloseBracket && root.right.isCloseBracket)
                {
                    root.open_needed = 2;
                    root.close_needed = 0;
                }
                else if (!root.left.isCloseBracket && !root.right.isCloseBracket)
                {
                    root.open_needed = 0;
                    root.close_needed = 2;
                }
                else if (root.left.isCloseBracket && !root.right.isCloseBracket)
                {
                    root.open_needed = 1;
                    root.close_needed = 1;
                }
                else
                {
                    root.open_needed = 0;
                    root.close_needed = 0;
                }
            }
            else
            {
                Int16 tmp = (short) (root.right.open_needed - root.left.close_needed);

                if (tmp > 0)
                {
                    root.open_needed = (short) (root.left.open_needed + tmp);
                    root.close_needed = root.right.close_needed;
                }
                else
                {
                    root.open_needed = root.left.open_needed;
                    root.close_needed = (short) (root.right.close_needed + Math.Abs(tmp));
                }
            }
        }

        private class Node
        {
            public Int16 close_needed;
            public Int16 open_needed;

            public bool isLeafNode;
            public bool isCloseBracket;

            public Node left, right;
        }
    }
}
