using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the findShortest function below.

    /*
     * For the unweighted graph, <name>:
     *
     * 1. The number of nodes is <name>Nodes.
     * 2. The number of edges is <name>Edges.
     * 3. An edge exists between <name>From[i] to <name>To[i].
     *
     */

    class Node
    {
        public long ColorId { get; set; }

        public List<Node> ConnectedNodes { get; set; }
    }


    static int FindShortest(int numberOfNodes, int[] fromEdgeValues, int[] toEdgeValues, long[] colorIds, int colorIdToEvaluate)
    {
        var colorNodes = GetEvaluationColorNodes(numberOfNodes, fromEdgeValues, toEdgeValues, colorIds, colorIdToEvaluate);

        if (colorNodes.Count <= 1)
        {
            return -1;
        }

        var shortestPath = GetShortestPath(colorNodes);

        return shortestPath;
    }

    private static int GetShortestPath(List<Node> colorNodes)
    {
        var shortestPath = int.MaxValue;
        foreach (var node in colorNodes)
        {
            var currentShortestPath = GetShortestPath(node, shortestPath);
            shortestPath = Math.Min(shortestPath, currentShortestPath);
        }

        return shortestPath;
    }

    private static int GetShortestPath(Node root, int shortestPath)
    {
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);
        var lastRowElement = root;

        var depth = 0;
        while (queue.Count > 0 && depth < shortestPath)
        {
            var node = queue.Dequeue();

            foreach (var connectedNode in node.ConnectedNodes)
            {
                queue.Enqueue(connectedNode);
            }

            if (node != root && node.ColorId == root.ColorId)
            {
                break;
            }

            if (node == lastRowElement)
            {
                lastRowElement = queue.Last();
                depth++;
            }
        }

        var pathLength = depth == 0 ? int.MaxValue : depth;
        return pathLength;
    }

    private static List<Node> GetEvaluationColorNodes(int numberOfNodes, int[] fromEdgeValues, int[] toEdgeValues, long[] colorIds, int colorIdToEvaluate)
    {
        var nodes = new Node[numberOfNodes];
        var colorNodes = new List<Node>();
        for (int i = 0; i < numberOfNodes; i++)
        {
            var colorId = colorIds[i];
            var node = new Node
            {
                ColorId = colorId,
                ConnectedNodes = new List<Node>()
            };

            nodes[i] = node;

            if (colorIdToEvaluate == colorId)
            {
                colorNodes.Add(node);
            }
        }

        var numberOfEdges = fromEdgeValues.Length;
        for (int i = 0; i < numberOfEdges; i++)
        {
            var firstNodeIndex = fromEdgeValues[i] - 1;
            var secondNodeIndex = toEdgeValues[i] - 1;

            var firstNode = nodes[firstNodeIndex];
            var secondNode = nodes[secondNodeIndex];

            firstNode.ConnectedNodes.Add(secondNode);
            secondNode.ConnectedNodes.Add(firstNode);
        }

        return colorNodes;
    }

    static void Main(string[] args)
    {
        string[] graphNodesEdges = Console.ReadLine().Split(' ');
        int numberOfNodes = Convert.ToInt32(graphNodesEdges[0]);
        int numberOfEdges = Convert.ToInt32(graphNodesEdges[1]);

        int[] graphFrom = new int[numberOfEdges];
        int[] graphTo = new int[numberOfEdges];

        for (int i = 0; i < numberOfEdges; i++)
        {
            string[] graphFromTo = Console.ReadLine().Split(' ');
            graphFrom[i] = Convert.ToInt32(graphFromTo[0]);
            graphTo[i] = Convert.ToInt32(graphFromTo[1]);
        }

        var idsString = Console.ReadLine();
        var idsArray = idsString.Split(' ')
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(x => Convert.ToInt64(x))
            .ToArray();

        long[] ids = idsArray;
        int val = Convert.ToInt32(Console.ReadLine());

        int ans = FindShortest(numberOfNodes, graphFrom, graphTo, ids, val);

        Console.WriteLine(ans);
    }
}
