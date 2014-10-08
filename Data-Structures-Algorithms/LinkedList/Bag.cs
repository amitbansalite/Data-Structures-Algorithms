using System.Collections.Generic;

// implementing a linkedlist generic class


namespace Algorithms.Problems.LinkedList
{
    public class Bag<T>
    {
        private int N;          // number of elements in the list
        private Node<T> first;  //  begining of list

        private class Node<T>
        {
            internal T data;
            internal Node<T> next;
        }

        public Bag()
        {
            N = 0;
            first = null;
        }

        public bool IsEmpty()
        {
            return first == null;
        }

        public int size()
        {
            return N;
        }

        public void AddAtStart(T data)
        {
            Node<T> oldFirst = first;
            first = new Node<T>();
            first.data = data;
            first.next = oldFirst;
            N++;
        }

        public IEnumerable<T> Enumerate()
        {
            Node<T> tmp = first;

            while (tmp != null)
            {
                yield return tmp.data;
                tmp = tmp.next;
            }
        }

    }
}

