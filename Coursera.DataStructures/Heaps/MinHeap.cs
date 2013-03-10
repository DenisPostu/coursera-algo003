using System;
using System.Collections.Generic;
using System.Linq;

namespace Coursera.DataStructures.Heaps
{
    public class MinHeap<T> : AbstractHeap<T> where T: IComparable
    {
        public MinHeap() : base(Enumerable.Empty<T>())
        {
        }

        public MinHeap(IEnumerable<T> items) : base(items)
        {
        }
        
        protected override bool HasHigherPriority(T a, T b)
        {
            return a.CompareTo(b) == -1;
        }
    }
}