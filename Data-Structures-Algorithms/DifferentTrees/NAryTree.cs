using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.DifferentTrees
{
    public class NAryTree<T>
    {        
        private GenericNAryTreeNode<T> root;

        public GenericNAryTreeNode<T> Root
        {
            get { return this.root; }
            set { this.root = value;}
        }

        public int GetNumberOfNodes()
        {
            int count = 0;

            if (root != null)
            {                
                count++;
                count = GetNumberOfNodes(root);
            }
            return count;
        }

        private int GetNumberOfNodes(GenericNAryTreeNode<T> node)
        {
            var count = node.GetNumberOfChildren();

            foreach(var child in node.Children)
            {
                count += GetNumberOfNodes(child);
            }
            return count;
        }

        public bool Exists(GenericNAryTreeNode<T> node)
        {
            return Find(node, root) != null; 
        }

        private GenericNAryTreeNode<T> Find(GenericNAryTreeNode<T> nodeToFind, GenericNAryTreeNode<T> currentNode)
        {
            GenericNAryTreeNode<T> returnNode = null;
            if (currentNode != null)
            {
                if (currentNode.Equals(nodeToFind))
                    returnNode = currentNode;
                else if (currentNode.HasChildren())
                {
                    int i=0;
                    while (returnNode == null && i < currentNode.GetNumberOfChildren())
                    {
                        returnNode = Find(nodeToFind, currentNode.Children[i]);
                        i++;
                    }
                }
            }       
            return null;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        //TODO : write more methods for print pre/post/inorder traversal
    }

    public  class GenericNAryTreeNode<T>
    {
        private T data;
        private List<GenericNAryTreeNode<T>> children;

        public GenericNAryTreeNode()
        {
            children = new List<GenericNAryTreeNode<T>>();
        }

        public GenericNAryTreeNode(T data)
            : this()
        {
            this.data = data;
        }

        public GenericNAryTreeNode(T data, List<GenericNAryTreeNode<T>> children)
            : this(data)
        {
            this.children = children;
        }

        public T Data
        {
            get{ return data;}
            set { data = value; }
        }
        
        public List<GenericNAryTreeNode<T>> Children
        {
            get { return this.children; }
            set { this.children = value; }
        }

        public void AddChild(GenericNAryTreeNode<T> child)
        {
            children.Add(child);
        }

        public void RemoveChildren()
        {
            children = new List<GenericNAryTreeNode<T>>();
        }
                
        public int GetNumberOfChildren()
        {
            return children.Count;
        }

        public bool HasChildren()
        {
            return children.Any();
        }
        
        public bool Equals(GenericNAryTreeNode<T> other)
        {
            return this.data.Equals(other.data);
        }

        public int HashCode()
        {
            return this.data.GetHashCode();
        }
    }
}
