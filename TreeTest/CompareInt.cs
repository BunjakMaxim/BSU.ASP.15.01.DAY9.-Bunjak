using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTest
{
    class CompareInt : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return CountSymbols(x) - CountSymbols(y);
        }

        private int CountSymbols(int x)
        {
            int count = 0;
            int n = 10;

            while (x / n >= 1)
            {
                n *= 10;
                count++;
            }
            return count;
        }
    }
}
