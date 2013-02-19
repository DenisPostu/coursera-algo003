using System;

namespace Coursera.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public class ProblemRunner : Attribute
    {
        public ProblemRunner(string problemName, string problemUrl)
        {
            ProblemName = problemName;
            ProblemUrl = problemUrl;
        }

        public string ProblemName { get; set; }
        public string ProblemUrl { get; set; }
    }
}