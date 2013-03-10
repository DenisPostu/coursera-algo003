using System;

namespace Coursera.DataStructures.Heaps
{
    public interface IHeap<T> where T : IComparable
    {
        //IHeap<T> Heapify(T[] items);
        int Size { get; }

        void Push(T item);
        T Pop();
        T Peak();

    }
}
