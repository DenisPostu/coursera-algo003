namespace Coursera.DataStructures.Graphs
{
    public class DirectedEdge
    {
        public override int GetHashCode()
        {
            unchecked
            {
                return (A * 397) ^ B;
            }
        }

        public DirectedEdge(int a, int b)
        {
            A = a;
            B = b;
        }

        public int A { get; set; }
        public int B { get; set; }

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