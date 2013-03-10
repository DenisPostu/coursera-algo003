using System.Diagnostics;
using Coursera.DataStructures.Heaps;

namespace Coursera.Implementations.ProgrammingQuestions.Question06
{
    internal class MedianMaintainer
    {
        private MinHeap<int> m_largeValuesMinHeap;
        private MaxHeap<int> m_smallValuesMaxHeap;

        public MedianMaintainer()
        {
            m_largeValuesMinHeap = new MinHeap<int>();
            m_smallValuesMaxHeap = new MaxHeap<int>();
        }

        public void Push(int number)
        {
            if (m_smallValuesMaxHeap.Size == 0)
            {
                m_smallValuesMaxHeap.Push(number);
                return;
            }
   
            if (m_smallValuesMaxHeap.Peak() > number)
            {
                m_smallValuesMaxHeap.Push(number);
            }
            else
            {
                m_largeValuesMinHeap.Push(number);
            }

            if (m_smallValuesMaxHeap.Size - m_largeValuesMinHeap.Size > 1)
            {
                m_largeValuesMinHeap.Push(m_smallValuesMaxHeap.Pop());
                return;
            }

            if (m_largeValuesMinHeap.Size > m_smallValuesMaxHeap.Size)
            {
                m_smallValuesMaxHeap.Push(m_largeValuesMinHeap.Pop());
                return;
            }

            Debug.Assert(m_smallValuesMaxHeap.Size - m_largeValuesMinHeap.Size <= 1);
        }

        public int GetMedian()
        {
            return m_smallValuesMaxHeap.Peak();
        }
    }
}