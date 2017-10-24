﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicProgramming
{
    public class MoneyChangeCalculator
    {
        public int RecursiveIterationIndex { get; private set; }
        public int DynamicIterationIndex { get; private set; }

        private readonly List<int> changeValues = new[] { 1, 2, 5, 10, 20 }.ToList();

        public List<int> Compute(int number)
        {
            RecursiveIterationIndex = 0;
            DynamicIterationIndex = 0;

            var recursiveCompute = ComputeRecursive(number);

            var memoizeHash = new Dictionary<int, List<int>>()
            {
                [1] = new List<int>(1),
                [2] = new List<int>(2),
                [5] = new List<int>(5),
                [10] = new List<int>(10),
                [20] = new List<int>(20)
            };

            DynamicIterationIndex += 5;

            var dynamicCompute = ComputeDynamic(number, memoizeHash);

            if (recursiveCompute.Count != dynamicCompute.Count) throw new Exception("Results are not the same there is a bug!");

            return dynamicCompute;
        }


        private List<int> ComputeRecursive(int number)
        {
            if(number == 0) return new List<int>();
            RecursiveIterationIndex++;

            var validChanges = changeValues.Where(cv => cv <= number);
            var leastCoins = new List<int>();

            foreach (var validChange in validChanges)
            {
                var coins = ComputeRecursive(number - validChange);
                coins.Add(validChange);

                if (!leastCoins.Any())
                {
                    leastCoins = coins;
                }

                if (coins.Count < leastCoins.Count)
                {
                    leastCoins = coins;
                }
            }

            return leastCoins;
        }

        private List<int> ComputeDynamic(int number, Dictionary<int, List<int>> memoizeHash)
        {
            if (number == 0) return new List<int>();
            if (memoizeHash.ContainsKey(number)) return memoizeHash[number];

            DynamicIterationIndex++;

            var validChanges = changeValues.Where(cv => cv <= number);
            var leastCoins = new List<int>();

            foreach (var validChange in validChanges)
            {
                var coins = ComputeRecursive(number - validChange);
                coins.Add(validChange);

                if (!leastCoins.Any())
                {
                    leastCoins = coins;
                }

                if (coins.Count < leastCoins.Count)
                {
                    leastCoins = coins;
                }
            }

            memoizeHash[number] = leastCoins;
            return leastCoins;
        }
    }
}