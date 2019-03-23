using System.IO;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

class Solution
{

    // Complete the arrayManipulation function below.
    static long ArrayManipulation(int n, int[][] queries)
    {
        long maxVal = 0;
        var array = new long[n + 1];

        for (int i = 0; i < queries.Length; i++)
        {
            var start = queries[i][0];
            var end = queries[i][1];
            var val = queries[i][2];

            array[start] += val;
            if (end + 1 <= n)
            {
                array[end + 1] -= val;
            }
        }

        var sum = 0L;
        for (int i = 0; i < n; i++)
        {
            sum += array[i];
            if (sum > maxVal)
            {
                maxVal = sum;
            }
        }

        return maxVal;
    }

    static void Main(string[] args)
    {
        string[] nm = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        int[][] queries = new int[m][];

        for (int i = 0; i < m; i++)
        {
            queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
        }

        long result = ArrayManipulation(n, queries);

        Console.WriteLine(result);
    }
}
