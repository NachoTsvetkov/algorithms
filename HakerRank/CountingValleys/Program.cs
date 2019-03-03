using System.IO;
using System;
using System.Linq;

class Solution
{

    static int countingValleys(int n, string s)
    {
        var altitude = 0;
        var valleys = 0;
        var isValley = false;
        for (int i = 0; i < n; i++)
        {
            altitude += s[i] == 'U' ? 1 : -1;
            var valleyStarts = !isValley && altitude < 0;
            if (valleyStarts)
            {
                isValley = true;
                valleys++;
            }

            var valleyEnds = isValley && altitude >= 0;
            if (valleyEnds)
            {
                isValley = false;
            }
        }

        return valleys;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string s = Console.ReadLine();

        int result = countingValleys(n, s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}