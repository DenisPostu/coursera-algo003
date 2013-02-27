using System;

namespace Coursera.DataStructures.Graphs
{
    public interface IWeightedEdge<T, TWeight> : IEdge<T> 
        where T : IComparable 
        where TWeight : IComparable
    {
        TWeight Weight { get; set; }
    }
}