using System;
using System.Collections.Generic;
using Algorithms.Problems.Graphs;

// worst case : O(MN)
    // N : length of text
    // M : length of regexp

// Applications : a) crossword puzzle solving b) syntax highlighter (notepad++) c) perl 
    
namespace Algorithms.Problems.Strings
{
    class RegexMatch
    {
        private char[] re;
	    private DiGraph G;
	    private int M;

        public RegexMatch(string regexp)
	    {
		    M = regexp.Length;
		    re = regexp.ToCharArray();
		    G = BuildTransitionGraph();		
	    }

        // logic : create a graph with edges as
            // for every special character in the regexp we can have some edges. Currently only (,),*,|  are handled
        // can be extended to handle more special characters
	    private DiGraph BuildTransitionGraph()
	    {
		    DiGraph G = new DiGraph(M+1);
		    Stack<int> ops = new Stack<int>();
		
		    for(int i =0; i<M; i++)
		    {
			    int lp = i;
			
			    if (re[i] == '(' || re[i] == '|')
				    ops.Push(i);			
			    else if (re[i] == ')')
			    {
				    int or = ops.Pop();
				    if (re[or] == '|')
				    {
					    lp = ops.Pop();
					    G.AddEdge(lp, or+1);
					    G.AddEdge(or, i);
				    }
				    else
					    lp = or;
			    }
			
			    if (i < M-1 && re[i+1] == '*')
			    {
				    G.AddEdge(lp, i+1);
				    G.AddEdge(i+1, lp);
			    }
		
			    if (re[i] == '(' || re[i] == '*' || re[i] == ')')
			    {
				    G.AddEdge(i, i+1);
			    }
		    }
		    return G;
	    }

	    // checks if the given text matches the regexp
	    // if it does return true (its possible to reach state M in the NFA) 

        // Logic:
            // 1) create a list of states that are reachable from 0 : ps
            // 2) create a list of states that are reachable after processing text.CharAt(i) : matches
            // 3) update ps with list of states that are reachable from matches
            // 4) if ever PS has a state that is the last state, then the given text matches the regexp
	    public bool Matches(string text)
	    {
		    List<int> ps = new List<int>();
		    DirectedDFS dfs = new DirectedDFS(G, 0);
		
		    // states reachable from start by e-transitions
            for (int i = 0; i < G.Vertices(); i++)
		    {
			    if (dfs.marked(i))
				    ps.Add(i);
		    }
		
		    for(int i=0; i<text.Length; i++)
		    {
			    List<int> match = new List<int>();
			
			    // states reachable after scanning past txt.charAt(i)
			    foreach(int v in ps)
			    {
					    if (v==M) return true;
					    if ( re[v] == text[i] || re[v] == '.')          // since '.' indicates any character, it is considered a match
						    match.Add(v+1);
			    }
			
			    dfs = new DirectedDFS(G, match);
			    ps = new List<int>();
                for (int v = 0; v < G.Vertices(); v++)
			    {
				    if ( dfs.marked(v))
					    ps.Add(v);
			    }		
		    }
		
		    foreach (int v in ps)
			    if (v == M) return true;
		
		    return false;
	    }

        public void Test()
        {
            var text = "AAAAAAD";
            var regex = @"((A*B|AC)D)";

            var obj = new RegexMatch(regex);
            var result = obj.Matches(text);

            if (result)
                Console.WriteLine(" Given text {0} matches the regex pattern {1}", text, regex);
            else
                Console.WriteLine(" Given text {0} does NOT matche the regex pattern {1}", text, regex);

            Console.WriteLine(" Press enter to exit.");
            Console.ReadLine();
        }
    }
}
