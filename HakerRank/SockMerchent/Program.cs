using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

class Solution
{

    // Complete the sockMerchant function below.
    static int sockMerchant(int n, int[] ar)
    {
        var socks = new Dictionary<int, bool>();
        var count = 0;
        for (var i = 0; i < n; i++)
        {
            var sock = ar[i];

            if (!socks.ContainsKey(sock))
            {
                socks.Add(sock, false);
            }

            if (socks[sock])
            {
                count++;
            }

            socks[sock] = !socks[sock];
        }

        return count;
    }

    static void Main(string[] args)
    {
        using (var textWriter = new StreamWriter(Environment.GetEnvironmentVariable("OUTPUT_PATH"), true))
        {
            int n = Convert.ToInt32(Console.ReadLine());

            var inputArray = Console.ReadLine().Split(' ');

            var ar = inputArray
                .Where(inputValue => !string.IsNullOrEmpty(inputValue))
                .Select(inputValue => int.Parse(inputValue))
                .ToArray();
            int result = sockMerchant(n, ar);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
