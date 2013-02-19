using System;
using System.Collections.Generic;
using System.Linq;

namespace Coursera.Implementations.ProgrammingQuestions.Question04
{
    public class GraphComponentsConnector
    {
        private Random m_random;
        private List<Edge> m_edges; 

    }

    internal class Edge
    {

        public override int GetHashCode()
        {
            unchecked
            {
                return (A * 397) ^ B;
            }
        }

        public Edge(int a, int b)
        {
            A = Math.Min(a, b);
            B = Math.Max(a, b);
        }

        public int A { get; set; }
        public int B { get; set; }

        protected bool Equals(Edge other)
        {
            return A == other.A && B == other.B;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Edge)obj);
        }
    }   
}