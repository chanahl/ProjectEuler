// <copyright file="Problem021.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using System.Linq;
using Common.Framework.Core.Logging;
using ProjectEuler.Mathematics;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Amicable numbers
    /// -
    /// Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
    /// If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.
    /// For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
    /// Evaluate the sum of all the amicable numbers under 10000.
    /// </summary>
    public class Problem021 : Problem
    {
        private int _sumOfAmicableNumbers;

        public Problem021()
        {
            Limit = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem021Key]
                    .Collection[ProjectEulerConstants.Problem021LimitKey]);
        }

        public Problem021(int limit)
        {
            Limit = limit;
        }

        public int Limit { get; set; }
        
        public override dynamic Solve()
        {
            for (var a = 2; a <= Limit; a++)
            {
                var dA = a.CalculateProperDivisors();
                var b = dA.Sum();

                // Eliminate double counting.
                if (b <= a)
                {
                    continue;
                }

                var dB = b.CalculateProperDivisors();

                // Amicable pair found.
                if (dB.Sum() == a)
                {
                    _sumOfAmicableNumbers += a + b;
                }
            }

            return _sumOfAmicableNumbers;
        }

        protected override void LogResult()
        {
            ResultMessage =
                "The sum of all the amicable numbers under [" +
                Limit +
                "] is [" +
                _sumOfAmicableNumbers +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }
    }
}
