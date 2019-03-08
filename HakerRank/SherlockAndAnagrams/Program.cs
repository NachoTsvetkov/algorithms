using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{

    // Complete the sherlockAndAnagrams function below.
    static int sherlockAndAnagrams(string s)
    {
        var substrings = new List<string>();
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = 1; j <= s.Length - i; j++)
            {
                substrings.Add(s.Substring(i, j));
            }
        }

        var anagramCount = 0;
        for (int i = 0; i < substrings.Count - 1; i++)
        {
            var charrAray = substrings[i].ToCharArray();
            Array.Reverse(charrAray);
            var anagram = new string(charrAray);

            for (int j = i + 1; j < substrings.Count; j++)
            {
                if (substrings[j] == anagram)
                {
                    anagramCount++;
                }
            }
        }

        return anagramCount;
    }

    static void Main(string[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = sherlockAndAnagrams(s);

            Console.WriteLine(result);
        }
    }
}
