using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTest
{
    class CompareBook : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Title.Length - y.Title.Length;
        }
    }
}
