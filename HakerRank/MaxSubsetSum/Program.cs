using System;
using System.Collections.Generic;

class Solution
{
    static Dictionary<int, int> MaxSubsetSums = new Dictionary<int, int>();

    // Complete the maxSubsetSum function below.
    static int GetMaxSubsetSum(int[] arr, int element = 0)
    {
        var subsetMaxSum = int.MinValue;
        for (int i = element + 2; i < arr.Length; i++)
        {
            var subsetSum = MaxSubsetSums.ContainsKey(i) ? MaxSubsetSums[i] : GetMaxSubsetSum(arr, i);
            subsetMaxSum = Math.Max(subsetMaxSum, subsetSum);
        }
        subsetMaxSum = Math.Max(0, subsetMaxSum);

        var maxSum = arr[element] + subsetMaxSum;
        return maxSum;
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        int res = Math.Max(GetMaxSubsetSum(arr, 0), GetMaxSubsetSum(arr, 1));

        Console.WriteLine(res);
    }
}
