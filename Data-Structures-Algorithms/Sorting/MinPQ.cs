using System;
using System.Collections.Generic;

// pay special attention to the resizing logic
// to display elements of PQ in sorted order, PQ needs to be sorted which destroys the PQ ordering
    // look at the SortedOrder() method below


namespace Algorithms.Problems.Sorting
{
    public class MinPQ<T> where T : IComparable
    {
        private T[] pq;     // maintain elements in MinPQ from 1 to N
        private int N;      // no of elements in the MinPQ

        public MinPQ() : this(1){}

        public MinPQ(int capacity)
        {
            N = 0;              // relaise that its a PQ, while inserting elemeents , N is updated
            pq = new T[1];
        }

        // create a min PQ with the given set of keys
        public MinPQ(T[] keys)
        {
            N = keys.Length;        // N = lenas elements are inserted to start with
            pq = new T[N+1];

            for (int i = 1; i <= N; i++)
                pq[i] = keys[i-1];

            for (int i = N/2; i >=1; i--)
                Sink(i, N);
        }

        public bool IsEmpty()
        {
            return N == 0;
        }

        public T Min()
        {
            if ( IsEmpty()) throw new Exception("No elements in the MinPQ");
            return pq[0];
        }

        public int Size()
        {
            return N;
        }

        public void Insert(T input)
        {
            if ( N >= pq.Length-1)
                Resize(2*pq.Length);

            pq[++N] = input;
            Swim(N);
        }

        public T DelMin()
        {
            if (IsEmpty()) throw new Exception("No elements in the MinPQ");

            T min = pq[1];
            exch(1,N--);
            Sink(1, N);
            pq[N + 1] = default(T);
            if ( N > 1 && N < (pq.Length-1) / 4)
                Resize(pq.Length/2);
            return min;
        }
        
        public IEnumerable<T> Display()
        {
            for (int i = 1; i <= Size(); i++)
            {
                yield return pq[i];
            }
        }

        // pq will no longer contain Min heap but will have sorted elements
        public void SortedOrder()
        {
            while (N > 1)
            {
                exch(1, N--);
                Sink(1, N);
            }

            for (int i = N; i >= 1 ; i--)
            {
                Console.WriteLine(pq[i]);
            }
        }

        #region private members
        private void Resize(int len)
        {
            var tmp = new T[len];
            for (int i = 1; i <= N; i++)
                tmp[i] = pq[i];
            pq = tmp;
        }

        private void Sink(int k, int N)
        {
            while (2*k <= N)
            {
                int j = 2*k;

                if (j < N && less(j+1, j)) j++;

                if (less(k, j)) break;

                exch(k, j);
                k = j;
            }
        }

        private void Swim(int k)
        {
            while (k>1 && less(k, k/2))
            {
                exch(k, k/2);
                k = k >> 1;
            }
        }

        private bool less(int i, int j)
        {
            return pq[i].CompareTo(pq[j]) < 0;
        }

        private void exch(int i, int j)
        {
            T tmp = pq[i];
            pq[i] = pq[j];
            pq[j] = tmp;
        }
        #endregion

        public void Test()
        {
            var arr = new int[] { 23, 5, 5, 91, 10, 9 };
            var minpq = new MinPQ<int>(arr);

            minpq.Insert(84);
            minpq.Insert(14);
            minpq.Insert(12);
            minpq.Insert(1);

            foreach (var s in minpq.Display())
                Console.WriteLine(s);

            // in order to display all elements in sorted order
            minpq.SortedOrder();

            Console.ReadLine();
        }
    }
}
