
// TST hasexplicit characters with only 3 links per node
    //TRIE has implicit charactersin terms of R links but many of which are empty


using System;
using System.Collections.Generic;

namespace Algorithms.Problems.TRIES
{
    public class TST<T>
    {
        private Node<T> root; 

        public class Node<T>
        {
            public T data;
            public char c;
            public Node<T> left;
            public Node<T> mid;
            public Node<T> right;
        }

        public Node<T> put(string key, T value)
        {
            root =  put(root, key, value, 0);
            return root;
        }

        private Node<T> put(Node<T> x, string key, T value, int d)
        {
            if (x == null)
                x = new Node<T>{c = key[d]};
            
            char c = key[d];

            if (c < x.c)
                x.left = put(x.left, key, value, d);
            else if (c > x.c)
                x.right = put(x.right, key, value, d);
            else if (d < key.Length - 1)
                x.mid = put(x.mid, key, value, d + 1);
            else
                x.data = value;

            return x;
        }

        public T get(String key)
        {
            Node<T> x = get(root, key, 0);
            if (x != null)
                return x.data;

            return default(T);
        }

        private Node<T> get(Node<T> x, String key, int d)
        {
            if (x == null)
                return null;

            char c = key[d];

            if (c < x.c)
                return get(x.left, key, d);
            else if (c > x.c)
                return get(x.right, key, d);
            else if (d < key.Length - 1)
                return get(x.mid, key, d + 1);
            else
                return x;
        }

        public IEnumerable<String> keys()
        {
            var q = new Queue<String>();
            keys(root, q, "");
            return q;
        }

        private void keys(Node<T> x, Queue<String> q, String key)
        {
            if ( x == null) return;
            
            keys(x.left, q, key);

            keys(x.mid, q, key + x.c);

            keys(x.right, q, key);
            
            if (x.data != null)
                q.Enqueue(key + x.c);
        }


        public void Test()
        {
            var tst = new TST<String>();
            tst.put("sea", "3");
            tst.put("shell", "4");
            tst.put("shells", "5");
            tst.put("amit", "4");
            tst.put("ass", "3");
            tst.put("able", "4");
            tst.put("asshole", "7");
            tst.put("ankit", "6");
            tst.put("shellsort", "9");
            tst.put("sas", "3");
            tst.put("sell", "4");

            var result = tst.get("amit");

            foreach (var text in tst.keys())
            {
                Console.WriteLine(text);
            }
            
            Console.WriteLine("Press enter key to exit");
            Console.ReadLine();
        }
    }
}
