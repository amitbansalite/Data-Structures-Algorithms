using System.Collections.Generic;
using Algorithms.Problems.LinkedList;

// adjacency list representation
// list <node> types.. 

namespace Algorithms.Problems.Graphs
{
    public class DiGraph
    {
        private int V;                  // number of nodes in the graph
        private Bag<int>[] adj;         // array of V items where each is a Bag<T>

        public DiGraph(int n)
        {
            V = n;
            adj = new Bag<int>[V];    

            for (int i = 0; i < V; i++)
            {
                adj[i] = new Bag<int>();
            }
        }

        public void AddEdge(int from, int to)
        {
            adj[from].AddAtStart(to);
        }

        public int Vertices()
        {
            return V;
        }

        public IEnumerable<int> Adj(int v)
        {
            return adj[v].Enumerate();
        }

        public int Edges()
        {
            int count = 0;

            for (int i = 0; i < V; i++)
            {
                count += adj[i].size();
            }
            return count;
        }

        public void Test()
        {
            //DiGraph G = new DiGraph(10);


        }
    }
}
