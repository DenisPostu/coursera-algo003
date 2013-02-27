using System;
using System.Collections.Generic;
using System.Linq;
using Coursera.DataStructures.Graphs;

namespace Coursera.Implementations.ProgrammingQuestions.Question04
{
    public class GraphComponentsConnector
    {
        private int m_vertex;
        private Dictionary<int, List<int>> m_outgoing = new Dictionary<int, List<int>>();
        private Dictionary<int, List<int>> m_incoming = new Dictionary<int, List<int>>();
        private HashSet<int> m_visited = new HashSet<int>(); 
        private Stack<int> m_exclusionStack = new Stack<int>();

        public IEnumerable<List<int>> FindConnectedComponents(int a, int b, List<DirectedEdge> adjacencyList)
        {
            for (var i = a; i <= b; ++i)
            {
                m_outgoing.Add(i, new List<int>());
                m_incoming.Add(i, new List<int>());
            }

            foreach (var edge in adjacencyList)
            {
                m_outgoing[edge.A].Add(edge.B);
                m_incoming[edge.B].Add(edge.A);
            }

            for (var i = b; i >= a; --i)
            {
                if (m_visited.Contains(i)) continue;
                DFS1(i);
            }

            m_visited.Clear();

            while (m_exclusionStack.Any())
            {
                m_vertex = m_exclusionStack.Pop();
                if (m_visited.Contains(m_vertex)) continue;
                
                var list = new List<int>();
                DFS2(m_vertex, list);
                yield return list;
            }
        }

        private void DFS2(int i, List<int> list)
        {
            m_visited.Add(i);
            list.Add(i);
            foreach (var j in m_outgoing[i])
            {
                if (m_visited.Contains(j)) continue;
                DFS2(j, list);
            }
        }

        private void DFS1(int i)
        {
            m_visited.Add(i);
            foreach (var j in m_incoming[i])
            {
                if (m_visited.Contains(j)) continue;
                DFS1(j);
            }
            m_exclusionStack.Push(i);
        }
    }
}