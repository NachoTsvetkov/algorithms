using System;
using System.Collections.Generic;

class Solution
{

    // Complete the luckBalance function below.
    static int LuckBalance(int k, int[][] contests)
    {
        var totalLuck = 0;
        var lostImportant = 0;

        var sortDescendingComparer = new Comparison<int[]>((x, y) => y[0] - x[0]);
        Array.Sort(contests, sortDescendingComparer);

        for (int i = 0; i < contests.Length; i++)
        {
            var luck = contests[i][0];
            var isImportant = contests[i][1] == 1;

            if (isImportant)
            {
                if (lostImportant < k)
                {
                    totalLuck += luck;
                    lostImportant++;
                }
                else
                {
                    totalLuck -= luck;
                }
            }
            else
            {
                totalLuck += luck;
            }
        }

        return totalLuck;
    }

    static void Main(string[] args)
    {
        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[][] contests = new int[n][];

        for (int i = 0; i < n; i++)
        {
            contests[i] = Array.ConvertAll(Console.ReadLine().Split(' '), contestsTemp => Convert.ToInt32(contestsTemp));
        }

        int result = LuckBalance(k, contests);

        Console.WriteLine(result);
    }
}
