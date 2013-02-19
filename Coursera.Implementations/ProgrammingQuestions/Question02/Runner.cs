using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Coursera.Core;
using Coursera.Core.Attributes;

namespace Coursera.Implementations.ProgrammingQuestions.Question02
{
    [QuestionRunner("Programming Question-2", "https://class.coursera.org/algo-003/quiz/attempt?quiz_id=33")]
    internal class Runner : IQuestionRunner
    {
        public Task Run()
        {
            var numbers = new List<int>();
            
            using (var reader = new StreamReader("ProgrammingQuestions/Question02/input.txt"))
            {
                var line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                    numbers.Add(int.Parse(line));
            }

            var quickSorter = new QuickSorter();

            var a = numbers.ToArray();
            quickSorter.SetPivotIndexSelector((_, l, r) => l);
            quickSorter.Sort(a);
            Console.WriteLine("Number of comparisons in case #{0}: {1}", 1, quickSorter.ComparisonsCount);

            var b = numbers.ToArray();
            quickSorter.SetPivotIndexSelector((_, l, r) => r);
            quickSorter.Sort(b);
            Console.WriteLine("Number of comparisons in case #{0}: {1}", 2, quickSorter.ComparisonsCount);

            var c = numbers.ToArray();
            quickSorter.SetPivotIndexSelector(ChooseMedianOfThree);
            quickSorter.Sort(c);
            Console.WriteLine("Number of comparisons in case #{0}: {1}", 3, quickSorter.ComparisonsCount);

            return Task.FromResult(true);
        }

        private int ChooseMedianOfThree(int[] a, int l, int r)
        {
            var mid = (l + (r - l) / 2);
            return new List<int> {l, r, mid}
                .Select(i => new {i, v = a[i]})
                .OrderBy(x => x.v)
                .ElementAt(1).i;
        }
    }
}
