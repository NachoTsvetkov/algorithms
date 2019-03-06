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

    // Complete the checkMagazine function below.
    static void checkMagazine(string[] magazine, string[] note)
    {
        var canMakeNote = true;
        var magazineDict = new Dictionary<string, int>();

        foreach (var word in magazine)
        {
            if (magazineDict.ContainsKey(word))
            {
                magazineDict[word]++;
            }
            else
            {
                magazineDict.Add(word, 1);
            }
        }

        foreach (var word in note)
        {
            if (magazineDict.ContainsKey(word) && magazineDict[word] > 0)
            {
                magazineDict[word]--;
            }
            else
            {
                canMakeNote = false;
                break;
            }
        }

        Console.WriteLine(canMakeNote ? "Yes" : "No");
    }

    static void Main(string[] args)
    {
        string[] mn = Console.ReadLine().Split(' ');

        int m = Convert.ToInt32(mn[0]);

        int n = Convert.ToInt32(mn[1]);

        string[] magazine = Console.ReadLine().Split(' ');

        string[] note = Console.ReadLine().Split(' ');

        checkMagazine(magazine, note);
    }
}
