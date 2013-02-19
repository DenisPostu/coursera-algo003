using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var readingInputFileTask = "Reading input data";
            var adjacencyList = new List<Edge>();
            var numbers = new int[2];

            Benchmarker.Start(readingInputFileTask);
            using (var reader = new StreamReader("ProgrammingQuestions/Question04/input.txt"))
            {
                var line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    numbers = line.Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    adjacencyList.Add(new Edge(numbers[0], numbers[1]));
                }
            }
            Benchmarker.Stop(readingInputFileTask);
            Console.WriteLine("{1} took {0}ms", Benchmarker.EllapsedMilliseconds(readingInputFileTask), readingInputFileTask);

            return Task.FromResult(true);
        }
    }
}
