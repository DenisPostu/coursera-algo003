using System;

namespace Coursera.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public class QuestionRunner : Attribute
    {
        public QuestionRunner(string questionName, string questionUrl)
        {
            QuestionName = questionName;
            QuestionUrl = questionUrl;
        }

        public string QuestionName { get; set; }
        public string QuestionUrl { get; set; }
    }
}