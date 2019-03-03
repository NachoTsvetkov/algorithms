using System.IO;
using System;
using System.Linq;

class Solution
{

    // Complete the sockMerchant function below.
    // Complete the repeatedString function below.
    static long repeatedString(string s, long n)
    {
        long occurences = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'a')
            {
                occurences++;
            }
        }

        occurences *= n / s.Length;
        var remainder = n % s.Length;

        for (int i = 0; i < remainder; i++)
        {
            if (s[i] == 'a')
            {
                occurences++;
            }
        }

        return occurences;
    }

    static void Main(string[] args)
    {
        string s = Console.ReadLine();

        long n = Convert.ToInt64(Console.ReadLine());

        long result = repeatedString(s, n);

        Console.WriteLine(result);
    }
}