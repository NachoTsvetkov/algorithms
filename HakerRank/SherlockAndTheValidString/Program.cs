using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{

    // Complete the isValid function below.
    static string IsValid(string s)
    {
        var frequencies = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            var ch = s[i];
            if (frequencies.ContainsKey(ch))
            {
                frequencies[ch]++;
            }
            else
            {
                frequencies.Add(ch, 1);
            }
        }

        var mostCommonFrequency = frequencies
            .GroupBy(f => f.Value)
            .Select(g => new { Frequency = g.Key, Count = g.Count() })
            .OrderByDescending(c => c.Count)
            .FirstOrDefault()
            .Frequency;

        var isValid = true;
        var hasSingleDifference = false; 
        foreach (var frequency in frequencies)
        {
            if (frequency.Value != mostCommonFrequency)
            {
                if (hasSingleDifference || frequency.Value > mostCommonFrequency + 1)
                {
                    isValid = false;
                    break;
                }

                hasSingleDifference = true;
            }
        }


        return isValid ? "YES" : "NO";
    }

    static void Main(string[] args)
    {
        string s = Console.ReadLine();

        string result = IsValid(s);

        Console.WriteLine(result);
    }
}
