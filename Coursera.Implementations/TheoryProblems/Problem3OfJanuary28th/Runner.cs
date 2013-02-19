using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Coursera.Core;
using Coursera.Core.Attributes;

namespace Coursera.Implementations.TheoryProblems.Problem3OfJanuary28th
{
    [ProblemRunner("Theory Problem 3 of January 28h", "https://class.coursera.org/algo-003/wiki/view?page=TheoryProblems")]
    internal class Runner : IProblemRunner
    {
        public Task Run()
        {
            var numbers = new List<int>{-1, 2, 3};
            var result = new IndexFinder().ContainsMatch(numbers);
            
            Console.WriteLine("Match found: {0}", result);

            return Task.FromResult(true);
        }
    }

    public class IndexFinder
    {
        public bool ContainsMatch(List<int> a)
        {
            return ContainsMatch(a, 0, a.Count - 1);
        }

        private bool ContainsMatch(List<int> a, int l, int r)
        {
            if (l > r) return false;
            if (l == r) return l == a[l];

            var mid = l + (r - l)/2;

            if (a[mid] == mid)
                return true;
            if (a[mid] < mid) 
                return ContainsMatch(a, mid + 1, r);
            return ContainsMatch(a, l, mid - 1);
        }
    }
}
