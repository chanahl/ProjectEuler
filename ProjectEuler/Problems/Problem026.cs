// <copyright file="Problem026.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using Common.Framework.Core.Logging;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Reciprocal cycles
    /// -
    /// A unit fraction contains 1 in the numerator. 
    /// The decimal representation of the unit fractions with denominators 2 to 10 are given:
    ///  1/2 = 0.5
    ///  1/3 = 0.(3)
    ///  1/4 = 0.25
    ///  1/5 = 0.2
    ///  1/6 = 0.1(6)
    ///  1/7 = 0.(142857)
    ///  1/8 = 0.125
    ///  1/9 = 0.(1)
    /// 1/10 = 0.1
    /// Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.
    /// Find the value of d &lt; 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.
    /// </summary>
    public class Problem026 : Problem
    {
        private int _denominator;

        public Problem026()
        {
            Limit = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem026Key]
                    .Collection[ProjectEulerConstants.Problem026LimitKey]);
        }

        public Problem026(int limit)
        {
            Limit = limit;
        }

        public int Limit { get; set; }

        /// <summary>
        /// Calculates the denominator d, for which 1/d contains the longest recurring cycle in its decimal fraction part.
        /// -
        /// Example
        ///  1 mod 7: remainder = 1, found[1] = 0
        /// 10 mod 7: remainder = 3, found[3] = 1
        /// 30 mod 7: remainder = 2, found[2] = 2
        /// 20 mod 7: remainder = 6, found[6] = 3
        /// 60 mod 7: remainder = 4, found[4] = 4
        /// 40 mod 7: remainder = 5, found[5] = 5
        /// 50 mod 7: remainder = 1, found[1] = 6
        /// </summary>
        /// <returns>
        /// An integer.
        /// </returns>
        public override dynamic Solve()
        {
            _denominator = 0;
            var longestRecurringCycle = 0;
            for (var d = Limit - 1; d > 1; d--)
            {
                // Given d, one can only have at most d-1 different possible remainders.
                if (longestRecurringCycle >= d)
                {
                    break;
                }

                // Found remainders for this denominator.
                var found = new int[d];
                var remainderIndex = 0;
                var remainder = 1;
                while (found[remainder] == 0 && !remainder.Equals(0))
                {
                    found[remainder] = remainderIndex;
                    remainder = (10 * remainder) % d;
                    remainderIndex++;
                }

                longestRecurringCycle = remainderIndex - found[remainder];
                _denominator = d;
            }

            return _denominator;
        }

        protected override void LogResult()
        {
            ResultMessage =
                "The value of d < [" +
                Limit +
                "] for which 1/d contains the longest recurring cycle in its decimal fraction part is [" +
                _denominator +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }
    }
}
