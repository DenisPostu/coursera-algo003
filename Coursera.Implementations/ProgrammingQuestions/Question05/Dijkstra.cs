using System;
using System.Collections.Generic;
using System.Linq;
using Coursera.DataStructures.Graphs;

namespace Coursera.Implementations.ProgrammingQuestions.Question05
{
    internal class Dijkstra
    {
        private Dictionary<int, List<WeightedUndirectedEdge>> m_edgesFrom; 
        private Dictionary<int, List<WeightedUndirectedEdge>> m_edgesTo;
        private int[] m_distances;
        private HashSet<int> m_explorableFront;
        private HashSet<int> m_visited; 

        public int[] ComputeFor(List<WeightedUndirectedEdge> edgesList, int n, int positiveInfinity)
        {
            m_edgesFrom = Enumerable.Range(1, n).ToDictionary(i => i, i => edgesList.Where(e => e.A == i).ToList());
            m_edgesTo = Enumerable.Range(1, n).ToDictionary(i => i, i => edgesList.Where(e => e.B == i).ToList());
            m_distances = Enumerable.Range(0, n + 1).Select(i => positiveInfinity).ToArray();

            m_distances[1] = 0;
            m_visited = new HashSet<int> {1};
            m_explorableFront = new HashSet<int>();
            foreach (var edge in m_edgesFrom[1])
            {    
                m_distances[edge.B] = Math.Min(m_distances[1] + edge.Weight, m_distances[edge.B]);
                m_explorableFront.Add(edge.B);
            }
            foreach (var edge in m_edgesTo[1])
            {
                m_distances[edge.A] = Math.Min(m_distances[1] + edge.Weight, m_distances[edge.A]);
                m_explorableFront.Add(edge.A);
            }

            while (m_explorableFront.Any())
            {
                var vertex = m_explorableFront.OrderBy(v => m_distances[v]).First();

                foreach (var edge in m_edgesFrom[vertex])
                {
                    m_distances[edge.B] = Math.Min(m_distances[vertex] + edge.Weight, m_distances[edge.B]);
                    if (!m_visited.Contains(edge.B)) m_explorableFront.Add(edge.B);
                    
                }
                foreach (var edge in m_edgesTo[vertex])
                {
                    m_distances[edge.A] = Math.Min(m_distances[vertex] + edge.Weight, m_distances[edge.A]);
                    if (!m_visited.Contains(edge.A)) m_explorableFront.Add(edge.A);
                }

                m_explorableFront.Remove(vertex);
                m_visited.Add(vertex);
            }

            return m_distances;
        }
    }
}