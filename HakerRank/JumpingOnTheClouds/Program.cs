using System.IO;
using System;
using System.Linq;

class Solution
{

    // Complete the sockMerchant function below.
    static int JumpingOnClouds(int[] c)
    {
        var jumps = 0;
        for (int i = 0; i < c.Length; )
        {
            var leapIsSafe = c.Length > i + 2 && c[i + 2] != 1;
            var stepIsSafe = c.Length > i + 1 && c[i + 1] != 1;

            if (!(leapIsSafe || stepIsSafe))
            {
                break;
            }

            var move = leapIsSafe ? 2 : 1;
            jumps++;
            i += move;
        }

        return jumps;
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        int result = JumpingOnClouds(c);

        Console.WriteLine(result);
    }
}