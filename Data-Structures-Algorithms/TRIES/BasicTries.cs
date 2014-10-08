using System;
using System.Collections.Generic;

//very very important DS
    
// methods implemented
    // 1. create a Tire
    // 2. search for a key
    // 3. all keys in sorted order
    // 4. keys that match a given prefix
    // 5. longest prefix that matches a given key

namespace Algorithms.Problems.TRIES
{
    public class BasicTries<T>
    {
        private const int R = 256;
        private Node<T> root = new Node<T>(); 

        public class Node<T>
        {
            public T data;
            public Node<T>[] next = new Node<T>[R];
        }

        public Node<T> put(String key, T value)
        {
            root = put(root, value, key, 0);
            return root;
        }

        private Node<T> put(Node<T> x, T value, String key, int d)
        {
            if (x == null)
                x = new Node<T>();
            
            if (d == key.Length)
            {
                x.data = value;
                return x;
            }
            char c = key[d];
            x.next[c] = put(x.next[c], value, key, d + 1);
            return x;
        }

        public bool contains(String key)
        {
            return get(key) != null;
        }
        

        //  examines only L characters for search hit andeven less for search miss ,but wastes space in terms of null links
        public T get(String key)
        {
            Node<T> x = get(root, key, 0);
            if (x == null)
                return default(T);

            return x.data;
        }

        private Node<T> get(Node<T> x, String key, int d)
        {
            if (x == null) return null;

            if (d == key.Length)
                return x;
            char c = key[d];
            return get(x.next[c], key, d + 1);
        }

        public IEnumerable<String> keys()
        {
            var q = new Queue<String>();
            collect(root, q, "");
            return q;
        }

        // similar to DFS
        private void collect(Node<T> x, Queue<String> q , String key)
        {
            if (x == null) return;

            if ( x.data != null )
                q.Enqueue(key);
            
            for (char c = (char) 0; c < R; c++)
            {
                collect(x.next[c], q, key + c);
            }
        }

        public String LongestPrefix(String key)
        {
            var len = LongestPrefix(root, key, 0, 0);
            return key.Substring(0, len);
        }

        private int LongestPrefix(Node<T> x, String key, int len, int d)
        {
            if (x == null) return len;

            if (x.data != null) len = d;

            if (d == key.Length) return len;
            
            char c = key[d];
            return LongestPrefix(x.next[c], key, len, d + 1);
        }

        private IEnumerable<String> keysWithPrefix(String prefix)
        {
            var q = new Queue<String>();
            var x = get(root, prefix, 0);
            collect(x, q, prefix);
            return q;
        }

        public void Test()
        {
            var trie = new BasicTries<String>();
            trie.put("sea", "3");
            trie.put("shell", "4");
            trie.put("shells", "5");
            trie.put("amit", "4");
            trie.put("ass", "3");
            trie.put("able", "4");
            trie.put("asshole", "7");
            trie.put("ankit", "6");
            trie.put("shellsort", "9");
            trie.put("sas", "3");
            trie.put("sell", "4");

            var result = trie.get("amit");
            
            foreach (var key in trie.keys())
            {
                Console.WriteLine(key);
            }

            Console.WriteLine("\n\n Keys with prefix :");
            foreach (var key in trie.keysWithPrefix("sh"))
            {
                Console.WriteLine(key);
            }

            var match = "shells";
            result = trie.LongestPrefix(match);

            Console.WriteLine("\n\n Longest  prefix is {0} for given key {1}", result, match);

            Console.WriteLine("\n\n Press enter key to exit");
            Console.ReadLine();
        }
    }
}
