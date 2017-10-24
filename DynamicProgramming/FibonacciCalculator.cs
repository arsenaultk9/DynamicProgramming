using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    public class FibonacciCalculator
    {
        public int RecursiveIterationIndex { get; private set; }
        public int DynamicIterationIndex { get; private set; }

        public int Compute(int number)
        {
            RecursiveIterationIndex = 0;
            DynamicIterationIndex = 0;

            var recursiveCompute = ComputeRecursive(number);

            var memoizeHash = new Dictionary<int, int>()
            {
                [0] = 0,
                [1] = 1
            };

            DynamicIterationIndex += 2; // To include two previous entries.

            var dynamicCompute = ComputeDynamic(number, memoizeHash);

            if(recursiveCompute != dynamicCompute) throw new Exception("Results are not the same there is a bug!");

            return dynamicCompute;
        }
        

        private int ComputeRecursive(int number)
        {
            RecursiveIterationIndex++;
            if (number <= 1) return number;

            return ComputeRecursive(number - 1) + ComputeRecursive(number - 2);
        }

        private int ComputeDynamic(int number, Dictionary<int, int> memoizeHash)
        {
            return GetResultFromCacheOrComputed(number - 1, memoizeHash) + GetResultFromCacheOrComputed(number - 2, memoizeHash);
        }

        private int GetResultFromCacheOrComputed(int number, Dictionary<int, int> memoizeHash)
        {
            if (memoizeHash.ContainsKey(number)) return memoizeHash[number];

            var result = ComputeDynamic(number, memoizeHash);
            memoizeHash[number] = result;
            DynamicIterationIndex++;

            return result;
        }
    }
}
