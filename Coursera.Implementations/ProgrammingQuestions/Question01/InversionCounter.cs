using System;
using System.Collections.Generic;
using System.Linq;

namespace Coursera.Implementations.ProgrammingQuestions.Question01
{
    public class InversionCounter
    {
        public long Count(List<int> numbers)
        {
            var inversions = CountInner(numbers);

            return inversions.Item2;
        }

        private Tuple<List<int>, long> CountInner(List<int> numbers)
        {
            var n = numbers.Count;
            if (n == 1) return new Tuple<List<int>, long>(numbers, 0);

            var l = numbers.Take(n/2).ToList();
            var r = numbers.Skip(n/2).ToList();
            var li = CountInner(l);
            var ri = CountInner(r);
            var si = CountSplit(li.Item1, ri.Item1);

            return new Tuple<List<int>, long>(si.Item1, li.Item2 + ri.Item2 + si.Item2);
        }

        private Tuple<List<int>, long> CountSplit(List<int> a, List<int> b)
        {
            int n = a.Count + b.Count;
            int ai = 0, bi = 0;
            long ri = 0;
            var rl = new List<int>();
            for (var i = 0; i < n; ++i)
            {
                if (ai == a.Count)
                {
                    while (bi < b.Count) rl.Add(b[bi++]);
                    break;
                }
                if (bi == b.Count)
                {
                    while (ai < a.Count) rl.Add(a[ai++]);
                    break;
                }
                if (a[ai] < b[bi])
                {
                    rl.Add(a[ai++]);
                }
                else
                {
                    rl.Add(b[bi++]);
                    ri += a.Count - ai;
                }
            }

            return new Tuple<List<int>, long>(rl, ri);
        }
    }
}