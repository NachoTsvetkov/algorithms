using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class GFG
{
    public class Node
    {
        public Node Root { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public int Key { get; set; }
    }

    static public int[] GetBstPreOrder(int[] inputArray)
    {
        var baseNodes = inputArray.Select(el => new Node { Key = el })
            .ToArray();
        var root = GetBalancedBst(baseNodes);
        var bstPreOrder = new List<int>();
        GetBstPreOrder(bstPreOrder, root);

        return bstPreOrder.ToArray();
    }

    static public Node GetBalancedBst(Node[] baseNodes)
    {
        var rootElementIndex = baseNodes.Length / 2;
        var root = baseNodes[rootElementIndex];

        var leftSideLenght = rootElementIndex;
        if (leftSideLenght > 0)
        {
            var leftSide = new Node[leftSideLenght];
            Array.Copy(baseNodes, 0, leftSide, 0, rootElementIndex);
            root.Left = GetBalancedBst(leftSide);
        }

        var rightSideLenght = baseNodes.Length - rootElementIndex - 1;
        if (rightSideLenght > 0)
        {
            var rightSide = new Node[rightSideLenght];
            Array.Copy(baseNodes, rootElementIndex + 1, rightSide, 0, rightSideLenght);
            root.Right = GetBalancedBst(rightSide);
        }

        return root;
    }

    static public void GetBstPreOrder(List<int> bstPreOrder, Node node)
    {
        bstPreOrder.Add(node.Key);

        if (node.Left != null)
        {
            GetBstPreOrder(bstPreOrder, node.Left);
        }

        if (node.Right != null)
        {
            GetBstPreOrder(bstPreOrder, node.Right);
        }
    }

    static public void Main()
    {
        var numberOfTestsString = Console.ReadLine();
        var numberOfTests = int.Parse(numberOfTestsString);
        for (var i = 0; i < numberOfTests; i++)
        {
            var arraySizeString = Console.ReadLine();
            var arraySize = int.Parse(numberOfTestsString);

            var inputArrayString = Console.ReadLine();
            var inputArray = inputArrayString.Split(' ', StringSplitOptions.None)
                .Select(s => int.Parse(s))
                .ToArray();

            var bstPreOrder = GetBstPreOrder(inputArray);
            var output = new StringBuilder();
            foreach (var val in bstPreOrder)
            {
                output.Append(val);
                output.Append(' ');
            }
            output.Remove(output.Length - 1, 1);

            Console.WriteLine(output);
        }
    }
}