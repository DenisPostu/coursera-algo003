using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Coursera.Core;
using Coursera.Core.Attributes;
using Coursera.Core.Benchmark;
using Coursera.DataStructures.Graphs;

namespace Coursera.Implementations.ProgrammingQuestions.Question06
{
    [QuestionRunner("Programming Question-6", "https://class.coursera.org/algo-003/quiz/attempt?quiz_id=76")]
    internal class Runner : IQuestionRunner
    {
        public async Task Run()
        {
            //await Task.Run(() => InternalRunForTwoSum());
            await Task.Run(() => InternalRunForMedianMaintenance());
        }

        private void InternalRunForTwoSum()
        {
            var readingInputFileTask = "Reading input data for first assignment";
            var computingPathsTask = "Computing sums";
            var numbersHashSet = new HashSet<int>();
            
            Benchmarker.Start(readingInputFileTask);
            using (var reader = new StreamReader("ProgrammingQuestions/Question06/input-a.txt"))
            {
                var line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    numbersHashSet.Add(int.Parse(line));
                }
            }
            Benchmarker.Stop(readingInputFileTask);
            Console.WriteLine("{1} took {0}ms", Benchmarker.EllapsedMilliseconds(readingInputFileTask), readingInputFileTask);

            Benchmarker.Start(computingPathsTask);
            var twoSumSolver = new TwoSumSolver(numbersHashSet);
            var numberOfValues = Enumerable.Range(2500, 1501).Count(twoSumSolver.ContainsDistinctPairWithSum);
            Benchmarker.Stop(computingPathsTask);

            Console.WriteLine("{1} took {0}ms", Benchmarker.EllapsedMilliseconds(computingPathsTask), computingPathsTask);
            Console.WriteLine("Number of values in [2500,4000] that have 2-SUM is {0}", numberOfValues);
        }

        private void InternalRunForMedianMaintenance()
        {
            var readingInputFileTask = "Reading input data for second assignment";
            var computingPathsTask = "Computing medians sum";
            var inputStream = new Queue<int>();

            Benchmarker.Start(readingInputFileTask);
            using (var reader = new StreamReader("ProgrammingQuestions/Question06/input-b.txt"))
            {
                var line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    inputStream.Enqueue(int.Parse(line));
                }
            }
            Benchmarker.Stop(readingInputFileTask);
            Console.WriteLine("{1} took {0}ms", Benchmarker.EllapsedMilliseconds(readingInputFileTask), readingInputFileTask);

            Benchmarker.Start(computingPathsTask);
            var medianSum = 0l;
            var medianMaintainer = new MedianMaintainer();
            while (inputStream.Any())
            {
                medianMaintainer.Push(inputStream.Dequeue());
                medianSum = (medianSum + medianMaintainer.GetMedian()) % 10000;

            }
            Benchmarker.Stop(computingPathsTask);

            Console.WriteLine("{1} took {0}ms", Benchmarker.EllapsedMilliseconds(computingPathsTask), computingPathsTask);
            Console.WriteLine("Median sum modulo 10000 is {0}", medianSum);
        }
    }
}
