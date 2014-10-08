using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.SPOJ
{
    public class GSS3
    {
        private class Node
        {
            public int res, pre, suf, sum;
            public void Merge(Node l, Node r)
            {
                sum = l.sum + r.sum;
                pre = Math.Max(l.pre, l.sum+r.pre);
                suf = Math.Max(r.suf, r.sum+l.suf);
                
                res = Math.Max( Math.Max(l.res, r.res), l.suf+r.pre );
            }
            public void Update(int x)
            {
                res = pre = suf = sum = x;
            }
        }
        
        private static void Update(Node[] tree, int pos, int value)
        {
            tree[pos].Update(value);

            int parent = pos >> 1;

            while (parent > 0)
            {
                tree[parent].Merge( tree[2*parent], tree[2*parent+1]);
                parent = parent >> 1;
            }
        }

        private static Node RangeQuery(int node, Node[] tree, int b, int e, int x, int y)
        {
            if (x <= b && y >= e)
                return tree[node];

            Node l = null;
            Node r = null;
            int mid = b + (e-b) / 2;
            
            if (x <= mid)
                l = RangeQuery(2*node  , tree,     b, mid, x, y);
            if (y > mid)
                r = RangeQuery(2*node+1, tree, mid+1, e, x, y);

            tree[node].Merge(tree[2*node], tree[2*node+1]);

            if (l == null)
                return r;
            if (r == null)
                return l;

            Node tmp = new Node();
            tmp.Merge(l, r);

            return tmp;
        }

        private static void Initialize(int node, short[] A, Node[] tree, int b, int e)
        {
            if (tree[node] == null)
                tree[node] = new Node();

            if (b == e)
                tree[node].Update(A[b]);
            else
            {
                int mid = b + (e - b) / 2;
                Initialize(2*node  , A, tree,     b, mid);
                Initialize(2*node+1, A, tree, mid+1,   e);

                tree[node].Merge( tree[2*node], tree[2*node+1]);
            }            
        }

        public static void Test()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            String S = Console.ReadLine();
            String[] nums = S.Split(' ');

            Int16[] A = new Int16[N];
            for (int i = 0; i < nums.Length; i++)
                A[i] = Convert.ToInt16(nums[i]);

            int height = (int) Math.Ceiling( Math.Log(N,2) );
            int size   = ((int)Math.Pow(2, height) << 1);
            
            Node[] tree = new Node[size];
            Initialize(1, A, tree, 0, N - 1);

            int M = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < M; i++)
            {
                S = Console.ReadLine();
                nums = S.Split(' ');

                byte operation = Convert.ToByte(nums[0]);
                int x = Convert.ToInt32(nums[1]);
                int y = Convert.ToInt32(nums[2]);

                if (operation == 1)
                {
                    Node result = RangeQuery(1, tree, 0, N - 1, x - 1, y - 1);
                    Console.WriteLine(result.res);
                }
                else
                {
                    int pos = (x - 1) + (1 << height);
                    Update(tree, pos, y);
                }
            }

            Console.ReadLine();
        }
    }
}
