using System;

// http://www.topcoder.com/tc?d1=tutorials&d2=lowestCommonAncestor&module=Static#Range_Minimum_Query_(RMQ)
// http://www.geeksforgeeks.org/segment-tree-set-1-sum-of-given-range/

/*
 * For solving the RMQ problem we can also use segment trees. 
 * A segment tree is a heap-like data structure that can be used for making UPDATE & QUERY operations upon array intervals in logarithmical time. 
 * 
 * 
 * We define the segment tree for the interval [i, j] in the following recursive manner:
 *  a) the first node will hold the information for the interval [i, j]
 *  b) if i<j the left and right son will hold the information for the intervals [i, (i+j)/2] and [(i+j)/2+1, j]
 *  Notice that the height of a segment tree for an interval with N elements is [logN] + 1. 
 **********  TREE SIZE =  [1, 2 * 2^[logX]] *******  ALWAYS  where X = Math.Celing (Math.Log(N,2));
 *  
*/

/*
 * Using segment trees we get an <O(N), O(logN)> algorithm. 
 * Segment trees are very powerful, not only because they can be used for RMQ. 
 * They are a very flexible data structure, can solve even the dynamic version of RMQ problem, 
 * and have numerous applications in range searching problems. 
*/

namespace Algorithms.Problems.DifferentTrees
{
    public class SegmentTree
    {
        private class Node
        {
            public int value;
            public void Merge(Node a, Node b)
            {
                value = Math.Min(a.value, b.value);
            }
        }

        private void Initialize(int node, int b, int e, Node[] tree, int[] A)
        {
            if (tree[node] == null)
                tree[node] = new Node();

            if (b == e)
                tree[node].value = A[b];
            else
            {
                int mid = b + (e - b)/2;
                Initialize(2 * node     , b     , mid, tree, A);
                Initialize(2 * node + 1 , mid+1 , e  , tree, A);

                tree[node].Merge( tree[2*node], tree[2*node+1]);
            }
        }

        private int RMQ(int node, int b, int e, Node[] tree, int i, int j)
        {
            // if range of node is completely outside i and j
            if (b >= j || e <= i)
                return -1;
            
            // if range of node is within i and j
            if (i <= b && e <= j)
                return tree[node].value;

            int mid = b + (e - b) / 2;
            int p1 = RMQ(2 * node   , b     , mid , tree, i, j);
            int p2 = RMQ(2 * node+2 , mid+1 , e   , tree, i, j);

            if (p1 == -1)
                return p2;
            if (p2 == -1)
                return p1;

            if (p1 <= p2)
                return p1;
            return p2;
        }

        private Node RMQ_Efficient(int root, int b, int e, Node[] tree, int i, int j)
        {
            if (i <= b && e <= j)
                return tree[root];

            Node l = null;
            Node r = null;
            int mid = b + (e - b) / 2;

            if (i <= mid)
                l = RMQ_Efficient(2 * root    ,       b, mid, tree, i, j);
            if (e > mid)
                r = RMQ_Efficient(2 * root + 1, mid + 1,    e, tree, i, j);

            tree[root].Merge( tree[2*root], tree[2*root+1] );

            if (l == null)
                return r;
            if (r == null)
                return l;

            Node tmp = new Node();
            tmp.Merge(l, r);
            return tmp;
        }

        // a lot simpler way to update the leaf node and then propate the change till the root like a HEAP
        private void Update(int node, int value, Node[] M, int[] A)
        {
            M[node].value = value;

            int parent = node >> 1;
            while (parent > 0)
            {
                M[parent].Merge(M[2 * parent], M[2 * parent + 1]);
                parent = parent >> 1;
            }
        }


        // complexity is 2 * (height)
        private void Update_Recursive(int node, int b, int e, Node[] tree, int pos, int value)
        {
            if (pos < b || pos > e)
                return;

            if (b == e && b == pos)
            {
                tree[node].value = value;
                return;
            }

            int mid = b + (e - b)/2;

            if ( pos <= mid )
                Update_Recursive(2 * node, b, mid, tree, pos, value);
            else
                Update_Recursive(2 * node + 1, mid + 1, e, tree, pos, value);

            tree[node].Merge(tree[2 * node], tree[2 * node + 1]);
        }

        public void Test()
        {
            var A = new int[] {1, 2, -3, 4};
            var N = A.Length;

            int height = (int) Math.Ceiling(Math.Log(N, 2));
            int size   = ( (int)Math.Pow(2,height) << 1 );
            
            var tree = new Node[size];
            Initialize(1, 0, N-1, tree, A);

            int i = 1;
            int j = 3;

            var result = RMQ_Efficient(1, 0, N - 1, tree, i, j);
            Console.WriteLine("Minimum element from {0} to {1} is {2}", i, j, result.value);

            int pos = 1;
            int newValue = 10;
            A[pos] = newValue;            
            
            //Update_Recursive(1, 0, N - 1, M, pos, newValue);
            
            // the position in M[] at which value needs to chnage : pos + (1 << height)
            pos += 1 << height; 
            Update(pos, newValue, tree, A);

            result = RMQ_Efficient(1, 0, N - 1, tree, i, j);
            Console.WriteLine("Minimum element from {0} to {1} is {2}", i, j, result.value);

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
