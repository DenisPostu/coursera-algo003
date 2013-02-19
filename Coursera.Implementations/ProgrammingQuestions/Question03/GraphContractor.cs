using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coursera.Implementations.ProgrammingQuestions.Question03
{
    public class GraphContractor
    {
        private Random m_random;

        private List<Vertex> m_vertices;
        private List<Edge> m_edges; 

        private Dictionary<int, List<int>> m_originalGraph;

        public int MinCutEdgesCount(Dictionary<int, List<int>> graph)
        {
            Setup(graph);

            Edge edge;
            Vertex vertexOne;
            Vertex vertexTwo;

            while (m_vertices.Count > 2)
            {
                edge = PickRandomEdge();
                vertexOne = m_vertices.FirstOrDefault(v => v.Vertices.Contains(edge.A));
                vertexTwo = m_vertices.FirstOrDefault(v => v.Vertices.Contains(edge.B));

                ContractVertices(vertexOne, vertexTwo);
            }

            var result = CalculateCutValue();
            return result;
        }

        private int CalculateCutValue()
        {
            var a = m_vertices[0];
            var b = m_vertices[1];

            return m_originalGraph
                .SelectMany(g => g.Value.Select(v => new Edge(g.Key, v)))
                .Distinct()
                .Count(e =>
                    (a.Vertices.Contains(e.A) && b.Vertices.Contains(e.B)) ||
                    (a.Vertices.Contains(e.B) && b.Vertices.Contains(e.A)));
        }

        private void ContractVertices(Vertex vertexOne, Vertex vertexTwo)
        {
            m_edges.RemoveAll(e => vertexOne.Vertices.Contains(e.A) && vertexTwo.Vertices.Contains(e.B));
            m_edges.RemoveAll(e => vertexOne.Vertices.Contains(e.B) && vertexTwo.Vertices.Contains(e.A));

            m_vertices.Remove(vertexTwo);
            vertexOne.Contract(vertexTwo);
        }

        private Edge PickRandomEdge()
        {
            var edgesCount = m_edges.Count;
            var randomEdge = m_edges[m_random.Next(0, edgesCount)];

            return randomEdge;
        }

        private void Setup(Dictionary<int, List<int>> graph)
        {
            m_random = new Random((int) DateTime.Now.Ticks);
            m_vertices = graph.Select(g => new Vertex(g.Key)).ToList();
            m_edges = graph.SelectMany(g => g.Value.Select(n => new Edge(g.Key, n))).Distinct().ToList();
            m_originalGraph = graph.ToDictionary(g => g.Key, g => g.Value.ToArray().ToList());
        }

        private class Edge
        {

            public override int GetHashCode()
            {
                unchecked
                {
                    return (A*397) ^ B;
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
                return Equals((Edge) obj);
            }
        }
    
        private class Vertex
        {
            public List<int> Vertices;

            public Vertex(int a)
            {
                Vertices = new List<int> {a};
            }

            public Vertex(List<int> a)
            {
                Vertices = a;
            }

            public void Contract(Vertex second)
            {
                Vertices.AddRange(second.Vertices.Where(v => !Vertices.Contains(v)));
            }
        }
    }
}