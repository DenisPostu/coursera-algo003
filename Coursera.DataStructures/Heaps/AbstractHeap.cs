using System;
using System.Collections.Generic;
using System.Linq;

namespace Coursera.DataStructures.Heaps
{
    public abstract class AbstractHeap<T> : IHeap<T> where T : IComparable
    {
        private List<T> m_items = new List<T>();

        protected AbstractHeap(IEnumerable<T> items)
        {
            m_items = items.ToList();
            Heapify();
        }

        private void Heapify()
        {
            for (var i = Size - 1; i >= 0; --i)
                SiftUp(i);
        }

        public int Size { get { return m_items.Count; } }

        public void Push(T item)
        {
            m_items.Add(item);
            SiftUp(m_items.Count - 1);
        }

        public T Pop()
        {
            if (!m_items.Any()) throw new IndexOutOfRangeException();

            Swap(0, Size - 1);
            
            var item = m_items.Last();
            m_items.RemoveAt(Size - 1);

            PushDown(0);

            return item;
        }

        public T Peak()
        {
            return m_items[0];
        }

        private void SiftUp(int i)
        {
            if (i == 0) return;

            if (HasHigherPriority(m_items[i], m_items[(i - 1) / 2]))
            {
                Swap(i, (i - 1) / 2);
                SiftUp((i - 1) / 2);
            }
        }

        private void PushDown(int i)
        {
            var swapIndex = i;
            if (i * 2 + 1 < Size && HasHigherPriority(m_items[i * 2 + 1], m_items[i]))
                swapIndex = i * 2 + 1;
            if (i * 2 + 2 < Size && HasHigherPriority(m_items[i * 2 + 2], m_items[swapIndex]))
                swapIndex = i * 2 + 2;

            if (i == swapIndex) return;
            Swap(i, swapIndex);
            PushDown(swapIndex);
        }

        protected abstract bool HasHigherPriority(T a, T b);

        protected void Swap(int a, int b)
        {
            T aux = m_items[a];
            m_items[a] = m_items[b];
            m_items[b] = aux;
        }
    }
}
