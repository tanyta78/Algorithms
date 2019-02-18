namespace PrimAlgoForMst
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Program
    {
        static HashSet<int> spanningTree = new HashSet<int>();
        static Dictionary<int, List<Edge>> nodesToEdges = new Dictionary<int, List<Edge>>();

        public static void Main(string[] args)
        {
            int numberOfVertices = 9;
            var graphEdges = new List<Edge>
            {
                new Edge(0, 3, 9),
                new Edge(0, 5, 4),
                new Edge(0, 8, 5),
                new Edge(1, 4, 8),
                new Edge(1, 7, 7),
                new Edge(2, 6, 12),
                new Edge(3, 5, 2),
                new Edge(3, 6, 8),
                new Edge(3, 8, 20),
                new Edge(4, 7, 10),
                new Edge(6, 8, 7)
            };

            var nodes = graphEdges.Select(e => e.StartNode).Union(graphEdges.Select(e => e.EndNode)).Distinct().OrderBy(e => e).ToList();

            foreach (var edge in graphEdges)
            {
                if (!nodesToEdges.ContainsKey(edge.StartNode))
                {
                    nodesToEdges.Add(edge.StartNode, new List<Edge>());
                }

                if (!nodesToEdges.ContainsKey(edge.EndNode))
                {
                    nodesToEdges.Add(edge.EndNode, new List<Edge>());
                }

                nodesToEdges[edge.StartNode].Add(edge);
                nodesToEdges[edge.EndNode].Add(edge);
            }

            foreach (var node in nodes)
            {
                if (!spanningTree.Contains(node))
                {
                    Prim(node);
                }
            }

        }

        private static void Prim(int startingNode)
        {
            spanningTree.Add(startingNode);

            var priorityQueue = new OrderedBag<Edge>();

            priorityQueue.AddMany(nodesToEdges[startingNode]);

            while (priorityQueue.Count != 0)
            {
                var minEdge = priorityQueue.GetFirst();
                priorityQueue.Remove(minEdge);

                var firstNode = minEdge.StartNode;
                var secondNode = minEdge.EndNode;

                var nonTreeNode = -1;
                if (spanningTree.Contains(firstNode) && !spanningTree.Contains(secondNode))
                {
                    nonTreeNode = secondNode;
                }

                if (!spanningTree.Contains(firstNode) && spanningTree.Contains(secondNode))
                {
                    nonTreeNode = firstNode;
                }

                if (nonTreeNode == -1)
                {
                    continue;
                }

                spanningTree.Add(nonTreeNode);
                Console.WriteLine($"{minEdge.StartNode} - {minEdge.EndNode}");

                priorityQueue.AddMany(nodesToEdges[nonTreeNode]);
            }
        }
    }
}
