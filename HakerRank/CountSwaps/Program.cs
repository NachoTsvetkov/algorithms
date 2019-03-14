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

    // Complete the countSwaps function below.
    static void CountSwaps(int[] a)
    {
        var numSwaps = 0;

        for (int i = 0; i < a.Length; i++)
        {

            for (int j = 0; j < a.Length - 1; j++)
            {
                // Swap adjacent elements if they are in decreasing order
                if (a[j] > a[j + 1])
                {
                    Swap(a, j);
                    numSwaps++;
                }
            }

        }


        var firstElement = a[0];
        var lastElement = a[a.Length - 1];

        Console.WriteLine($"Array is sorted in {numSwaps} swaps.");
        Console.WriteLine($"First Element: {firstElement}");
        Console.WriteLine($"Last Element: {lastElement}");
    }

    private static void Swap(int[] array, int index)
    {
        var tmp = array[index];
        array[index] = array[index + 1];
        array[index + 1] = tmp;
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
        CountSwaps(a);
    }
}
