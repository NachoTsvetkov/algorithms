using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{

    // Complete the sherlockAndAnagrams function below.
    static int sherlockAndAnagrams(string input)
    {
        var substringDataList = new List<Dictionary<char, int>>();
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 1; j <= input.Length - i; j++)
            {
                var substringArray = input.Substring(i, j).ToCharArray();
                var substringData = new Dictionary<char, int>();
                foreach (var character in substringArray)
                {
                    if (substringData.ContainsKey(character))
                    {
                        substringData[character]++;
                    }
                    else
                    {
                        substringData.Add(character, 1);
                    }
                }
                substringDataList.Add(substringData);
            }
        }

        var anagramCount = 0;

        for (int i = 0; i < substringDataList.Count; i++)
        {
            var firstData = substringDataList[i];
            for (int j = i + 1; j < substringDataList.Count; j++)
            {
                var secondData = substringDataList[j];

                if (firstData.Count == secondData.Count)
                {
                    var areAnagrams = true;
                    foreach (var characterData in firstData)
                    {
                        var containsSameChars = secondData.ContainsKey(characterData.Key)
                            && secondData[characterData.Key] == firstData[characterData.Key];
                        if (!containsSameChars)
                        {
                            areAnagrams = false;
                            break;
                        }
                    }

                    if (areAnagrams)
                    {
                        anagramCount++;
                    }
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
