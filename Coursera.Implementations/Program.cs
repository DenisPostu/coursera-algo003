using System;
using System.Threading.Tasks;
using Coursera.Implementations.ProgrammingQuestions.Question04;

namespace Coursera.Implementations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
            Console.ReadKey();
        }

        static async void Run()
        {
            Console.WriteLine("Starting task..");
            var task = Task.Run(() => new Runner().Run());
            Console.WriteLine("Awaiting task..");
            await task;
            Console.WriteLine("Done");            
        }
    }
}
