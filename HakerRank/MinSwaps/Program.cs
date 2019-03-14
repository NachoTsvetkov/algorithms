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

    // Complete the minimumSwaps function below.
    static int MinimumSwaps(int[] arr)
    {
        var minSwaps = 0;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] == i + 1)
            {
                continue;
            }
            // swap
            Swap(arr, i);

            minSwaps++;
            i--;
            
        }

        return minSwaps;
    }

    private static void Swap(int[] arr, int i)
    {
        var tmp = arr[i]; // temporary variable for the swap
        arr[i] = arr[arr[i] - 1];
        arr[tmp - 1] = tmp;
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int res = MinimumSwaps(arr);

        Console.WriteLine(res);
    }
}
