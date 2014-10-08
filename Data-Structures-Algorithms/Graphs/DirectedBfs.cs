using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.Graphs
{
    public class DirectedBfs
    {
        private bool[] visited;

        public DirectedBfs(DiGraph G, int source)
        {
            BFS(G, source);
        }

        private void BFS(DiGraph G, int source)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(source);

            while (q.Count > 0)
            {
                var cur = q.Dequeue();

                foreach (int i in G.Adj(cur))
                {
                    q.Enqueue(i);
                }
            }
        }
    }
}
