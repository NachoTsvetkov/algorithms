using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    public class SubstringData
    {
        public Dictionary<char, int> Data { get; set; }

        public int WordLength { get; set; }

        public SubstringData()
        {

        }

        public SubstringData(string substring)
        {
            var substringArray = substring.ToCharArray();

            this.Data = new Dictionary<char, int>();
            this.WordLength = substringArray.Length;

            foreach (var character in substringArray)
            {
                if (this.Data.ContainsKey(character))
                {
                    this.Data[character]++;
                }
                else
                {
                    this.Data.Add(character, 1);
                }
            }
        }
    }
    // Complete the sherlockAndAnagrams function below.
    static int SherlockAndAnagrams(string input)
    {
        var substringDataList = new List<SubstringData>();
        for (int j = 1; j < input.Length; j++)
        {
            for (int i = 0; i <= input.Length - j; i++)
            {
                var substring = input.Substring(i, j);
                var substringData = new SubstringData(substring);
                substringDataList.Add(substringData);
            }
        }

        var anagramCount = 0;

        for (int i = 0; i < substringDataList.Count - 1; i++)
        {
            var firstData = substringDataList[i];
            for (int j = i + 1; j < substringDataList.Count && substringDataList[j].WordLength == firstData.WordLength; j++)
            {
                var secondData = substringDataList[j];
                var areAnagrams = CheckForAnagram(anagramCount, firstData.Data, secondData.Data);

                if (areAnagrams)
                {
                    anagramCount++;
                }
            }
        }

        return anagramCount;
    }

    private static bool CheckForAnagram(int anagramCount, Dictionary<char, int> firstData, Dictionary<char, int> secondData)
    {
        var areAnagrams = true;
        if (firstData.Count == secondData.Count)
        {
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
        }
        else
        {
            areAnagrams = false;
        }

        return areAnagrams;
    }

    static void Main(string[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = SherlockAndAnagrams(s);

            Console.WriteLine(result);
        }
    }
}
