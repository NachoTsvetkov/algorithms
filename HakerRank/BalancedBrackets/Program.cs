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

    // Complete the isBalanced function below.
    static string isBalanced(string s)
    {
        var matches = new Dictionary<char, char>
        {
            { '{', '}' },
            { '[', ']' },
            { '(', ')' }
        };

        var stack = new Stack<char>();
        foreach (var c in s)
        {
            if (matches.Keys.Contains(c))
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count == 0)
                {
                    return "NO";
                }

                var openingBracket = stack.Pop();
                if (c != matches[openingBracket])
                {
                    return "NO";
                }
            }
        }

        if (stack.Count > 0)
        {
            return "NO";
        }

        return "YES";
    }

    static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string s = Console.ReadLine();

            string result = isBalanced(s);

            Console.WriteLine(result);
        }

    }
}
