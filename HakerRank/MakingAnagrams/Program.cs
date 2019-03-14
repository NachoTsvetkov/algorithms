using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{

    // Complete the makeAnagram function below.
    static int MakeAnagram(string a, string b)
    {
        var letters = new Dictionary<char, int>();
        for (int i = 0; i < a.Length; i++)
        {
            var ch = a[i];
            if (letters.ContainsKey(ch))
            {
                letters[ch]++;
            }
            else
            {
                letters.Add(ch, 1);
            }
        }

        for (int i = 0; i < b.Length; i++)
        {
            var ch = b[i];
            if (letters.ContainsKey(ch))
            {
                letters[ch]--;
            }
            else
            {
                letters.Add(ch, -1);
            }
        }

        var diff = letters.Sum(x => Math.Abs(x.Value));

        return diff;
    }

    static void Main(string[] args)
    {
        string a = Console.ReadLine();

        string b = Console.ReadLine();

        int res = MakeAnagram(a, b);

        Console.WriteLine(res);
    }
}
