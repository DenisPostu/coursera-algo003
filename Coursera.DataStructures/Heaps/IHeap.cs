using System;

namespace Coursera.DataStructures.Heaps
{
    public interface IHeap<T> where T : IComparable
    {
        //IHeap<T> Heapify(T[] items);
        
        void Push(T item);
        T Pop();
    }
}
