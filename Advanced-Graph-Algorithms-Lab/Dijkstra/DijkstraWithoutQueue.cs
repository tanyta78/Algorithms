namespace Dijkstra
{
    using System;
    using System.Collections.Generic;

    public static class DijkstraWithoutQueue
    {
        public static List<int> DijkstraAlgorithm(int[,] graph, int sourceNode, int destinationNode)
        {
            var n = graph.GetLength(0);

            //Initialize distance[]
            var distance = new int[n];
            for (int i = 0; i < n; i++)
            {
                distance[i] = int.MaxValue;
            }

            distance[sourceNode] = 0;

            var used = new bool[n];
            var prev = new int?[n];

            //Find nearest unvisited node from the source
            while (true)
            {
                var minDistance = int.MaxValue;
                int minNode = 0;
                for (int node = 0; node < n; node++)
                {
                    if (!used[node] && distance[node]<minDistance)
                    {
                        minDistance = distance[node];
                        minNode = node;
                    }
                }

                if (minDistance==int.MaxValue)
                {
                    break;
                }

                used[minNode] = true;

                //Improve shortest distance
                for (int node = 0; node < n; node++)
                {
                    if (graph[minNode,node]>0)
                    {
                        var newDistance = minDistance+graph[minNode,node];

                        if (newDistance<distance[node])
                        {
                            distance[node] = newDistance;
                            prev[node] = minNode;
                        }
                    }
                }
            }
            if(distance[destinationNode] == int.MaxValue)
            {
                return null;
            }

            var path = new List<int>();
            int? currentNode = destinationNode;
            while(currentNode != null)
            {
                path.Add(currentNode.Value);
                currentNode = prev[currentNode.Value];
            }

            path.Reverse();

            return path;
           
        }
    }
}
