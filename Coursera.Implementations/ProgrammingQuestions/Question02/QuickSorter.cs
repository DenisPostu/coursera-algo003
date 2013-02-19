using System;
using System.Collections.Generic;
using System.Linq;

namespace Coursera.Implementations.ProgrammingQuestions.Question02
{
    public class QuickSorter
    {
        public long ComparisonsCount = 0;
        private Func<int[], int, int, int> m_pivotIndexSelector;

        public void SetPivotIndexSelector(Func<int[], int, int, int> pivotIndexSelector)
        {
            m_pivotIndexSelector = pivotIndexSelector;
        }

        public void Sort(int[] array)
        {
            ComparisonsCount = 0;
            Sort(array, 0, array.Length - 1);
        }

        private void Sort(int[] array, int l, int r)
        {
            if (l >= r) return;

            ComparisonsCount += r - l;

            var pivot = m_pivotIndexSelector(array, l, r);
            var newPivotPosition = Partition(array, l, r, pivot);

            Sort(array, newPivotPosition + 1, r);
            Sort(array, l, newPivotPosition - 1);
        }

        private int Partition(int[] array, int l, int r, int pivot)
        {
            int i = l;

            Swap(array, l, pivot);
            for (var j = l + 1; j <= r; ++j)
            {
                if (array[j] < array[l])
                {
                    Swap(array, ++i, j);
                }
            }
            Swap(array, l, i);

            return i;
        }

        private void Swap(int[] array, int i, int j)
        {
            var aux = array[i];
            array[i] = array[j];
            array[j] = aux;
        }
    }



}