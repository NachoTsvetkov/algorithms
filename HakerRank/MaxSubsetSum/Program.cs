using System;
using System.Collections.Generic;
using System.IO;

class Solution
{

    // Complete the maxSubsetSum function below.
    static int GetMaxSubsetSum(int[] arr)
    {
        if (arr.Length == 1)
        {
            return arr[0];
        }

        var maxSum = Math.Max(arr[0], arr[1]); 

        if (arr.Length == 2)
        {
            return maxSum;
        }

        var maxSubsetSums = new int[arr.Length];
        maxSubsetSums[0] = arr[0];
        maxSubsetSums[1] = maxSum;

        for (int i = 2; i < arr.Length; i++)
        {
            var prevSum = maxSubsetSums[i - 2];

            var currentMaxSum = Math.Max(prevSum, prevSum + arr[i]);
            currentMaxSum = Math.Max(currentMaxSum, arr[i]);
            currentMaxSum = Math.Max(currentMaxSum, maxSubsetSums[i - 1]);

            maxSubsetSums[i] = currentMaxSum;

            maxSum = Math.Max(currentMaxSum, maxSum);
        }

        return maxSum;
    }

    static void Main(string[] args)
    {
        using (var stream = File.OpenRead(@".\input03.txt"))
        using (var reader = new StreamReader(stream))
        {
            int n = Convert.ToInt32(reader.ReadLine());

            var input = reader.ReadLine();
            var values = input.Split(' ');
            int[] arr = Array.ConvertAll(values, value => Convert.ToInt32(value));
            int res = GetMaxSubsetSum(arr);

            Console.WriteLine(res);
        }
    }
}
