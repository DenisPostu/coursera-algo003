using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coursera.DataStructures.Heaps;
using Coursera.DataStructures.Tests.Conventions;
using Xunit;
using Xunit.Extensions;

namespace Coursera.DataStructures.Tests.Heaps
{
    public class MinHeapTests
    {
        [Theory, HeapTestConvention]
        public void PushItemPopsSameItem(MinHeap<int> heap)
        {
            var expected = 5;
            heap.Push(expected);
            var actual = heap.Pop();

            Assert.Equal(expected, actual);
        }
    }
}
