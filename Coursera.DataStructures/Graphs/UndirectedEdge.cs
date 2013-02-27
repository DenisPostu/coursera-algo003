using System;

namespace Coursera.DataStructures.Graphs
{
    public class UndirectedEdge : IEdge<int>
    {
        public int A { get; set; }
        public int B { get; set; }

        public UndirectedEdge(int a, int b)
        {
            A = Math.Min(a, b);
            B = Math.Max(a, b);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (A * 397) ^ B;
            }
        }

        protected bool Equals(DirectedEdge other)
        {
            return A == other.A && B == other.B;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DirectedEdge)obj);
        }
    }
}