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
    // Complete the whatFlavors function below.
    static void WhatFlavors(int[] cost, int money)
    {
        for (int i = 0; i < cost.Length - 1; i++)
        {
            for (int j = i + 1; j < cost.Length; j++)
            {
                if (money == cost[i] + cost[j])
                {
                    Console.WriteLine($"{i + 1} {j + 1}");
                }
            }
        }
    }

    static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int money = Convert.ToInt32(Console.ReadLine());

            int n = Convert.ToInt32(Console.ReadLine());

            int[] cost = Array.ConvertAll(Console.ReadLine().Split(' '), costTemp => Convert.ToInt32(costTemp));
            WhatFlavors(cost, money);
        }
    }
}
