using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Hard
{
    public class LongestIncreasingPath
    {
        public static int LongestIncreasingPath1(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            int[,] alreadyKnownResults = new int[m, n];
            int maxResult = int.MinValue;
            for (int row = 0; row < m; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    int currentResult = Dfs(row, column, int.MinValue);
                    maxResult = Math.Max(maxResult, currentResult);
                }
            }

            return maxResult;

            int Dfs(int row, int column, int previousValue)
            {
                if (row is -1 || column is -1 || row == m || column == n) return 0;

                int currentValue = matrix[row][column];
                if (currentValue > previousValue is false) return 0;

                if (alreadyKnownResults[row, column] is not 0) return alreadyKnownResults[row, column];

                int max = new[]
                {
                Dfs(row, column - 1, currentValue),
                Dfs(row, column + 1, currentValue),
                Dfs(row - 1, column, currentValue),
                Dfs(row + 1, column, currentValue)
            }.Max();

                int result = max + 1;
                alreadyKnownResults[row, column] = result;
                return result;
            }
        }


        public static void Run()
        {
            int[][] nums = [[9, 9, 4], [6, 6, 8], [2, 1, 1]];

            var output = LongestIncreasingPath1(nums);
        }
    }
}

