using System;
using System.Collections.Generic;
using System.Linq;

namespace Coursera.DataStructures.Heaps
{
    public class MaxHeap<T> : AbstractHeap<T> where T: IComparable
    {
        public MaxHeap() : base(Enumerable.Empty<T>())
        {
        }

        public MaxHeap(IEnumerable<T> items) : base(items)
        {
        }
        
        protected override bool HasHigherPriority(T a, T b)
        {
            return a.CompareTo(b) >= 0;
        }
    }
}