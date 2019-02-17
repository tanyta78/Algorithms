using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;


    private HashSet<string> visited;
    private HashSet<string> cycleNodes;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
        this.visited = new HashSet<string>();
        this.cycleNodes = new HashSet<string>();
    }

    public ICollection<string> TopSort()
    {
        var result = new LinkedList<string>();
        TopSortIterative(result);

        //foreach (var node in this.graph.Keys)
        //{
        //    this.TopSortDfs(node, result);
        //}

        return result;
    }

    private void TopSortDfs(string node, LinkedList<string> result)
    {
        if (this.cycleNodes.Contains(node))
        {
            throw new InvalidOperationException();
        }

        if (!this.visited.Contains(node))
        {
            this.visited.Add(node);
            this.cycleNodes.Add(node);

            foreach (var child in this.graph[node])
            {
                this.TopSortDfs(child, result);
            }

            this.cycleNodes.Remove(node);
            result.AddFirst(node);
        }
    }

    private void TopSortIterative(LinkedList<string> result)
    {
        var nodesNoIncomingEdges = new HashSet<string>();

        HashSet<string> nodesWithIncomingEdges = this.GetNodesWithIncomingEdges();

        foreach (var graphKey in this.graph.Keys)
        {
            if (!nodesWithIncomingEdges.Contains(graphKey))
            {
                nodesNoIncomingEdges.Add(graphKey);
            }
        }

        while (nodesNoIncomingEdges.Count != 0)
        {
            var currentNode = nodesNoIncomingEdges.First();
            nodesNoIncomingEdges.Remove(currentNode);
            result.AddFirst(currentNode);

            var children = this.graph[currentNode].ToList();
            this.graph[currentNode] = new List<string>();

            var leftNodesWithIncomingEdges = this.GetNodesWithIncomingEdges();

            foreach (var child in children)
            {
                if (!leftNodesWithIncomingEdges.Contains(child))
                {
                    nodesNoIncomingEdges.Add(child);
                }
            }
        }

        if (this.graph.SelectMany(s => s.Value).Any())
        {
            throw new InvalidOperationException();
        }
    }

    private HashSet<string> GetNodesWithIncomingEdges()
    {
        var nodesWithIncomingEdges = new HashSet<string>();

        this.graph.SelectMany(s => s.Value).ToList().ForEach(e => nodesWithIncomingEdges.Add(e));


        return nodesWithIncomingEdges;
    }
}
