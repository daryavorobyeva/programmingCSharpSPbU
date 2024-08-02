using System.Text;
using Routers.Exceptions;

namespace Routers;

/// <summary>
/// Builds the optimal configuration of the router network
/// using the Prim's algorithm for graphs and building the maximum spanning tree.
/// </summary>
public class TopologyConfiguration
{
    /// <summary>
    /// An edge of a graph has two nodes that it connects and the length of the edge.
    /// </summary>
    private class GraphEdge
    {
        public int Weight { get; }
        public int FirstVertex { get; }
        public int SecondVertex { get; }

        public GraphEdge(int weight, int firstVertex, int secondVertex)
        {
            Weight = weight;
            FirstVertex = firstVertex;
            SecondVertex = secondVertex;
        }
    }

    /// <summary>
    /// Finds the maximum edge in length from those that are not yet included 
    /// in the spanning tree and does not close the cycle.
    /// </summary>
    /// <param name="markedVertices"></param>
    /// <param name="graph"></param>
    /// <returns></returns>
    private static GraphEdge FindMaxEdge(HashSet<int> markedVertices, List<GraphEdge> graph)
    {
        var maxEdge = new GraphEdge(int.MinValue, 0, 0);
        foreach (var edge in graph)
        {
            if ((markedVertices.Contains(edge.FirstVertex) && !markedVertices.Contains(edge.SecondVertex))
                || (markedVertices.Contains(edge.SecondVertex) && !markedVertices.Contains(edge.FirstVertex)))
            {
                if (edge.Weight > maxEdge.Weight)
                {
                    maxEdge = edge;
                }
            }
        }
        return maxEdge;
    }

    /// <summary>
    /// Prim's algorithm.
    /// </summary>
    /// <param name="graph"></param>
    /// <param name="countInitialVerticies"></param>
    /// <returns></returns>
    /// <exception cref="TopologyNotConnectedException"></exception>
    private static List<GraphEdge> PrimsAlgorithm(List<GraphEdge> graph, int countInitialVerticies)
    {
        var spanningTree = new List<GraphEdge>();
        var markedVertices = new HashSet<int> { 1 };

        while (markedVertices.Count < countInitialVerticies)
        {
            GraphEdge currentMaxEdge = FindMaxEdge(markedVertices, graph);
            if (currentMaxEdge.Weight == int.MinValue)
            {
                break;
            }
            spanningTree.Add(currentMaxEdge);
            markedVertices.Add(currentMaxEdge.FirstVertex);
            markedVertices.Add(currentMaxEdge.SecondVertex);
        }

        if (markedVertices.Count != countInitialVerticies)
        {
            throw new TopologyNotConnectedException("Not every router is reachable.");
        }

        return spanningTree;
    }

    private static (List<GraphEdge>, int) ParseStringToGraph(string inputString)
    {
        var vertices = new HashSet<int>();
        var graph = new List<GraphEdge>();

        foreach (var component in inputString.Split("\n"))
        {
            var data = component.Split(":");
            var firstVertex = int.Parse(data[0]);

            foreach (var verticiesWithEdges in data[1].Split(','))
            {
                var current = verticiesWithEdges.Replace("(", "").Replace(")", "").Split(" ");

                if (current.Length < 3)
                {
                    throw new FormatException("Wrong topology format.");
                }

                var secondVertex = int.Parse(current[1]);
                var edgeWeight = int.Parse(current[2]);

                if (edgeWeight <= 0)
                {
                    throw new ArgumentException("Throughput can't be negative or equal to zero.");
                }

                graph.Add(new GraphEdge(edgeWeight, firstVertex, secondVertex));
                vertices.Add(secondVertex);
            }
            vertices.Add(firstVertex);
        }
        return (graph, vertices.Count);
    }

    private static string ParseGraphToString(List<GraphEdge> edges)
    {
        var builder = new StringBuilder();
        foreach (var edge in edges)
        {
            var edgeRepresentation = $"{edge.FirstVertex}: {edge.SecondVertex} ({edge.Weight})";
            builder.Append(edgeRepresentation + '\n');
        }
        return builder.ToString();
    }

    /// <summary>
    /// The final function for building an optimal router network.
    /// </summary>
    /// <param name="topology"></param>
    /// <returns></returns>
    public static string BuildClearTopology(string topology)
    {
        var graphFromTopology = ParseStringToGraph(topology);
        var newGraph = PrimsAlgorithm(graphFromTopology.Item1, graphFromTopology.Item2);

        return ParseGraphToString(newGraph);
    }
}