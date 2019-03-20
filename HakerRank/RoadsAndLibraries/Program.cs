using System;
using System.Collections.Generic;
using System.Numerics;

class Solution
{
    class City
    {
        public City()
        {
            this.NeighboursIndexes = new List<int>();
        }

        public List<int> NeighboursIndexes { get; }

        public bool HasBeenVisited { get; set; }
    }

    // Complete the roadsAndLibraries function below.
    static BigInteger RoadsAndLibraries(int numberOfCities, BigInteger costLib, BigInteger costRoad, int[][] roads)
    {
        if (costRoad > costLib)
        {
            return costLib * numberOfCities;
        }

        var cities = GetCities(numberOfCities, roads);

        BigInteger cost = 0;

        for (int i = 0; i < cities.Length; i++)
        {
            var city = cities[i];
            if (city.HasBeenVisited)
            {
                continue;
            }

            var clusterSize = GetClusterSize(i, cities);
            cost += (clusterSize - 1) * costRoad + costLib;
        }

        return cost;
    }

    private static BigInteger GetClusterSize(int i, City[] cities)
    {
        var clusterSize = 0;
        var stack = new Stack<City>();

        stack.Push(cities[i]);
        cities[i].HasBeenVisited = true;

        while (stack.Count > 0)
        {
            var city = stack.Pop();
            clusterSize++;

            foreach (var neighbourIndex in city.NeighboursIndexes)
            {
                var neighbour = cities[neighbourIndex];

                if (!neighbour.HasBeenVisited)
                {
                    stack.Push(neighbour);
                    neighbour.HasBeenVisited = true;
                }
            }
        }

        return clusterSize;
    }

    private static City[] GetCities(int numberOfCities, int[][] roads)
    {
        var cities = new City[numberOfCities];

        for (int i = 0; i < numberOfCities; i++)
        {
            cities[i] = new City(); 
        }

        foreach (var road in roads)
        {
            var firstCity = road[0] - 1;
            var secondCity = road[1] - 1;

            cities[firstCity].NeighboursIndexes.Add(secondCity);
            cities[secondCity].NeighboursIndexes.Add(firstCity);
        }

        return cities;
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

            BigInteger result = RoadsAndLibraries(n, c_lib, c_road, cities);

            Console.WriteLine(result);
        }
    }
}