using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Coursera.Core;
using Coursera.Core.Attributes;
using Coursera.Core.Benchmark;
using Coursera.DataStructures.Graphs;

namespace Coursera.Implementations.ProgrammingQuestions.Question05
{
    [QuestionRunner("Programming Question-5", "https://class.coursera.org/algo-003/quiz/attempt?quiz_id=96")]
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
            var computingPathsTask = "Computing paths";
            var numbers = new string[]{};
            var edgesList = new List<WeightedUndirectedEdge>();
            int vertex = -1;

            Benchmarker.Start(readingInputFileTask);
            using (var reader = new StreamReader("ProgrammingQuestions/Question05/input.txt"))
            {
                var line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    numbers = line.Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    vertex = int.Parse(numbers.First());
                    
                    edgesList.AddRange(
                        numbers
                            .Skip(1)
                            .Select(s => s.Split(new[] { ',' }))
                            .Select(a => new WeightedUndirectedEdge(vertex, int.Parse(a[0]), int.Parse(a[1])))
                            .ToList());
                }
            }
            Benchmarker.Stop(readingInputFileTask);
            Console.WriteLine("{1} took {0}ms", Benchmarker.EllapsedMilliseconds(readingInputFileTask), readingInputFileTask);

            Benchmarker.Start(computingPathsTask);
            // work goes here
            Benchmarker.Stop(computingPathsTask);

            Console.WriteLine("{1} took {0}ms", Benchmarker.EllapsedMilliseconds(computingPathsTask), computingPathsTask);
            // output goes here
        }
    }
}
