using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Coursera.Core;
using Coursera.Core.Attributes;

namespace Coursera.Implementations.ProgrammingQuestions.Question01
{
    [QuestionRunner("Programming Question-1", "https://class.coursera.org/algo-003/quiz/index?quiz_type=homework")]
    internal class Runner : IQuestionRunner
    {
        public Task Run()
        {
            var numbers = new List<int>();
            
            using (var reader = new StreamReader("ProgrammingQuestions/Question01/input.txt"))
            {
                var line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                    numbers.Add(int.Parse(line));
            }

            var count = new InversionCounter().Count(numbers);
            
            Console.WriteLine("Number of inversions: {0}", count);

            return Task.FromResult(true);
        }
    }
}
