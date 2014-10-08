using System.Collections.Generic;

// implementing DFS algorithm

//Determine single-source or multiple-source reachability in a digraph using DFS.

// Runs in O(E+V) time.

namespace Algorithms.Problems.Graphs
{
    public class DirectedDFS
    {
        private bool[] visited;     // visitd[v] = true if v is reachable from source
     
        public DirectedDFS(DiGraph G, int source)
        {
            visited = new bool[G.Vertices()];
            Dfs(G, source);
        }

        public DirectedDFS(DiGraph G, IEnumerable<int> Sources)
        {
            visited = new bool[G.Vertices()];
            foreach (var source in Sources)
            {
                Dfs(G, source);
            }
        }

        private void Dfs(DiGraph G, int s)
        {
            visited[s] = true;

            foreach (var v in G.Adj(s))
            {
                if ( !visited[v])
                    Dfs(G, v);
            }
        }

        public bool marked(int v)
        {
            return visited[v];
        }
    }
}
