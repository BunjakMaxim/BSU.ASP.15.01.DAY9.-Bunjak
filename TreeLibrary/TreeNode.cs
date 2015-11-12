using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLibrary
{
    class TreeNode<T>
    {
        public T value;
        public TreeNode<T> left;
        public TreeNode<T> right;

        public TreeNode(T value)
        {
            this.value = value;
        }
    }
}
