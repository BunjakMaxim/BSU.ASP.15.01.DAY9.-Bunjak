using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLibrary
{
    public class Tree<T>
        where T : IComparable<T>
    {
        TreeNode<T> node;
        Func<T, T, int> comparer;

        public Tree()
        {
            comparer = (T a, T b) => { return a.CompareTo(b); };
        }
        public Tree(T value)
            : this()
        {
            this.node = new TreeNode<T>(value);
        }

        public Tree(IComparer<T> comp)
        {
            comparer = (T a, T b) => { return comp.Compare(a, b); };
        }

        public void AddNode(T value)
        {
            if (node == null)
                node = new TreeNode<T>(value);
            else
                AddNode(value, this.node);
        }

        public IEnumerable<T> PreorderIterator()
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            TreeNode<T> node = this.node;

            while (node != null || stack.Count > 0)
            {
                yield return node.value;

                if (node.right != null)
                    stack.Push(node.right);
                node = node.left;
                if (node == null && stack.Count > 0)
                    node = stack.Pop();
            }
        }

        public IEnumerable<T> InorderIterator()
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            TreeNode<T> node = this.node;

            while (node != null || stack.Count > 0)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                if (node == null && stack.Count > 0)
                {
                    node = stack.Pop();
                    yield return node.value;
                    node = node.right;
                }
            }
        }

        public IEnumerable<T> PostorderIterator()
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            TreeNode<T> node = this.node, parent = null;

            while (node != null || stack.Count > 0)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                else
                {
                    node = stack.Peek();
                    if (node.right != null && node.right != parent)
                        node = node.right;
                    else
                    {
                        yield return node.value;

                        parent = node;
                        node = null;
                        stack.Pop();
                    }
                }
            }
        }

        private void AddNode(T value, TreeNode<T> node)
        {
            if (comparer(node.value, value) > 0)
            {
                if (node.left == null)
                    node.left = new TreeNode<T>(value);
                else
                    AddNode(value, node.left);
            }
            else
            {
                if (node.right == null)
                    node.right = new TreeNode<T>(value);
                else
                    AddNode(value, node.right);
            }
        }
    }
}
