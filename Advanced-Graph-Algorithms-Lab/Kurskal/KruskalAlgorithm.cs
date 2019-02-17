namespace Kurskal
{
    using System.Collections.Generic;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {

            var parents = new int[numberOfVertices];

            for (int i = 0; i < numberOfVertices; i++)
            {
                parents[i] = i;
            }

            edges.Sort();
            var spanningTree = new List<Edge>();

            foreach (var edge in edges)
            {
                var startNode = edge.StartNode;
                var endNode = edge.EndNode;

                var rootStartNode = FindRoot(startNode, parents);
                var rootEndNode = FindRoot(endNode, parents);

                if (rootStartNode != rootEndNode)
                {
                    spanningTree.Add(edge);
                    parents[rootEndNode] = rootStartNode;
                }
            }

            return spanningTree;
        }

        public static int FindRoot(int node, int[] parent)
        {
            int root = node;
            while (parent[root] != root)
            {
                root = parent[root];
            }

            while (node != root)
            {
                int previousParent = parent[node];
                parent[node] = root;
                node = previousParent;
            }

            return root;
        }
    }
}
