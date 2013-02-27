namespace Coursera.DataStructures.Graphs
{
    public class WeightedUndirectedEdge : UndirectedEdge, IWeightedEdge<int, int>
    {
        public int Weight { get; set; }

        public WeightedUndirectedEdge(int a, int b, int w) : base(a, b)
        {
            Weight = w;
        }

        protected bool Equals(WeightedUndirectedEdge other)
        {
            return base.Equals(other) && Weight == other.Weight;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ Weight;
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}