using System;
using System.Collections.Generic;
using System.IO;

class Solution
{

    public static int Fibonacci(int n)
    {
        if (n == 0)
        {
            return 0;
        }

        var sequence = new int[n + 1];
        sequence[0] = 0;
        sequence[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            sequence[i] = sequence[i - 1] + sequence[i - 2];
        }

        var value = sequence[n];
        return value;
    }

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(Fibonacci(n));
    }
}

