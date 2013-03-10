using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
        }
        
        public void Push(T item)
        {
            m_items.Add(item);
            SiftUp(m_items.Count - 1);
        }

        private void SiftUp(int i)
        {
        }

        public T Pop()
        {
            if (!m_items.Any()) throw new IndexOutOfRangeException();

            var item = m_items.First();
            m_items[0] = m_items.Last();
            m_items.RemoveAt(m_items.Count - 1);

            PushDown(0);

            return item;
        }

        private void PushDown(int i)
        {
            
        }

        protected abstract bool HasHigherPriority(T a, T b);

        protected void Swap(ref T a, ref T b)
        {
            T aux = a;
            a = b;
            b = aux;
        }
    }
}
