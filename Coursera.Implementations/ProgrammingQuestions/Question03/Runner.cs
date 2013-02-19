using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Coursera.Core;
using Coursera.Core.Attributes;

namespace Coursera.Implementations.ProgrammingQuestions.Question03
{
    [QuestionRunner("Programming Question-3", "https://class.coursera.org/algo-003/quiz/attempt?quiz_id=52")]
    internal class Runner : IQuestionRunner
    {
        public Task Run()
        {
            var adjacencyList = Enumerable.Range(1, 5)
                .ToDictionary(x => x, _ => new List<int>());

            using (var reader = new StreamReader("ProgrammingQuestions/Question03/input.txt"))
            {
                var line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    var numbers = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                    adjacencyList[numbers.First()] = numbers.Skip(1).ToList();
                }
            }

            var t = Enumerable
                .Range(0, 100)
                .AsParallel()
                .Select(n => new GraphContractor().MinCutEdgesCount(adjacencyList))
                .ToList();

            Console.WriteLine(string.Format("Min cut size is {0}", t.Min()));

            return Task.FromResult(true);
        }
    }
}
