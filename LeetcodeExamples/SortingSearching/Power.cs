using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LeetcodeExamples.SortingSearching
{
    public class Power
    {

        private static double BinaryExp(double x, long n)
        {
            // Base case, to stop recursive calls.
            if (n == 0)
            {
                return 1;
            }

            // Handle case where, n < 0.
            if (n < 0)
            {
                return 1.0 / BinaryExp(x, -1 * n);
            }

            // Perform Binary Exponentiation.
            // If 'n' is odd we perform Binary Exponentiation on 'n - 1' and
            // multiply result with 'x'.
            if (n % 2 == 1)
            {
                return x * BinaryExp(x * x, (n - 1) / 2);
            }
            // Otherwise we calculate result by performing Binary Exponentiation on
            // 'n'.
            else
            {
                return BinaryExp(x * x, n / 2);
            }
        }

        public static double MyPow(double x, int n)
        {
            if (n==0) return 1;
         

            int counter = 1;
            double result = 1;

            while (counter <= Math.Abs(n))
            {
                result *= x;
                counter++;
            }

            if (n<=0)
            {
                return 1/result;
            }

            return result;
        }
        public static void Run()
        {


            var output = BinaryExp(0.00001, 2147483647);

             output = MyPow(0.00001, 2147483647);
        }

    }
}
