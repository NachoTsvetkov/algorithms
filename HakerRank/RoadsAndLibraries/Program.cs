using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    // Complete the roadsAndLibraries function below.
    static long RoadsAndLibraries(int numberOfCities, int libCost, int roadCost, int[][] roads)
    {
        if (roadCost > libCost)
        {
            return libCost * numberOfCities;
        }

        var roadLength = libCost / roadCost;

        var accessToLibrary = new bool[numberOfCities];

        var cost = 0L;
        for (int cityIndex = 0; cityIndex < numberOfCities; cityIndex++)
        {
            if (accessToLibrary[cityIndex] == true)
            {
                continue;
            }

            accessToLibrary[cityIndex] = true;
            var numberOfRoads = BuildRoads(cityIndex, roadLength, accessToLibrary, roads);
            cost += libCost + numberOfRoads * roadCost;
        }

        return cost;
    }

    private static int BuildRoads(int cityIndex, int roadLength, bool[] accessToLibrary, int[][] roads)
    {
        var cityName = cityIndex + 1;
        var roadCount = 0;

        for (int i = 0; i < roads.Length; i++)
        {
            var adjasentCityIndex = -1;

            if (roads[i][0] == cityName)
            {
                adjasentCityIndex = roads[i][1] - 1;
            }

            if (roads[i][1] == cityName)
            {
                adjasentCityIndex = roads[i][0] - 1;
            }

            if (adjasentCityIndex == -1)
            {
                continue;
            }

            if (!accessToLibrary[adjasentCityIndex])
            {
                accessToLibrary[adjasentCityIndex] = true;
                roadCount += 1;
                if (roadLength > 1)
                {
                    roadCount += BuildRoads(adjasentCityIndex, roadLength - 1, accessToLibrary, roads);
                }
            }
        }

        return roadCount;
    }

    static void Main(string[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] nmC_libC_road = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nmC_libC_road[0]);

            int m = Convert.ToInt32(nmC_libC_road[1]);

            int c_lib = Convert.ToInt32(nmC_libC_road[2]);

            int c_road = Convert.ToInt32(nmC_libC_road[3]);

            int[][] cities = new int[m][];

            for (int i = 0; i < m; i++)
            {
                cities[i] = Array.ConvertAll(Console.ReadLine().Split(' '), citiesTemp => Convert.ToInt32(citiesTemp));
            }

            long result = RoadsAndLibraries(n, c_lib, c_road, cities);

            Console.WriteLine(result);
        }

    }
}