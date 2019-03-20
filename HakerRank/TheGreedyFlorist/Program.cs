using System;
using System.Linq;
using System.Numerics;

class Solution
{

    // Complete the getMinimumCost function below.
    static BigInteger GetMinimumCost(int numberOfFriends, int[] costs)
    {
        var sortedCosts = costs.OrderByDescending(cost => cost).ToArray();

        BigInteger minCost = 0;
        var numberOfPurchases = 0;

        for (int i = 0; i < sortedCosts.Length; i++)
        {
            if (i != 0 && i % numberOfFriends == 0)
            {
                numberOfPurchases++;
            }

            minCost += (numberOfPurchases + 1) * sortedCosts[i];
        }

        return minCost;
    }

    static void Main(string[] args)
    {
        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        BigInteger minimumCost = GetMinimumCost(k, c);

        Console.WriteLine(minimumCost);
    }
}
