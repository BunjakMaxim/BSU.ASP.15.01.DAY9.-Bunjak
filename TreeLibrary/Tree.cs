using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLibrary
{
    public class Tree<T>
    {
        TreeNode<T> root;
        Func<T, T, int> comparer;

        # region Constructors
        public Tree()
        {
            comparer = (a, b) => (a as IComparable<T>).CompareTo(b);
        }

        public Tree(T value)
            : this()
        {
            this.root = new TreeNode<T>(value);
        }

        public Tree(IComparer<T> comp)
        {
            comparer = (T a, T b) => comp.Compare(a, b);
        }

        public Tree(T value, IComparer<T> comp) : this(comp)
        {
            this.root = new TreeNode<T>(value);
        }

        public Tree(IEnumerable<T> collection) : this()
        {
            foreach(var t in collection)
            {
                AddNode(t);
            }
        }

        public Tree(IEnumerable<T> collection, IComparer<T> comp): this(comp)
        {
            foreach (var t in collection)
            {
                AddNode(t);
            }
        }
        # endregion

        public void AddNode(T value)
        {
            if (root == null)
                root = new TreeNode<T>(value);
            else
                AddNode(value, this.root);
        }

        # region Iterators
        public IEnumerable<T> PreorderIterator()
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            TreeNode<T> node = this.root;

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
            TreeNode<T> node = this.root;

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
            TreeNode<T> node = this.root, parent = null;

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
        # endregion

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
