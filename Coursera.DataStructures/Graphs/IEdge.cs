using System;

namespace Coursera.DataStructures.Graphs
{
    public interface IEdge<T>
        where T : IComparable
    {
        T A { get; set; }
        T B { get; set; }
    }
}