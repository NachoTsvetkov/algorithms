using System;

class Solution
{

    // Complete the rotLeft function below.
    static int[] rotLeft(int[] a, int d)
    {
        var b = new int[a.Length];

        for (int i = 0; i < b.Length; i++)
        {
            var indexToCopy = i + d;
            if (indexToCopy >= a.Length)
            {
                indexToCopy -= a.Length;
            }

            b[i] = a[indexToCopy];
        }

        return b;
    }

    static void Main(string[] args)
    {
        string[] nd = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nd[0]);

        int d = Convert.ToInt32(nd[1]);

        int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp))
        ;
        int[] result = rotLeft(a, d);

        Console.WriteLine(string.Join(" ", result));
    }
}
