using System;

class Solution
{

    // Complete the alternatingCharacters function below.
    static int AlternatingCharacters(string s)
    {
        var skipCount = 0;
        for (int i = 0; i < s.Length - 1; i++)
        {
            var current = s[i];
            var next = s[i + 1];

            if (current == next)
            {
                skipCount++;
            }
        }

        return skipCount;
    }

    static void Main(string[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = AlternatingCharacters(s);

            Console.WriteLine(result);
        }
    }
}
