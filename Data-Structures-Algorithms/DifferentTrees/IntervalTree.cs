using System;
using System.Collections.Generic;

namespace Algorithms.Problems.DifferentTrees
{
    public class IntervalTree
    {
        private struct Interval
        {
            public int low, high;
        }

        private class Node
        {
            public int max;
            public Interval i;
            public Node left, right;
        }

        private Interval? SearchInterval(Node root, Interval i)
        {
            if (root == null)
                return null;

            if (!(root.i.low >= i.high || root.i.high <= i.low))
                return root.i;

            if (root.left != null && i.low <= root.left.max)
                return SearchInterval(root.left, i);

            return SearchInterval(root.right, i);
        }

        private void PrintIntervalTree(Node root)
        {
            if (root == null)
                return;

            PrintIntervalTree(root.left);
            Console.WriteLine("{0} : {1} with max : {2}", root.i.low, root.i.high, root.max);
            PrintIntervalTree(root.right);
        }

        private Node AddInterval(Node root, Interval i)
        {
            if (root == null)
            {
                root = new Node { max = i.high, i = new Interval() { low = i.low, high = i.high } };
                return root;
            }

            if (root.i.low > i.low)
                root.left = AddInterval(root.left, i);
            else if (root.i.low < i.low)
                root.right = AddInterval(root.right, i);

            if (root.left != null && root.left.max > root.max)
                root.max = root.left.max;
            if (root.right != null && root.right.max > root.max)
                root.max = root.right.max;
            
            return root;
        }

        private Node DeleteInterval(Node root, Interval i)
        {
            return null;
        }

        public void Test()
        {
            var intervals = new List<Interval>();
            intervals.Add(new Interval() { low = 15, high = 20 });
            intervals.Add(new Interval() { low = 10, high = 30 });
            intervals.Add(new Interval() { low = 17, high = 19 });
            intervals.Add(new Interval() { low = 5 , high = 20 });
            intervals.Add(new Interval() { low = 12, high = 15 });
            intervals.Add(new Interval() { low = 30, high = 40 });

            Node root = null;
            foreach (Interval i in intervals)
            {
                root = AddInterval(root, i);
            }

            PrintIntervalTree(root);

            var searchInterval = new Interval() {low = 6, high = 7};
            var result = SearchInterval(root, searchInterval);

            Console.WriteLine(" Searching for interval [{0},{1}]", searchInterval.low, searchInterval.high);
            if (result.HasValue)
                Console.WriteLine(" Overlaps with [{0},{1}]", result.Value.low, result.Value.high);
            else
                Console.WriteLine(" has NO overlaps in the Interval search tree.");

            Console.WriteLine("\n\n Press enter to exit");
            Console.ReadLine();
        }
    }
}
