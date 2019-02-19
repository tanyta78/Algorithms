namespace Dijkstra
{
    using System;
    using System.Collections.Generic;

    public static class DijkstraWithPriorityQueue
    {
        public static List<int> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, int>> graph, Node sourceNode, Node destinationNode)
        {

            var previous = new int?[graph.Count];
            var visited = new bool[graph.Count];
            var priorityQueue = new PriorityQueue<Node>();

            foreach (var kvp in graph)
            {
                kvp.Key.DistanceFromStart = Double.PositiveInfinity;
            }

            sourceNode.DistanceFromStart = 0;
            priorityQueue.Enqueue(sourceNode);

            while (priorityQueue.Count > 0)
            {
                var smallest = priorityQueue.ExtractMin();

                if (smallest == destinationNode)
                {
                    break;
                }

                foreach (var node in graph[smallest])
                {
                    if (!visited[node.Key.Id])
                    {
                        priorityQueue.Enqueue(node.Key);
                        visited[node.Key.Id] = true;
                    }

                    var distance = smallest.DistanceFromStart + node.Value;

                    if (distance < node.Key.DistanceFromStart)
                    {
                        node.Key.DistanceFromStart = distance;
                        previous[node.Key.Id] = smallest.Id;
                        priorityQueue.DecreaseKey(node.Key);
                    }
                }
            }

            if (double.IsInfinity(destinationNode.DistanceFromStart))
            {
                return null;
            }

            var path=new List<int>();
            int? current = destinationNode.Id;
            while (current!=null)
            {
                path.Add(current.Value);
                current = previous[current.Value];
            }

            path.Reverse();
            return path;
        }
    }
}
