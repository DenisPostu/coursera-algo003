using System;
using System.Collections.Generic;
using Coursera.Implementations.TheoryProblems.Problem3OfJanuary28th;
using NUnit.Framework;

namespace Coursera.Implementations.Tests.TheoryProblems
{
    [TestFixture]
    public class Problem3OfJanuary28ThTests
    {
        private IndexFinder m_target;
        
        [SetUp]
        public void SetUp()
        {
            m_target = new IndexFinder();
        }

        [Test]
        public void ContainsMatch_SizeOneArrayWith0_ReturnsTrue()
        {
            var data = new List<int>{0};
            var result = m_target.ContainsMatch(data);

            Assert.IsTrue(result);
        }

        [Test]
        public void ContainsMatch_SizeOneArrayWithNegative_ReturnsFalse()
        {
            var data = new List<int>{-1};
            var result = m_target.ContainsMatch(data);

            Assert.IsFalse(result);
        }

        [Test]
        public void ContainsMatch_SizeOneArrayWithPositive_ReturnsFalse()
        {
            var data = new List<int>{3};
            var result = m_target.ContainsMatch(data);

            Assert.IsFalse(result);
        }
        
        [Test]
        public void ContainsMatch_SizeTwoArrayWithNoMatch_ReturnsFalse()
        {
            var data = new List<int>{3,4};
            var result = m_target.ContainsMatch(data);

            Assert.IsFalse(result);
        }

        [Test]
        public void ContainsMatch_SizeTwoArrayWithFirstMatch_ReturnsTrue()
        {
            var data = new List<int>{0, 4};
            var result = m_target.ContainsMatch(data);

            Assert.IsTrue(result);
        }

        [Test]
        public void ContainsMatch_SizeTwoArrayWithSecondMatch_ReturnsTrue()
        {
            var data = new List<int>{-7, 1};
            var result = m_target.ContainsMatch(data);

            Assert.IsTrue(result);
        }

        [TestCaseSource("GetTestData")]
        public void ContainsMatch_ParametrizedTest(Tuple<List<int>, bool> testData)
        {
            var result = m_target.ContainsMatch(testData.Item1);
            var expected = testData.Item2;

            Assert.AreEqual(expected, result);
        }

        private IEnumerable<Tuple<List<int>, bool>> GetTestData()
        {
            yield return new Tuple<List<int>, bool>(new List<int> {0, 5, 6, 7, 8, 9}, true);
            yield return new Tuple<List<int>, bool>(new List<int> {-1, 1, 2, 3, 4, 5, 6}, true);
            yield return new Tuple<List<int>, bool>(new List<int> {-1, 0, 2, 3, 4, 5, 6, 7, 10}, true);
            yield return new Tuple<List<int>, bool>(new List<int> {-10, -2, -1, 3}, true);
            yield return new Tuple<List<int>, bool>(new List<int> {-10, -2, -1, 0, 1, 2, 6}, true);
            yield return new Tuple<List<int>, bool>(new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}, true);
            yield return new Tuple<List<int>, bool>(new List<int> {-9, -8, -7, -6, 4, 6}, true);
            yield return new Tuple<List<int>, bool>(new List<int> {-9, 0, 1}, false);
            yield return new Tuple<List<int>, bool>(new List<int> {-9, 0, 1, 2}, false);
            yield return new Tuple<List<int>, bool>(new List<int> {-9, 0, 1, 5}, false);
            yield return new Tuple<List<int>, bool>(new List<int> {-9, 0, 1, 6}, false);
            yield return new Tuple<List<int>, bool>(new List<int> {-9, 0, 1, 5, 6}, false);
            yield return new Tuple<List<int>, bool>(new List<int> {1, 2, 3, 4, 5, 6}, false);
            yield return new Tuple<List<int>, bool>(new List<int> {1, 3, 5, 7, 9}, false);
            yield return new Tuple<List<int>, bool>(new List<int> {10, 12, 13, 19}, false);
        }

    }
}
