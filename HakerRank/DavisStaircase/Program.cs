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

    // Complete the stepPerms function below.
    static int StepPerms(int n)
    {
        if (n < 3)
        {
            return n;
        }

        var numberOfCombinations = 0;

        for (int a = 0; a * 3 < n; a++)
        {
            var aSteps = a * 3;
            var aReminder = n - aSteps;

            for (int b = 0; b < aReminder / 2; b++)
            {
                var bSteps = b * 2;
                var bReminder = n - bSteps;

                var c = bReminder;
                numberOfCombinations += bReminder;
            }
        }

        return numberOfCombinations;
    }

    static void Main(string[] args)
    {
        int s = Convert.ToInt32(Console.ReadLine());

        for (int sItr = 0; sItr < s; sItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int res = StepPerms(n);

            Console.WriteLine(res);
        }
    }
}
