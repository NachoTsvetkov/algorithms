using System.IO;
using System;

class Solution
{

    // Complete the minimumAbsoluteDifference function below.
    static int minimumAbsoluteDifference(int[] arr)
    {
        var minDiff = int.MaxValue;
        Array.Sort(arr);
        for (var i = 0; i < arr.Length - 1; i++)
        {
            var diff = Math.Abs(arr[i] - arr[i + 1]);
            if (diff < minDiff)
            {
                minDiff = diff;
            }
        }

        return minDiff;
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        int result = minimumAbsoluteDifference(arr);

        Console.WriteLine(result);
    }
}
