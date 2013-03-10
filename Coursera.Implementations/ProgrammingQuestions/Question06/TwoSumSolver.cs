using System.Collections.Generic;
using System.Linq;

namespace Coursera.Implementations.ProgrammingQuestions.Question06
{
    internal class TwoSumSolver
    {
        private readonly HashSet<int> m_numbersHashSet;

        public TwoSumSolver(HashSet<int> numbersHashSet)
        {
            m_numbersHashSet = numbersHashSet;
        }

        public bool ContainsPairWithSum(int t)
        {
            return m_numbersHashSet.Any(x => m_numbersHashSet.Contains(t - x));
        }

        public bool ContainsDistinctPairWithSum(int t)
        {
            return m_numbersHashSet.Any(x => x != t - x && m_numbersHashSet.Contains(t - x));
        }
    }
}