using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Coursera.Core;
using Coursera.Core.Attributes;
using Coursera.Core.Benchmark;

namespace Coursera.Implementations.ProgrammingQuestions.Question04
{
    [QuestionRunner("Programming Question-4", "https://class.coursera.org/algo-003/quiz/attempt?quiz_id=57")]
    internal class Runner : IQuestionRunner
    {
        public Task Run()
        {
            var t = new Thread(InternalRun, 200 << 20);
            t.Start();
            t.Join();

            return Task.FromResult(true);
        }

        private void InternalRun()
        {
            var readingInputFileTask = "Reading input data";
            var computingSccsTask = "Computing SCCs";
            var adjacencyList = new List<Edge>();
            var numbers = new int[2];
            var connector = new GraphComponentsConnector();
            var min = int.MaxValue;
            var max = int.MinValue;

            Benchmarker.Start(readingInputFileTask);
            using (var reader = new StreamReader("ProgrammingQuestions/Question04/input.txt"))
            {
                var line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    numbers = line.Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    adjacencyList.Add(new Edge(numbers[0], numbers[1]));
                    min = Math.Min(min, Math.Min(numbers[0], numbers[1]));
                    max = Math.Max(max, Math.Max(numbers[0], numbers[1]));
                }
            }
            Benchmarker.Stop(readingInputFileTask);
            Console.WriteLine("{1} took {0}ms", Benchmarker.EllapsedMilliseconds(readingInputFileTask), readingInputFileTask);

            Benchmarker.Start(computingSccsTask);
            var components = connector.FindConnectedComponents(min, max, adjacencyList).ToList();
            Benchmarker.Stop(computingSccsTask);

            Console.WriteLine("{1} took {0}ms", Benchmarker.EllapsedMilliseconds(computingSccsTask), computingSccsTask);
            Console.WriteLine("Sizes of the largest components are: {0}", string.Join(",", components.Select(l => l.Count).OrderByDescending(l => l).Take(5)));
            Console.WriteLine("Total size of components is: {0}", components.Select(c => c.Count).Sum());

        }
    }
}
